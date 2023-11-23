using CotacacoSeguroDomain.ContratosGenericos.AbstractEntity;
using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;
using CotacacoSeguroShared.Attributes;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

[DataTableAttribute("veiculos", "TB_MODELOSMARCAS")]
public class ModelosEntity : EntityPersistence
{
    public int ID { get; private set; }
    public string NomeModelo { get; private set; }
    public int AnoInicialFabricacao { get; private set; }
    public int? AnoFinalFabricacao { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public MarcasEntity Marca { get; private set; }

    public override async Task<bool> ValidateAdiconar(MarcasRequest entity)
    {
        throw new NotImplementedException();
    }

    public override async Task<bool> ValidateAtualizar(MarcasRequest entity)
    {
        throw new NotImplementedException();
    }
}
