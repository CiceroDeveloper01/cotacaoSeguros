using CotacacoSeguroShared.PaginacaoBuscao;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

public class ModelosFilters : CriterioPagina
{
    public string NomeMarca { get; set; }
    public string NomeModelo { get; set; }
    public int AnoInicialFabricacao { get; private set; }
    public int AnoFinalFabricacao { get; private set; }
}