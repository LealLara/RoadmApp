using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoadmApp.Domain.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoadmApp.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {

        private readonly string _key;

        public TokenRepository(IConfiguration config)
        {
            _key = config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key");
        }

        public Task<string> GenerateToken(string hash)
        {
            Claim[] claims = new[] { new Claim(ClaimTypes.NameIdentifier, hash) };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_key));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            string tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(tokenResult);
        }
    }
}
