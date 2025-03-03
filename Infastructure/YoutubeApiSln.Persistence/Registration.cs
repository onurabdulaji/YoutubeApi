using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApiSln.Application.Interfaces.Repositories;
using YoutubeApiSln.Application.Interfaces.UnitOfWorks;
using YoutubeApiSln.Domain.Entitites;
using YoutubeApiSln.Persistence.Context;
using YoutubeApiSln.Persistence.Repositories;
using YoutubeApiSln.Persistence.UnitOfWorks;

namespace YoutubeApiSln.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection"));

        });
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 2;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = false;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}
