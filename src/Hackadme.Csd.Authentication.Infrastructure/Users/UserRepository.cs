using Hackadme.Csd.Authentication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hackadme.Csd.Authentication.Infrastructure.Users
{
    internal class UserRepository : IUserRepository
    {
        private static List<UserDto> _users = new List<UserDto>();

        public UserDto? GetById(Guid? id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public UserDto? GetByEmail(string? email)
        {
            return _users.FirstOrDefault(u => string.Equals(email, u.Email, StringComparison.CurrentCultureIgnoreCase));
        }

        public void Save(UserDto user)
        {
            _users.Add(user);
        }
    }
}
