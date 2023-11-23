using Dapper;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        ImportarCarros();
    }

    static void ImportarCarros()
    {
        ImportarMarcasCarros();
        ImportarModelosCarros();
    }

    static void ImportarMarcasCarros()
    {
        OleDbConnection _olecon;
        OleDbCommand _oleCmd;
        string _Arquivo = @"C:\Seguros\Cotacao\marcas-e-modelos\marcas-carros.xlsx";
        string _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
        string _Consulta;
        try
        {
            _olecon = new OleDbConnection(_StringConexao);
            _olecon.Open();

            _oleCmd = new OleDbCommand();
            _oleCmd.Connection = _olecon;
            _oleCmd.CommandType = CommandType.Text;

            _oleCmd.CommandText = "SELECT ID, NOME FROM [MARCAS-CARROS$]";
            OleDbDataReader reader = _oleCmd.ExecuteReader();

            string sql = "";

            while (reader.Read())
            {
                try
                {
                    //"Persist Security Info=False;Trusted_Connection=True; database=dbgeneric_app;server=DESKTOP-GJU88SC;Encrypt=True;")
                    using (var conexao = new SqlConnection("Server=DESKTOP-GJU88SC\\SQLEXPRESS;Uid=usuarioSeguro;Pwd=@SoLo150910;Database=dtbSegurosCarros;"))
                    {
                        sql = $@"INSERT INTO veiculos.TB_MARCAS
                                                      (ID
                                                     , NomeMarca
                                                     , TipoProducao
                                                     , DataAlteracao
                                                     , DataCriacao) 
                                                VALUES({reader.GetValue(0).ToString()}
                                                     , '{reader.GetValue(1).ToString().Replace("'", "''")}'
                                                     , 'CARROS'
                                                     , GETDATE()
                                                     , GETDATE())";
                        conexao.Execute(sql);
                    }
                    Console.WriteLine($@"Gravando Marca com ID: {reader.GetValue(0).ToString()} e Descrição: {reader.GetValue(1).ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(sql);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    static void ImportarModelosCarros()
    {
        OleDbConnection _olecon;
        OleDbCommand _oleCmd;
        string _Arquivo = @"C:\Seguros\Cotacao\marcas-e-modelos\modelos-carros.xlsx";
        string _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
        string _Consulta;
        try
        {
            _olecon = new OleDbConnection(_StringConexao);
            _olecon.Open();

            _oleCmd = new OleDbCommand();
            _oleCmd.Connection = _olecon;
            _oleCmd.CommandType = CommandType.Text;

            _oleCmd.CommandText = "SELECT ID, IDMARCA, NOME FROM [MODELOS-CARRO$]";
            OleDbDataReader reader = _oleCmd.ExecuteReader();

            string sql = "";

            while (reader.Read())
            {
                try
                {
                    //"Persist Security Info=False;Trusted_Connection=True; database=dbgeneric_app;server=DESKTOP-GJU88SC;Encrypt=True;")
                    using (var conexao = new SqlConnection("Server=DESKTOP-GJU88SC\\SQLEXPRESS;Uid=usuarioSeguro;Pwd=@SoLo150910;Database=dtbSegurosCarros;"))
                    {
                        sql = $@"INSERT INTO veiculos.TB_MODELOSMARCAS
                                                      (ID
                                                     , IDMARCAS
                                                     , NomeModelo
                                                     , AnoInicialFabricacao
                                                     , AnoFinalFabricacao
                                                     , DataAlteracao
                                                     , DataCriacao) 
                                                VALUES({reader.GetValue(0).ToString()}
                                                     , {reader.GetValue(1).ToString()}
                                                     , '{reader.GetValue(2).ToString().Replace("'", "''")}'
                                                     , 1900
                                                     , 2100 
                                                     , GETDATE()
                                                     , GETDATE())";
                        conexao.Execute(sql);
                    }
                    Console.WriteLine($@"Gravando Modelo com ID: {reader.GetValue(0).ToString()} e Descrição: {reader.GetValue(2).ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(sql);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

