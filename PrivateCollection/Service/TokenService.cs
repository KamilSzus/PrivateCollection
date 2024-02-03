using Microsoft.IdentityModel.Tokens;
using PrivateCollection.Controllers;
using PrivateCollection.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PrivateCollection.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration Config;
        private readonly SymmetricSecurityKey SymmetricSecurityKey;

        public TokenService(IConfiguration config)
        {
            this.Config = config;
            this.SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Config["JWT:SigningKey"]));
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var signingCredentials = new SigningCredentials(this.SymmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = signingCredentials,
                Issuer = this.Config["JWT:Issuer"],
                Audience = this.Config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
