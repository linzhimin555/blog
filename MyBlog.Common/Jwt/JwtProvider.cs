using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBlog.Common.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSetting _jwtSetting;

        private readonly IHttpContextAccessor _accessor;

        public JwtProvider(IOptions<JwtSetting> options, IHttpContextAccessor accessor) 
        {
            _jwtSetting = options.Value;

            _accessor = accessor;
        }
        public string CreateJwtToken(TokenModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSetting.IssuerSigningKey);
            ClaimsIdentity identity = new ClaimsIdentity("Bearer");
            identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Uid));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(_jwtSetting.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        public string GetUserId()
        {
            var user = _accessor.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null)
                    return claim.Value;
            }
            return string.Empty;
        }
    }

    public class TokenModel
    {
        public string Uid { get; set; }

        public string UserName { get; set; }
    }
}
