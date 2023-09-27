using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackadme.Csd.Authentication.Users
{
    public interface IUser
    {
        Guid Id { get; }
        string Email { get; }

        bool ValidatePassword(string password);
    }
}
