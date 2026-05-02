using FluentValidation;
using RoadmApp.Application.IServices;
using RoadmApp.Application.Responses;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using RoadmApp.Domain.Utils.Templates;
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

            User? existing = await _userRepository.GetByNicknameAsync(data.Access.Nickname);

            Success errorDetected = NickNameAlreadyExists(existing);

            Contact? existingContact = await _contactRepository.GetByEmailAsync(data.Contacts.Email);

            Success errorDetectedContact = EmailAlreadyExists(existingContact);

            if (errorDetected.Message is not null)
                return new SuccessModel { Success = false, Message = errorDetected.Message };
            if (errorDetectedContact.Message is not null)
                return new SuccessModel { Success = false, Message = errorDetectedContact.Message };

            string head = EEmailType.Welcome.GetDescription();
            string text = BildBody_CreateAccess();

            User? createdUser = await _userRepository.AddAsync(new UserEntity().TransformToUserEntity(data.ToBusiness()));

            if (createdUser != null)
            { 
                newContact = new(email: data.Contacts.Email, cellphone: data.Contacts.Cellphone, flagWhatsApp: data.Contacts.FlagWhatsApp, userId: createdUser.UserId);
                newContact = await _contactRepository.AddAsync(newContact.TransformToContactEntity(newContact));

                await SendEmail(data, head, text);
            }

            logBody = await _logRepository.AddLog(new LogEntity().CreateAccessLogAndTransform(createdUser.Nickname, createdUser.UserId));

            createdUser.SetPatternPasswordResult();
            createdUser.SetContactResult(newContact);

            successResult = new(
                success: true,
                message: "Usuário criado com sucesso",
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
                    Message = "Nickname já cadastrado."
                };
            }

            return successResult;
        }
        private static Success EmailAlreadyExists(Contact? existing)
        {
            Success successResult = new();

            if (existing is not null)
            {
                successResult = new()
                {
                    SuccessFlag = false,
                    Message = "Email já cadastrado."
                };
            }

            return successResult;
        }
        private static string BildBody_CreateAccess()
        {
            string data = EmailTemplates.GetTemplate(EEmailType.Welcome);

            return data;
        }
        private async Task SendEmail(RegisterModel data, string head, string text)
        {
            Email emailBody = new(emailAddress: data.Contacts.Email, header: head, emailBody: text, emailType: EEmailType.Welcome);

            await _emailService.SendAsync(emailBody);
        }

        private static string BildBody_FirstRegister()
        {
            string data = EmailTemplates.GetTemplate(EEmailType.FirstRegister);

            return data;
        }
    }
}