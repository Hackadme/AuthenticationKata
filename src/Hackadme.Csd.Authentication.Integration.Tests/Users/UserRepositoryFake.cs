using Hackadme.Csd.Authentication.Users;

namespace Hackadme.Csd.Authentication.Integration.Tests.Users
{
    internal class UserRepositoryFake : IUserRepository
    {
        public UserRepositoryFake()
        {
        }

        public UserDto? GetByEmail(string? email)
        {
            throw new NotImplementedException();
        }

        public UserDto? GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Save(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}