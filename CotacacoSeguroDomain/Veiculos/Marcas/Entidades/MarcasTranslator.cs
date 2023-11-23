namespace CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

public static class MarcasTranslator
{
    public static MarcasResult EntityToDto(this MarcasEntity marcasEntity, int id) => new MarcasResult 
    { 
        ID = id,
        NomeMarca = marcasEntity.NomeMarca,
        TipoProducao = marcasEntity.TipoProducao,
        DataAlteracao = marcasEntity.DataAlteracao,
        DataCriacao = marcasEntity.DataCriacao
    };
}