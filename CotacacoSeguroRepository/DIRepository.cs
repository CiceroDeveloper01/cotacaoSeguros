using CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Repository;
using CotacacoSeguroDomain.Seguros.Cotacoes.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.VersoesModelos.Interfaces.Repository;
using CotacacoSeguroRepository.Seguros.Clientes;
using CotacacoSeguroRepository.Seguros.Cotacoes;
using CotacacoSeguroRepository.Veiculos.Marcas;
using CotacacoSeguroRepository.Veiculos.Modelos;
using CotacacoSeguroRepository.Veiculos.VersoesModelos;
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
        services.AddScoped<IVersoesModelosRepository, VersoesModelosRepository>();
        services.AddScoped<IClientesRepository, ClientesRepository>();
        services.AddScoped<ICotacoesRepository, CotacoesRepository>();
        return services;
    }
}