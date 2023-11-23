using CotacacoSeguroDomain.ContratosGenericos.AbstractEntity;
using CotacacoSeguroDomain.ContratosGenericos.Interfaces.Services;
using CotacacoSeguroDomain.Veiculos.Marcas.Interfaces.Repository;
using CotacacoSeguroShared.Attributes;

namespace CotacacoSeguroDomain.Veiculos.Marcas.Entidades;


[DataTableAttribute("veiculos", "TB_MARCAS")]
public class MarcasEntity : EntityPersistence
{
    private readonly IMarcasRepository _marcasRepository;
    public int ID { get; private set; }
    public string NomeMarca { get; private set; }
    public string TipoProducao { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public MarcasEntity Marcas { get; private set; }
    

    public MarcasEntity(IMarcasRepository marcasRepository)
    {
        _marcasRepository = marcasRepository;
    }
       
    private async Task<bool> Validar()
    {
        if (string.IsNullOrEmpty(NomeMarca))
            ValidFields.Add("NomeMarca", "Por Favor, Informar o Nome da Marca");

        if (string.IsNullOrEmpty(TipoProducao))
            ValidFields.Add("TipoProducao", "Por Favor, Informar o Tipo de Produção");

        if (ValidFields.Count == 0)
            return true;

        return false;
    }

    public override async Task<bool> ValidateAdiconar(MarcasRequest entity)
    {
        NomeMarca = entity.NomeMarca;
        TipoProducao = entity.TipoProducao.ToString("G");
        DataAlteracao = DateTime.Now;
        DataCriacao = DateTime.Now;

        if (await Validar())
            return true;

        return false;
    }

    public override async Task<bool> ValidateAtualizar(MarcasRequest entity)
    {
        ID = entity.ID;
        NomeMarca = entity.NomeMarca;
        TipoProducao = entity.TipoProducao.ToString("G");
        DataAlteracao = DateTime.Now;

        if (await Validar())
        {
            var id = await _marcasRepository.VerificarExistenciaRegistro(ID);

            if (id != 0)
                return true;

        }

        return false;
    }
}