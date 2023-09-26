using Microsoft.AspNetCore.Mvc;

namespace Hackadme.Csd.Authentication.Users
{
    public class UserController : Controller
    {
        [HttpPost("/api/users")]
        public async Task<ActionResult<CreateUserResponse>> CreateAsync([FromBody] CreateUserRequest request)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Email = request.email;
            user.PasswordHash = UserRepository.CreatePasswordHash(user.Id, request.password);
            UserRepository.Add(user);
            return new CreateUserResponse(user.Id);
        }

        [HttpGet("/api/users/{id}")]
        public async Task<ActionResult<GetUserResponse>> GetByIdAsync(Guid id)
        {
            var user = UserRepository.GetById(id);
            if (user == null) return NotFound();

            return new GetUserResponse()
            {
                id = user.Id,
                email = user.Email,
            };
        }
    }
}
