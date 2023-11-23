using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Services;
using Microsoft.Extensions.Logging;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using FluentValidator;
using CotacacoSeguroShared.Commands.Interfaces;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Commands.Domain;
using CotacacoSeguroDomain.Enums;

namespace CotacacoSeguroService.Veiculos.Marcas;

public class MarcasService : Notifiable, IMarcasService
{
    private readonly ILogger<MarcasService> _logger;
    private readonly IMarcasRepository _marcasRepository;
    private readonly MarcasEntity _marcasEntity;

    public MarcasService(ILogger<MarcasService> logger,
                         IMarcasRepository marcasRepository,
                         MarcasEntity marcasEntity)
    {
        _logger = logger;
        _marcasRepository = marcasRepository;
        _marcasEntity = marcasEntity;
    }

    public async Task<ICommandResult> Adicionar(MarcasRequest request)
    {
        
        if (await _marcasEntity.ValidateAdiconar(request)) 
        {
            var IdmarcaInserida = await _marcasRepository.Adicionar(_marcasEntity.Marcas);

            return new CreatingResultObject((int)ERetornosApi.Created,
                                            true,
                                            "Marca, Inserida Com Sucesso",
                                            _marcasEntity.EntityToDto(IdmarcaInserida));
        }
        return new CreatingResultObject((int)ERetornosApi.Ok, false, "Marca, Não Inserida Com Sucesso", _marcasEntity.ValidFields);
    }

    public async Task<ICommandResult> Atualizar(MarcasRequest request)
    {
        if (await _marcasEntity.ValidateAtualizar(request))
        {
            await _marcasRepository.Atualizar(_marcasEntity.Marcas);

            return new CreatingResultObject((int)ERetornosApi.Ok,
                                            true,
                                            "Marca, Atualizada Com Sucesso",
                                            _marcasEntity.EntityToDto(_marcasEntity.ID));
        }
        return new CreatingResultObject((int)ERetornosApi.Ok, false, "Marca, Não Atualizada Com Sucesso", _marcasEntity.ValidFields);
    }

    public Task<ICommandResult> BuscarPorFiltro(MarcasFilters filter)
    {
        return null;
    }

    public async Task<ICommandResult> BuscarPorId(int ID)
    {
        var marca = await _marcasRepository.BuscarPorId(ID);

        if (marca == null)
            return new CreatingResultObject((int)ERetornosApi.Ok, false, "Marca, Não Localizada");
        else
            return new CreatingResultObject((int)ERetornosApi.Ok, true, "Marca, Localizada", marca);

    }

    public async Task<ICommandResult> Deletar(int ID)
    {
        var validarParaExclusao = await _marcasRepository.PersistirMarcaExclusao(ID);

        if (validarParaExclusao == true)
        {
            await _marcasRepository.Deletar(ID);
            return new CreatingResultObject((int)ERetornosApi.Ok, true, "Marca, Excluída Com Sucesso");
        }
        else
            return new CreatingResultObject((int)ERetornosApi.Ok, false, "Marca, Não Pode ser Excluída Por Ter Modelos ou Versões de Veículos ou Cotações Realizadas");
    }
}