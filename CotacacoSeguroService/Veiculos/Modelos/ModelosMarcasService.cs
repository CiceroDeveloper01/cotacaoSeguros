using CotacacoSeguroDomain.Enums;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Entidades;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Services;
using CotacacoSeguroShared.Commands.Domain;
using CotacacoSeguroShared.Commands.Interfaces;
using CotacacoSeguroShared.PaginacaoBuscao;
using Microsoft.Extensions.Logging;

namespace CotacacoSeguroService.Veiculos.Modelos;

public class ModelosMarcasService : IModelosMarcasService
{
    private readonly ILogger<ModelosMarcasService> _logger;
    private readonly IModelosMarcasRepository _modelosRepository;
    private readonly ModelosEntity _modelosEntity;
    
    public ModelosMarcasService(ILogger<ModelosMarcasService> logger,
                          IModelosMarcasRepository modelosRepository,
                          ModelosEntity modelosEntity)
    {
        _logger = logger;
        _modelosRepository = modelosRepository;
        _modelosEntity = modelosEntity;
    }

    public async Task<ICommandResult> Adicionar(ModelosRequest request)
    {
        if (await _modelosEntity.ValidateAdiconar(request))
        {
            var IdModeloInserida = await _modelosRepository.Adicionar(_modelosEntity.Modelos);

            return new CreatingResultObject((int)ERetornosApi.Created,
                                            true,
                                            "Modelo, Inserida Com Sucesso",
                                            _modelosEntity.EntityToDto(IdModeloInserida));
        }
        return new CreatingResultObject((int)ERetornosApi.Ok, false, "Marca, Não Inserida Com Sucesso", _modelosEntity.ValidFields);
    }

    public async Task<ICommandResult> Atualizar(ModelosRequest request)
    {
        if (await _modelosEntity.ValidateAtualizar(request))
        {
            await _modelosRepository.Atualizar(_modelosEntity.Modelos);

            return new CreatingResultObject((int)ERetornosApi.Ok,
                                            true,
                                            "Modelo, Atualizada Com Sucesso",
                                            _modelosEntity.EntityToDto(_modelosEntity.ID));
        }
        return new CreatingResultObject((int)ERetornosApi.Ok, false, "Modelo, Não Atualizada Com Sucesso", _modelosEntity.ValidFields);
    }

    public async Task<ICommandResult> BuscarPorFiltro(ModelosFilters filter)
    {
        int totalItens = await _modelosRepository.TotalDeRegistrosCadastrados(filter);

        if (totalItens > 0)
        {
            var objetoPaginacao = ObterPaginacaoInicialFinalBusca.ObterPaginacaoBusca(totalItens, filter.Pagina, filter.QuantidadePagina);
            var resultado = _modelosRepository.BuscarPorFiltro(filter, objetoPaginacao);
            return new CreatingResultObject((int)ERetornosApi.Ok, true, "Modelos, Localizados", resultado);
        }
        return new CreatingResultObject((int)ERetornosApi.Ok, true, "Modelos Não Localizados");
    }

    public async Task<ICommandResult> BuscarPorId(int ID)
    {
        var modelo = await _modelosRepository.BuscarPorId(ID);

        if (modelo == null)
            return new CreatingResultObject((int)ERetornosApi.Ok, false, "Modelo, Não Localizado");
        else
            return new CreatingResultObject((int)ERetornosApi.Ok, true, "Modelo, Localizado", modelo);
    }

    public async Task<ICommandResult> Deletar(int ID)
    {
        if (await _modelosRepository.PersistirModeloExclusao(ID))
        {
            await _modelosRepository.Deletar(ID);
            return new CreatingResultObject((int)ERetornosApi.Ok, true, "Modelo, Excluída Com Sucesso");
        }
        else
            return new CreatingResultObject((int)ERetornosApi.Ok, false, "Modelo, Não Pode ser Excluída Por Ter Versões de Veículos ou Cotações Realizadas");
    }
}

