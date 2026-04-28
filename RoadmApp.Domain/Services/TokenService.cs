using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices;

namespace RoadmApp.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public Task<string> GenerateToken(int userId)
        {
            return _tokenRepository.GenerateToken(userId);
        }
    }
}