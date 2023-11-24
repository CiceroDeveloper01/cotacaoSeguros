namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

public static class ModelosTranslator
{
    public static ModelosResult EntityToDto(this ModelosEntity modelosEntity, int id) => new ModelosResult
    {
        ID = id,
        NomeModelo = modelosEntity.NomeModelo,
        AnoInicialFabricacao = modelosEntity.AnoInicialFabricacao,
        AnoFinalFabricacao = modelosEntity.AnoFinalFabricacao,
        DataAlteracao = modelosEntity.DataAlteracao,
        DataCriacao = modelosEntity.DataCriacao
    };
}
