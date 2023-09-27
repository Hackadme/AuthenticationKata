using Microsoft.AspNetCore.Mvc;

namespace Hackadme.Csd.Authentication.Users
{
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("/api/users")]
        public async Task<ActionResult<CreateUserResponse>> CreateAsync([FromBody] CreateUserRequest request)
        {
            if (request == null 
                || string.IsNullOrEmpty(request.email) 
                || string.IsNullOrEmpty(request.password))
            {
                return BadRequest("Body is invalid or missing!");
            }

            var user = service.Create(request.email, request.password);

            return new CreateUserResponse(user);
        }

        [HttpGet("/api/users/{id}")]
        public async Task<ActionResult<GetUserResponse>> GetByIdAsync(Guid id)
        {
            var user = service.GetById(id);
            if (user == null) return NotFound();

            return new GetUserResponse(user);
        }
    }
}
