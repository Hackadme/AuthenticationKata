namespace Hackadme.Csd.Authentication.Users
{
    public interface IUserService
    {
        IUser? GetById(Guid id);
        IUser? GetByEmail(string email);
        IUser Create(string email, string password);
    }
}
