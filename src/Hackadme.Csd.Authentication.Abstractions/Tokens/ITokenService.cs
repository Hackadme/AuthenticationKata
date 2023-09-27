namespace Hackadme.Csd.Authentication.Tokens
{
    public interface ITokenService
    {
        IToken? Login(string email, string password);
    }
}
