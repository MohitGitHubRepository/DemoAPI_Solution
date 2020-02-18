using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;

namespace Authentication.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GetJWTToken(string userId)
        {
            // Specify the claims for user credential names
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Define security key and encode
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DemoApi_Security_Key"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define JWT token with essential information and set expiry time
            var token = new JwtSecurityToken(
                issuer: "AuthenticationService",
                audience: "AuthService",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: cred
                );

            // Create the response object
            var response = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return JsonConvert.SerializeObject(response);
        }
    }
}
