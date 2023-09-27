using Hackadme.Csd.Authentication.Users;
using Microsoft.AspNetCore.Mvc;

namespace Hackadme.Csd.Authentication.Tokens
{
    public class TokenController : Controller
    {
        private readonly ITokenService service;

        public TokenController(ITokenService service)
        {
            this.service = service;
        }

        [HttpPost("api/tokens/login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
        {
            if (request == null 
                || string.IsNullOrEmpty(request.email) 
                || string.IsNullOrEmpty(request.password))
                return BadRequest("Body is invalid or missing!");

            var token = service.Login(request.email, request.password);
            if (token == null) return Unauthorized();

            return new LoginResponse(token);
        }
    }
}
