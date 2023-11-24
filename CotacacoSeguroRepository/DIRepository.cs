using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;
using CotacacoSeguroRepository.Veiculos.Marcas;
using CotacacoSeguroRepository.Veiculos.Modelos;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace CotacacoSeguroRepository;

public static class DIRepository
{
    public static IServiceCollection AddRepository(this IServiceCollection services, string connection)
    {
        services.AddScoped(IServiceProvider => new SqlConnection(connection));
        services.AddScoped<IMarcasRepository, MarcasRepository>();
        services.AddScoped<IModelosMarcasRepository, ModelosMarcasRepository>();
        return services;
    }
}