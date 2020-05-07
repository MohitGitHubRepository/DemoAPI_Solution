using System.Security.Claims;

namespace Survey.Domain.AuthServices.RefreshToken
{
    public interface IRefreshTokenGenerator
    {
        string GenerateRefreshToken();
        string GetRefreshToken(string username);
       void DeleteRefreshToken(string username,string refreshToken);
       void SaveRefreshToken(string username,string newRefreshToken);
       ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}