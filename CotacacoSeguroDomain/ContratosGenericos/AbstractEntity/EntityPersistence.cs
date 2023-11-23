using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.ContratosGenericos.AbstractEntity;

public abstract class EntityPersistence
{
    public int ID { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public abstract Task<bool> ValidateAdiconar(MarcasRequest entity);
    public abstract Task<bool> ValidateAtualizar(MarcasRequest entity);
    public new Dictionary<string, string> ValidFields { get; private set ; }
}