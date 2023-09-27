namespace Hackadme.Csd.Authentication.Users
{
    internal class User : IUser
    {
        private readonly UserDto dto;

        public User(UserDto dto)
        {
            this.dto = dto;
        }

        public Guid Id => dto.Id;

        public string Email => dto.Email ?? string.Empty;

        public bool ValidatePassword(string password)
        {
            return UserService.CreatePasswordHash(Id, password) == dto.PasswordHash;
        }
    }
}