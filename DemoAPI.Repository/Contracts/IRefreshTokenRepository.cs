namespace Survey.DataAccess.SQL.Contracts
{
    public interface IRefreshTokenRepository
    {
        void deleteRefreshToken(string token, string email);
        void saveRefreshToken(string token, string email);
        string getRefreshToken( string email);
    }
}