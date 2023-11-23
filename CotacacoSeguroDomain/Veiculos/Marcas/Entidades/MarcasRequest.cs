using CotacacoSeguroDomain.Enums;

namespace CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

public class MarcasRequest
{
    public int ID { get; set; }
    public string NomeMarca { get; set; }
    public ETipoProducao TipoProducao { get; set; }
}