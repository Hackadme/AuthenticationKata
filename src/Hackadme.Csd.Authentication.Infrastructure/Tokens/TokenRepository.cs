using Hackadme.Csd.Authentication.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackadme.Csd.Authentication.Infrastructure.Tokens
{
    internal class TokenRepository : ITokenRepository
    {
        private readonly List<TokenDto> _tokens = new List<TokenDto>();

        public TokenDto? GetById(Guid id)
        {
            return _tokens.FirstOrDefault(t => t.AccessToken == id);
        }

        public void Save(TokenDto token)
        {
            _tokens.Add(token);
        }
    }
}
