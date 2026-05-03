using FluentValidation;
using RoadmApp.Application.IServices;
using RoadmApp.Application.Responses;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using RoadmApp.Domain.Validations;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class CreateAccessUseCase : ICreateAccessUseCase
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ILogRepository _logRepository;

        public CreateAccessUseCase(IEmailService emailService, IUserRepository userRepository, ILogRepository logRepository, IContactRepository contactRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _logRepository = logRepository;
            _contactRepository = contactRepository;
        }

        public async Task<SuccessModel> CreateAccess(RegisterModel data)
        {
            CreateAccessValidation valid = new();
            Log logBody = new();
            Contact newContact = new();
            SuccessModel successResult = new();
            valid.ValidateAndThrow(data.ToBusiness());

            User? nickameAlreadyExists = await _userRepository.GetByNicknameAsync(data.Access.Nickname);

            Success errorDetected = NickNameAlreadyExists(nickameAlreadyExists);

            Contact? contactAlreadyExists = await _contactRepository.GetByEmailAsync(data.Contacts.Email);

            Success errorDetectedContact = await _emailService.EmailAlreadyExists(contactAlreadyExists);

            if (errorDetected.Message is not null)
                return new SuccessModel { Success = false, Message = errorDetected.Message };
            if (errorDetectedContact.Message is not null)
                return new SuccessModel { Success = false, Message = errorDetectedContact.Message };

            User? createdUser = await _userRepository.AddAsync(new UserEntity().TransformToUserEntity(data.ToBusiness()));

            if (createdUser != null)
            {
                string body = await _emailService.BildEmailBody(EEmailType.Welcome);
                Email emailBody = new(emailAddress: data.Contacts.Email, header: EEmailType.Welcome.GetDescription(), emailBody: body, emailType: EEmailType.Welcome);

                newContact = new(email: data.Contacts.Email, cellphone: data.Contacts.Cellphone, flagWhatsApp: data.Contacts.FlagWhatsApp, userId: createdUser.UserId);
                newContact = await _contactRepository.AddAsync(newContact.TransformToContactEntity(newContact));

                await _emailService.SendAsync(emailBody);
            }

            logBody = await _logRepository.AddLog(new LogEntity().CreateAccessLogAndTransform(createdUser.Nickname, createdUser.UserId));

            createdUser.SetPatternPasswordResult();
            createdUser.SetContactResult(newContact);

            successResult = new(
                success: true,
                message: Messages.UserCreatedSuccessfully,
                logId: logBody.LogId,
                data: new List<object> { createdUser }
            );

            return successResult;
        }
        private static Success NickNameAlreadyExists(User? existing)
        {
            Success successResult = new();

            if (existing is not null)
            {
                successResult = new()
                {
                    SuccessFlag = false,
                    Message = Messages.NicknameAlreadyRegistered
                };
            }

            return successResult;
        }




    }
}