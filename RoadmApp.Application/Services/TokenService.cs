using RoadmApp.Application.IServices;
using RoadmApp.Domain.IRepositories;

namespace RoadmApp.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public Task<string> GenerateToken(string hash)
        {
            return _tokenRepository.GenerateToken(hash);
        }
    }
}