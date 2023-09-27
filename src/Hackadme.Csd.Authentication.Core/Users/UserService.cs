using System.Security.Cryptography;
using System.Text;

namespace Hackadme.Csd.Authentication.Users
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
            var id = Guid.NewGuid();
            var password = "test123$";

            var user = new UserDto
            {
                Id = id,
                Email = "test@hackadme.test",
                PasswordHash = CreatePasswordHash(id, password)
            };
            repository.Save(user);
        }

        public IUser? GetById(Guid id)
        {
            var dto = repository.GetById(id);
            if (dto == null) return null;
            return new User(dto);
        }

        public IUser? GetByEmail(string email)
        {
            var dto = repository.GetByEmail(email);
            if (dto == null) return null;
            return new User(dto);
        }


        public IUser Create(string email, string password)
        {
            var dto = new UserDto();
            dto.Id = Guid.NewGuid();
            dto.Email = email;
            dto.PasswordHash = CreatePasswordHash(dto.Id, password);
            repository.Save(dto);
            return new User(dto);
        }

        internal static string CreatePasswordHash(Guid id, string? password)
        {
            var sha = SHA256.Create();
            var passwordHash = $"{id}{password}";
            var passwordHashBytes = Encoding.UTF8.GetBytes(passwordHash);
            var passwordHashBytesHashed = sha.ComputeHash(passwordHashBytes);
            return Convert.ToBase64String(passwordHashBytesHashed);
        }
    }
}