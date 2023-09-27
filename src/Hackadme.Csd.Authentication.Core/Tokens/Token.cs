using Hackadme.Csd.Authentication.Users;

namespace Hackadme.Csd.Authentication.Tokens
{
    internal class Token : IToken
    {
        private readonly TokenDto dto;

        internal Token(TokenDto dto)
        {
            this.dto = dto;
        }

        public Guid AccessToken => dto.AccessToken ?? throw new ArgumentNullException("AccessToken");
        public Guid UserId => dto.UserId ?? throw new ArgumentNullException("UserId");
    }
}