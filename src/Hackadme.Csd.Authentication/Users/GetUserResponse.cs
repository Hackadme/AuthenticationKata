namespace Hackadme.Csd.Authentication.Users
{
    public class GetUserResponse
    {
        private readonly IUser user;

        public GetUserResponse(IUser user)
        {
            this.user = user;
        }

        public Guid id => user.Id;
        public string email => user.Email;
    }
}