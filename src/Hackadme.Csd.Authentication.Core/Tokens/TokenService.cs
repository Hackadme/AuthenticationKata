using Hackadme.Csd.Authentication.Users;

namespace Hackadme.Csd.Authentication.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly IUserService userService;
        private readonly ITokenRepository repository;

        public TokenService(IUserService userService, ITokenRepository repository)
        {
            this.userService = userService;
            this.repository = repository;
        }

        public IToken? Login(string email, string password)
        {
            var user = userService.GetByEmail(email);
            if (user == null)
            {
                return null;
            }

            if (!user.ValidatePassword(password))
            {
                return null;
            }

            var dto = new TokenDto
            {
                AccessToken = Guid.NewGuid(),
                UserId = user.Id
            };
            repository.Save(dto);

            return new Token(dto);
        }
    }
}