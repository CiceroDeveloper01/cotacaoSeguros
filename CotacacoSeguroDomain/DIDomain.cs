using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace CotacacoSeguroDomain;

public static class DIDomain
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<MarcasEntity>();
        return services;
    }
}