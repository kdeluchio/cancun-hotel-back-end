using CancunHotel.Domain.Enums;
using CancunHotel.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CancunHotel.Domain.Management
{
    public class ManagementToken : IManagementToken
    {
        public static string JwtSecretToken { get => "67AF10B1-7A74-40E1-A570-12E28C307C50"; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManagementToken(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Create(Guid userId, UserAccessLevel userAccess)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSecretToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserAccess", ((int)userAccess).ToString()),
                    new Claim("UserId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string ReadClaim(TokenClaims claimsName)
        {
            var claim = _httpContextAccessor.HttpContext
                                            .User
                                            .FindFirst(x => x.Type == claimsName.ToString());
            return claim?.Value;
        }
    
    }
}
