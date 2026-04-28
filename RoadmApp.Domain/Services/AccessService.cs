using FluentValidation;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices;
using RoadmApp.Domain.Models;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
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
            string text = BildBody_FirstRegister();

            emailBody = new(emailAddress: data.Contacts.FirstOrDefault(c => c.Email != null)?.Email, header: head, emailBody: text, emailType: EEmailType.Welcome);
             
            newUser.Transform(data);

            createdUser = await _userRepository.AddAsync(newUser);

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


        private static string BildBody_FirstRegister()
        {
            string data =
            $"<!DOCTYPE html>\r\n\r\n<html lang=\"pt-BR\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n  <title>Bem-vinda ao RoadmAPP</title>\r\n</head>\r\n\r\n<body style=\"margin:0; padding:0; background-color:#f4f7f8; font-family:Arial, sans-serif;\">\r\n\r\n  <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"padding:20px;\">\r\n    <tr>\r\n      <td align=\"center\">\r\n\r\n```\r\n    <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" style=\"background:white; border-radius:12px; overflow:hidden; box-shadow:0 4px 12px rgba(0,0,0,0.1);\">\r\n\r\n      <!-- HEADER -->\r\n      <tr>\r\n        <td style=\"background:#2EC4B6; padding:30px; text-align:center; color:white;\">\r\n          <h1 style=\"margin:0;\">🐰 RoadMAPP</h1>\r\n          <p style=\"margin:5px 0 0;\">Organize sua vida com leveza</p>\r\n        </td>\r\n      </tr>\r\n\r\n      <!-- BODY -->\r\n      <tr>\r\n        <td style=\"padding:30px; color:#333;\">\r\n\r\n          <h2>Bem-vinda! 🎉</h2>\r\n\r\n          <p>\r\n            Sua conta foi criada com sucesso. Agora você pode organizar seus estudos, tarefas e metas com muito mais clareza.\r\n          </p>\r\n\r\n          <p>\r\n            Explore agendas, quadros estilo kanban, flashcards e muito mais!\r\n          </p>\r\n\r\n          <!-- CTA -->\r\n          <div style=\"text-align:center; margin:30px 0;\">\r\n            <a href=\"https://.com\"\r\n               style=\"background:#2EC4B6; color:white; padding:12px 25px; border-radius:8px; text-decoration:none; font-weight:bold;\">\r\n               Começar agora 🚀\r\n            </a>\r\n          </div>\r\n\r\n          <p style=\"font-size:14px; color:#777;\">\r\n            Se você não criou essa conta, pode ignorar este email.\r\n          </p>\r\n\r\n        </td>\r\n      </tr>\r\n\r\n      <!-- FOOTER -->\r\n      <tr>\r\n        <td style=\"background:#f1f1f1; padding:20px; text-align:center; font-size:12px; color:#999;\">\r\n          © 2026 RoadMAPP • Feito com 💙\r\n        </td>\r\n      </tr>\r\n\r\n    </table>\r\n\r\n  </td>\r\n</tr>\r\n```\r\n\r\n  </table>\r\n\r\n</body>\r\n</html>\r\n";
            return data;
        }
    }
}