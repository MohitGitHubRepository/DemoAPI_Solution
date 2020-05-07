using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Survey.Core.Model;
using Survey.DataAccess.SQL.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Survey.Domain.AuthServices.RefreshToken
{

    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        IRefreshTokenRepository repository;
        private IConfiguration configuration;

        public RefreshTokenGenerator(IRefreshTokenRepository Repository ,IConfiguration _configuration)
        {
            this.repository = Repository;
            this.configuration = _configuration;
        }
        public void DeleteRefreshToken(string username, string refreshToken)
        {
          repository.deleteRefreshToken(refreshToken,username);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GetRefreshToken(string username)
        {
            return repository.getRefreshToken(username);
        }

        public void SaveRefreshToken(string username, string newRefreshToken)
        {
            repository.saveRefreshToken(newRefreshToken, username);
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var audienceconfig = configuration.GetSection("Audience");
            var key = audienceconfig["key"];
            var keyByteArray = Encoding.ASCII.GetBytes(key);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = audienceconfig["Iss"],

                ValidateAudience = true,
                ValidAudience = audienceconfig["Aud"],

                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
