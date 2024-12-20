using Application.Interfaces.Authentication;
using Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            var singingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: singingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }

        public Guid GetIdFromToken(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            var jwtToken = jwtHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims.FirstOrDefault(u => u.Type == "userId");

            if (claims == null)
                return Guid.Empty;

            var result = Guid.TryParse(claims.Value, out Guid userId);

            if (!result)
                return Guid.Empty;

            return userId;
        }
    }
}
