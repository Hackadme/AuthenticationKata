namespace Hackadme.Csd.Authentication.Users
{
    public class CreateUserResponse
    {
        private readonly IUser user;

        public CreateUserResponse(IUser user)
        {
            this.user = user;
        }

        public Guid id => user.Id;
    }
}