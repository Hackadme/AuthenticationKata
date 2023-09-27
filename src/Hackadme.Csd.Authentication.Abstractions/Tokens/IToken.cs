using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackadme.Csd.Authentication.Tokens
{
    public interface IToken
    {
        Guid AccessToken { get; }
        Guid UserId { get; }
    }
}
