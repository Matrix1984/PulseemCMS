
using Microsoft.Extensions.Configuration;
using PulseemCMS.Application.Common.Interfaces;
using PulseemCMS.Domain.AppSettings;
using PulseemCMS.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    { 
        services.AddScoped<IClientDbService, ClientDbService>(); 

        return services;
    }
}
