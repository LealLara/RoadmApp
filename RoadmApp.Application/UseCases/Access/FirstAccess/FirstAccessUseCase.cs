using FluentValidation;
using RoadmApp.Application.AplicationModels;
using RoadmApp.Application.IServices;
using RoadmApp.Application.Responses;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using RoadmApp.Domain.Validations; 

namespace RoadmApp.Application.UseCases.Access.FirstAccess
{
    public class FirstAccessUseCase : IFirstAccessUseCase
    {
        private readonly IAccessRepository _accessRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IEmailService _emailService;
        public FirstAccessUseCase(IAccessRepository accessRepository, IUserRepository userRepository, ILogRepository logRepository, IEmailService emailService, IContactRepository contactRepository)
        {
            _accessRepository = accessRepository;
            _userRepository = userRepository;
            _logRepository = logRepository;
            _emailService = emailService;
            _contactRepository = contactRepository;
        }
        /// <summary>
        /// Método para realizar o primeiro acesso de um usuário, permitindo que ele defina uma nova senha.
        /// </summary>
        /// <param name="login">Modelo contendo as informações de login do usuário.</param>
        /// <returns>Retorna um objeto SuccessModel indicando o resultado da operação.</returns>
        /// <exception cref="Exception">Lança exceção em caso de erro durante o processo de primeiro acesso.</exception>
        public async Task<SuccessModel> FirstAccess(FirstAccessLoginModel login)
        {
            Log logBody = new();
            FirstAccessValidation valid = new();
            SuccessModel successResult = new();

            valid.ValidateAndThrow(login.ToBusiness());

            User? nick = await _userRepository.GetByNicknameAsync(login.Nickname);
            string hash = await _userRepository.GetHash(login.Nickname);

            if (nick == null)
            {
                return new SuccessModel(
                    success: false,
                    message: Messages.UserNotFound,
                    logId: 0,
                    data: new List<object>()
                    );
            }

            if (hash == null || !BCrypt.Net.BCrypt.Verify(PatternAccountConfig.PatternFirstRegister, hash))
                throw new Exception(Messages.InvalidPatternPassword);

            nick.SetPassword(login.NewPassword);


            var updatedPassword = await _userRepository.UpdatePasswordAsync(new UserEntity().TransformToUserEntity(nick));
            if(updatedPassword == null)
                throw new Exception(Messages.ErrorUpdatingPassword);

            AccessModel access = new(
                nickname: login.Nickname,
                password: login.NewPassword,
                isBlocked: false,
                userId: nick.UserId,
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.MinValue
            );

            var accessResult = await _accessRepository.AddAsync(access.TransformToAccessEntity());

            if (accessResult != null)
            {
                List<Contact> contact = await _contactRepository.GetContactbyUserId(nick.UserId);
                if (contact != null && contact.Count > 0)
                {
                    string head = EEmailType.FirstRegister.GetDescription();
                    string text = await _emailService.BildEmailBody(EEmailType.FirstRegister);
                    await _emailService.SendAsync(new Email(emailAddress: contact[0].Email, header: head, emailBody: text, emailType: EEmailType.FirstRegister));
                }
            }
            logBody = await _logRepository.AddLog(new LogEntity().FirstAccessLogAndTransform(nick.Nickname, nick.UserId));

            successResult = new(success: true, message: Messages.UserCreatedSuccessfully, logId: logBody.LogId, data: new List<object>() { accessResult });

            return successResult;
        }
    }
}