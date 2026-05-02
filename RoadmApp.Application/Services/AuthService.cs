using RoadmApp.Application.IServices;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly ITokenService _tokenService;
        public AuthService(IUserRepository userRepository, ITokenService tokenService, ILogRepository logRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logRepository = logRepository;
        }
        public async Task<Success> Login(string nick, string password)
        {
            var user = await _userRepository.GetByNicknameAsync(nick);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new Exception("Credenciais inválidas");

            string token = await _tokenService.GenerateToken(user.UserId);

            if (string.IsNullOrEmpty(token))
                throw new Exception("Erro ao gerar token");

            LogEntity logBody = new(logMessage: $"Usuário logou no sistema: {user.Nickname}",
                         logTypeId: (int)ELogType.Login,
                         userId: user.UserId
            );

            Log? log = await _logRepository.AddLog(logBody);

            return new Success(true, "Login efetuado com sucesso", log.LogId, new List<object> { token });
        }
    }
}