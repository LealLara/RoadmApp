using FluentValidation;
using RoadmApp.Application.Models;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices; 
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
        private readonly ILogRepository _logRepository;

        public CreateAccessUseCase(IEmailService emailService, IUserRepository userRepository, ILogRepository logRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _logRepository = logRepository;
        }

        public async Task<Success> CreateAccess(Register data)
        {
            CreateAccessValidation valid = new();
            Log logBody = new();
            Success successResult = new();
            valid.ValidateAndThrow(data);

            User? existing = await _userRepository.GetByNicknameAsync(data.Access.Nickname);
            
            (bool flowControl, Success value) = NickNameAlreadyExists(ref successResult, existing);
            
            if (!flowControl)
                return value;
         
            string head = EEmailType.Welcome.GetDescription();
            string text = BildBody_CreateAccess();

            User? createdUser = await _userRepository.AddAsync(new UserEntity().TransformToUserEntity(data));

            if (createdUser != null)
            {
                Email emailBody = new(emailAddress: data.Contacts.FirstOrDefault(c => c.Email != null)?.Email, header: head, emailBody: text, emailType: EEmailType.Welcome);

                await _emailService.SendAsync(emailBody);
            }


            logBody = await _logRepository.AddLog(new LogEntity().CreateAccessLogAndTransform(createdUser.Nickname, createdUser.UserId));

            successResult = new(
                successFlag: true,
                message: "Usuário criado com sucesso",
                logId: logBody.LogId,
                data: new List<object> { createdUser }
            );

            return successResult;
        }

        private static (bool flowControl, Success value) NickNameAlreadyExists(ref Success successResult, User? existing)
        {
            if (existing is not null)
            {
                successResult = new()
                {
                    SuccessFlag = false,
                    Message = "Nickname já cadastrado"
                };
                return (flowControl: false, value: successResult);
            }

            return (flowControl: true, value: null);
        }

        private static string BildBody_CreateAccess()
        {
            string data = EmailTemplates.GetTemplate(EEmailType.Welcome);

            return data;
        }
        private static string BildBody_FirstRegister()
        {
            string data = EmailTemplates.GetTemplate(EEmailType.FirstRegister);

            return data;
        }
    }
}