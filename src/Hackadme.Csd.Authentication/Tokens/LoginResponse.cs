namespace Hackadme.Csd.Authentication.Tokens
{
    public class LoginResponse
    {
        private readonly IToken token;

        public LoginResponse(IToken token)
        {
            this.token = token;
        }

        public string accessToken => token.AccessToken.ToString();
    }
}