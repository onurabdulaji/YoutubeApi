using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApiSln.Application.Interfaces.Repositories;
using YoutubeApiSln.Persistence.Context;
using YoutubeApiSln.Persistence.Repositories;

namespace YoutubeApiSln.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection"));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        });

    }
}
