using RoadmApp.Application.IServices;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Contants;
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
            User? user = await _userRepository.GetByNicknameAsync(nick);
            if (user == null)
            {
                return new Success(
                successFlag: false,
                message: Messages.UserNotFound,
                logId: 0,
                data: new List<object>()
            );
            }
            string hash = await _userRepository.GetHash(nick);

            if (hash == null || !BCrypt.Net.BCrypt.Verify(password, hash))
                throw new Exception(Messages.InvalidCredentials);

            string token = await _tokenService.GenerateToken(hash);

            if (string.IsNullOrEmpty(token))
                throw new Exception(Messages.TokenGenerationError);

            LogEntity logBody = new(logMessage: $"{Messages.UserLoggedIn} {nick}",
                         logTypeId: (int)ELogType.Login,
                         userId: user.UserId
            );

            Log? log = await _logRepository.AddLog(logBody);

            return new Success(true, $"{Messages.UserLoggedIn} {nick}", log.LogId, new List<object> { token });
        }
    }
}