using CotacacoSeguroDomain.ContratosGenericos.AbstractEntity;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroDomain.Veiculos.Modelos.Interfaces.Repository;
using CotacacoSeguroShared.Attributes;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

[DataTableAttribute("veiculos", "TB_MODELOSMARCAS")]
public class ModelosEntity : EntityPersistence<ModelosRequest, ModelosEntity>
{
    private readonly IModelosMarcasRepository _modelosRepository;
    private readonly MarcasEntity _marcasEntity;
    public int ID { get; private set; }
    public string NomeModelo { get; private set; }
    public int AnoInicialFabricacao { get; private set; }
    public int? AnoFinalFabricacao { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public MarcasEntity Marca { get; private set; }
    public ModelosEntity Modelos { get; private set; }

    public ModelosEntity(IModelosMarcasRepository modelosRepository, MarcasEntity marcasEntity)
    {
        _modelosRepository = modelosRepository;
        _marcasEntity = marcasEntity;
    }

    private async Task<bool> Validar(MarcasRequest marcasRequest)
    {
        if (string.IsNullOrEmpty(NomeModelo))
            ValidFields.Add("NomeModelo", "Por Favor, Informar o Nome do Modelo do Veículo");

        if (AnoInicialFabricacao < 0  
         || AnoInicialFabricacao == 0 
         || AnoInicialFabricacao < 1900 
         || AnoInicialFabricacao > DateTime.Now.Year)
            ValidFields.Add("Ano Inicial Fabricação", "Por Favor, Informe o Ano Inicial Fabricação");

        if (AnoFinalFabricacao < 0 || AnoFinalFabricacao > AnoInicialFabricacao)
            ValidFields.Add("Ano Final Fabricação", "Por Favor, Informe o Ano Final de Fabricação Menor ou Igual");

        if (marcasRequest.ID <= 0)
            ValidFields.Add("Marca", "Por Favor, Informe a Marca que o Modelo do Veículo Pertence");


        if (ValidFields.Count == 0)
        {
            Marca = await _marcasEntity.VerificarExistenciaRegistro(marcasRequest.ID);
            if (Marca != null)
                return true;
            else
            {
                ValidFields.Add("Marca", "Por Favor, a Marca Informada Para Cadastrar o Novo Modelo do Veículo Não Foi Localizada.");
            }
        }
        return false;
    }

    public override async Task<bool> ValidateAdiconar(ModelosRequest entity)
    {
        NomeModelo = entity.NomeModelo;
        AnoInicialFabricacao = entity.AnoInicialFabricacao;
        AnoFinalFabricacao = entity.AnoFinalFabricacao;
        DataAlteracao = DateTime.Now;
        DataCriacao = DateTime.Now;

        if (await Validar(entity.Marcas))
            return true;

        return false;
    }

    public override async Task<bool> ValidateAtualizar(ModelosRequest entity)
    {
        ID = entity.ID;
        NomeModelo = entity.NomeModelo;
        AnoInicialFabricacao = entity.AnoInicialFabricacao;
        AnoFinalFabricacao = entity.AnoFinalFabricacao;
        DataAlteracao = DateTime.Now;

        if (await Validar(entity.Marcas))
            return true;

        return false;
    }

    public override async Task<ModelosEntity> VerificarExistenciaRegistro(int ID)
    {
        var modelo = await _modelosRepository.BuscarPorId(ID);

        if (modelo != null)
        {
            ID = modelo.ID;
            NomeModelo = modelo.NomeModelo;
            DataAlteracao = modelo.DataAlteracao;
            DataCriacao = modelo.DataCriacao;
            return Modelos;
        }

        return null;
    }
}