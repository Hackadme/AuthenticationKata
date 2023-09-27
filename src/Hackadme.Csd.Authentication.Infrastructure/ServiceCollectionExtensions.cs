using Hackadme.Csd.Authentication.Infrastructure.Tokens;
using Hackadme.Csd.Authentication.Infrastructure.Users;
using Hackadme.Csd.Authentication.Tokens;
using Hackadme.Csd.Authentication.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Hackadme.Csd.Authentication.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITokenRepository, TokenRepository>();

            return services;
        }
    }
}
