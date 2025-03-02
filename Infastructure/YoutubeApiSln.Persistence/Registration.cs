using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Persistence.Context;

namespace YoutubeApiSln.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection"));
        });
    }
}
