using Api.Infrastructure;
using Api.Mapping;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMapping();
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }
}
