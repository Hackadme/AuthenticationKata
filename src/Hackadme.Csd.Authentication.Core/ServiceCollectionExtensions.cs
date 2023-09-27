using Hackadme.Csd.Authentication.Tokens;
using Hackadme.Csd.Authentication.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Hackadme.Csd.Authentication.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}
