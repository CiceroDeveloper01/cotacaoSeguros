using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroRepository.Veiculos.Marcas;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace CotacacoSeguroRepository;

public static class DIRepository
{
    public static IServiceCollection AddRepository(this IServiceCollection services, string connection)
    {
        services.AddScoped(IServiceProvider => new SqlConnection(connection));
        services.AddScoped<IMarcasRepository, MarcasRepository>();
        return services;
    }
}