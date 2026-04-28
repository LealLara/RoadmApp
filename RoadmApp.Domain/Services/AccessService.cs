using FluentValidation;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices;
using RoadmApp.Domain.Models;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using RoadmApp.Domain.Utils.Templates;
using RoadmApp.Domain.Validations;

namespace RoadmApp.Domain.Services
{
    public class AccessService : IAccessService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;

        public AccessService(IEmailService emailService, IUserRepository userRepository, ILogRepository logRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _logRepository = logRepository;
        }

        public async Task<User> CreateAccess(Register data)
        {
            Email emailBody = new();
            CreateAccessValidation valid = new();
            User newUser = new();
            User createdUser = new();
            valid.ValidateAndThrow(data);

            var existing = await _userRepository.GetByNicknameAsync(data.Access.Nickname);
            if (existing != null)
                throw new Exception("Email já existe");

            string head = EEmailType.Welcome.GetDescription();
            string text = BildBody_CreateAccess();

            emailBody = new(emailAddress: data.Contacts.FirstOrDefault(c => c.Email != null)?.Email, header: head, emailBody: text, emailType: EEmailType.Welcome);
             
            createdUser = await _userRepository.AddAsync(newUser.Transform(data));

            if (createdUser != null)
            {
                await _emailService.SendAsync(emailBody);
            }

            Log logBody = new(logMessage: $"Novo usuário criado: {createdUser.Nickname}",
                               logTypeId: (int)ELogType.Creation,
                               userId: createdUser.UserId
            );

            await _logRepository.AddLog(logBody);

            return createdUser;
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