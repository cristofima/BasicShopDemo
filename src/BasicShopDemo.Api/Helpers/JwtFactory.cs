using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicShopDemo.Api.Helpers
{
    public class JwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(IOptions<JwtOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
        }

        public string GenerateEncodedToken(string userName, string email, IList<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(this._jwtOptions.Issuer, this._jwtOptions.Issuer,
              claims.ToArray(),
              expires: DateUtils.GetCurrentDate().AddMinutes(this._jwtOptions.ValidForMinutes),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime GetExpireDate(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            if (!jwtSecurityTokenHandler.CanReadToken(token))
            {
                return DateUtils.GetCurrentDate();
            }

            var jwtSecurityToken = jwtSecurityTokenHandler.ReadToken(token);
            return jwtSecurityToken.ValidTo;
        }
    }
}
