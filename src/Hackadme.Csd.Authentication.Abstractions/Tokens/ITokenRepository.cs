namespace Hackadme.Csd.Authentication.Tokens
{
    public interface ITokenRepository
    {
        TokenDto? GetById(Guid id);
        void Save(TokenDto token);
    }
}
