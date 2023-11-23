using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;
using CotacacoSeguroService.Veiculos.Marcas;
using Microsoft.Extensions.DependencyInjection;

namespace CotacacoSeguroService;

public static class DIService
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services = AddServices(services);
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMarcasService, MarcasService>();
        return services;
    }
}