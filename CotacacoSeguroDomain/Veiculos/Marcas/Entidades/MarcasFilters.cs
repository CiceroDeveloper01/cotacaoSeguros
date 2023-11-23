using CotacacoSeguroDomain.Enums;
using CotacacoSeguroShared.PaginacaoBuscao;

namespace CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

public class MarcasFilters : CriterioPagina
{
    public string NomeMarca { get; set; }
    public ETipoProducao? TipoProducao { get; set; }
}