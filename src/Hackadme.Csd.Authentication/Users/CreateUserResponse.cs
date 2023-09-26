namespace Hackadme.Csd.Authentication.Users
{
    public class CreateUserResponse
    {
        public CreateUserResponse(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; set; }
    }
}