using System.Security.Cryptography;
using System.Text;

namespace Hackadme.Csd.Authentication.Users
{
    public static class UserRepository
    {
        private static List<User> _users = new List<User>();

        static UserRepository()
        {
            var id = Guid.NewGuid();
            var password = "test123$";
            _users.Add(new User
            {
                Id = id,
                Email = "test@hackadme.test",
                PasswordHash = CreatePasswordHash(id, password)
            });
        }

        public static User? GetById(Guid? id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public static User? GetByEmail(string? email)
        {
            return _users.FirstOrDefault(u => string.Equals(email, u.Email, StringComparison.CurrentCultureIgnoreCase));
        }

        public static void Add(User user)
        {
            _users.Add(user);
        }


        public static string CreatePasswordHash(Guid id, string? password)
        {
            var sha = SHA256.Create();
            var passwordHash = $"{id}{password}";
            var passwordHashBytes = Encoding.UTF8.GetBytes(passwordHash);
            var passwordHashBytesHashed = sha.ComputeHash(passwordHashBytes);
            return Convert.ToBase64String(passwordHashBytesHashed);
        }
    }
}
