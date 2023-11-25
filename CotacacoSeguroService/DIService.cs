using CotacacoSeguroDomain.Seguros.Clientes.Interfaces.Services;
using CotacacoSeguroDomain.Seguros.Cotacoes.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.VersoesModelos.Interfaces.Services;
using CotacacoSeguroService.Seguros.Clientes;
using CotacacoSeguroService.Veiculos.Marcas;
using CotacacoSeguroService.Veiculos.Modelos;
using CotacacoSeguroService.Veiculos.VersoesModelos;
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
        services.AddScoped<IModelosMarcasService, ModelosMarcasService>();
        services.AddScoped<IVersoesModelosService, VersoesModelosService>();
        services.AddScoped<IClientesService, ClientesService>();
        services.AddScoped<ICotacoesServices, CotacoesService>();
        return services;
    }
}