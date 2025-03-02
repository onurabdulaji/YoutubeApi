using Microsoft.Extensions.DependencyInjection;
using YoutubeApiSln.Application.Interfaces.AutoMapper;

namespace YoutubeApiSln.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
}
