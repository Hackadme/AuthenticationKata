using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackadme.Csd.Authentication.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
