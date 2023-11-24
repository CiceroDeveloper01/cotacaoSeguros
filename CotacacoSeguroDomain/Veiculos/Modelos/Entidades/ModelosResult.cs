using CotacacoSeguroDomain.Veiculos.Marcas.Entidades;

namespace CotacacoSeguroDomain.Veiculos.Modelos.Entidades;

public class ModelosResult
{
    public int ID { get; set; }
    public string NomeModelo { get; set; }
    public int AnoInicialFabricacao { get; set; }
    public int? AnoFinalFabricacao { get; set; }
    public MarcasResult Marcas { get; set; }
    public DateTime DataAlteracao { get; set; }
    public DateTime DataCriacao { get; set; }
}
