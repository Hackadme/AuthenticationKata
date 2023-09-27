namespace Hackadme.Csd.Authentication.Users
{
    public interface IUserRepository 
    {
        UserDto? GetById(Guid? id);
        UserDto? GetByEmail(string? email);
        void Save(UserDto user);
    }
}
