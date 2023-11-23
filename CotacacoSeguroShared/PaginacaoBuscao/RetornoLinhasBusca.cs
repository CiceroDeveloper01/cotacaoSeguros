namespace CotacacoSeguroShared.PaginacaoBuscao;

public class RetornoLinhasBusca
{
    public int LinhaInicialCaptura { get; private set; }
    public int LinhaFinalCaptura { get; private set; }
    public int TotalItens { get; private set; }
    public int TotalPaginas { get; private set; }
    public int QuantidadeItensPorPagina { get; private set; }
    public int NumeroPaginaAtual { get; private set; }
    public RetornoLinhasBusca(int linhainicialcaptura, 
                              int linhafinalcaptura, 
                              int quantidadeitensporagina, 
                              int totalitens, 
                              int totalpaginas, 
                              int numeropaginaatual)
    {
        LinhaInicialCaptura = linhainicialcaptura;
        LinhaFinalCaptura = linhafinalcaptura;
        QuantidadeItensPorPagina = quantidadeitensporagina;
        TotalItens = totalitens;
        TotalPaginas = totalpaginas;
        NumeroPaginaAtual = numeropaginaatual;
    }
}