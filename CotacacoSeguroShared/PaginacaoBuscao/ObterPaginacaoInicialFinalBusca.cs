namespace CotacacoSeguroShared.PaginacaoBuscao;

public class ObterPaginacaoInicialFinalBusca
{
    const int numeropaginainicalpadrao = 1;
    const int quantidademaximaitensporpagina = 100;
    private static int paginacorrente = 0;
    private static int quantidadeitensreal = 0;
    private static double numeropaginasreal = 0;
    public static void ValidarPaginasInformadas(int totalregistros, int numeropaginadesejada, int quantidadeitensporpagina)
    {
        double numeropaginas = 0;
        if (numeropaginadesejada <= 0)
            numeropaginadesejada = 1;

        if (quantidadeitensporpagina > quantidademaximaitensporpagina)
            quantidadeitensporpagina = quantidademaximaitensporpagina;

        if (totalregistros > quantidadeitensporpagina)
        {
            numeropaginas = (double)totalregistros / (double)quantidadeitensporpagina;
            quantidadeitensreal = quantidadeitensporpagina;
        }
        else
        {
            numeropaginas = numeropaginainicalpadrao;
            quantidadeitensreal = totalregistros;
        }
        numeropaginasreal = Math.Ceiling(numeropaginas);
        if (numeropaginadesejada > numeropaginasreal)
            paginacorrente = Convert.ToInt32(numeropaginasreal);
        else
            paginacorrente = numeropaginadesejada;
    }
    public static RetornoLinhasBusca ObterPaginacaoBusca(int totalregistros, int numeropaginadesejada, int quantidadeitensporpagina)
    {
        ValidarPaginasInformadas(totalregistros, numeropaginadesejada, quantidadeitensporpagina);

        int PosicaoInicial = 0;
        int PosicaoFinal = 0;
        if (paginacorrente != 1)
        {
            PosicaoInicial = ((paginacorrente - 1) * quantidadeitensreal) + 1;
            PosicaoFinal = (PosicaoInicial - 1) + quantidadeitensreal;
        }
        else
        {
            PosicaoInicial = paginacorrente;
            PosicaoFinal = (PosicaoInicial - 1) + quantidadeitensreal;
        }
        if (PosicaoFinal > totalregistros)
            PosicaoFinal = totalregistros;
        var retornoLinhasBusca = new RetornoLinhasBusca(PosicaoInicial, PosicaoFinal, quantidadeitensreal, totalregistros, Convert.ToInt32(numeropaginasreal), paginacorrente);
        return retornoLinhasBusca;
    }
}
