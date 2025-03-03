using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApiSln.Infastructure.Tokens;

namespace YoutubeApiSln.Infastructure
{
    public static class Registration
    {
        public static void AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        }
    }
}

