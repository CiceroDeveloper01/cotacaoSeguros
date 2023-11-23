using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

public class ModelosRequest
{
    public int ID { get; set; }
    public string NomeModelo { get; set; }
    public int AnoInicialFabricacao { get; set; }
    public int? AnoFinalFabricacao { get; set; }
    public MarcasRequest Marcas { get; set; }
}