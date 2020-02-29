using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Surve.Domain.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Survey.Domain.AuthService
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
