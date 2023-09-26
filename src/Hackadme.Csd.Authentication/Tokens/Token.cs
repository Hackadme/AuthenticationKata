using Hackadme.Csd.Authentication.Users;

namespace Hackadme.Csd.Authentication.Tokens
{
    public class Token
    {
        public Token(User user)
        {
            AccessToken = Guid.NewGuid();
            UserId = user.Id;
        }

        public Guid AccessToken { get; set; }
        public Guid UserId { get; set; }
    }
}