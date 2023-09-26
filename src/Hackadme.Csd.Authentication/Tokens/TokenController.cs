using Hackadme.Csd.Authentication.Users;
using Microsoft.AspNetCore.Mvc;

namespace Hackadme.Csd.Authentication.Tokens
{
    public class TokenController : Controller
    {
        private readonly List<Token> _tokens = new List<Token>();

        [HttpPost("api/tokens/login")]
        public async Task<ActionResult<Token>> LoginAsync([FromBody] LoginRequest request)
        {
            if (request == null 
                || string.IsNullOrEmpty(request.email) 
                || string.IsNullOrEmpty(request.password))
                return BadRequest("Body is invalid or missing!");

            var user = UserRepository.GetByEmail(request.email);
            if (user == null) return Unauthorized();

            if (user.PasswordHash != UserRepository.CreatePasswordHash(user.Id, request.password)) return Unauthorized();

            var token = new Token(user);
            _tokens.Add(token);

            return token;
        }
    }
}
