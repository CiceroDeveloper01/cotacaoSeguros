using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.ContratosGenericos.AbstractEntity;

public abstract class EntityPersistence<EntityIn, EntityOut>
{
    public int ID { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public abstract Task<bool> ValidateAdiconar(EntityIn entity);
    public abstract Task<bool> ValidateAtualizar(EntityIn entity);
    public abstract Task<EntityOut> VerificarExistenciaRegistro(int ID);
    public new Dictionary<string, string> ValidFields { get; private set ; }
}