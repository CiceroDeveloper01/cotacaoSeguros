using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace CotacacoSeguroDomain;

public static class DIDomain
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<MarcasEntity>();
        services.AddScoped<ModelosEntity>();
        return services;
    }
}