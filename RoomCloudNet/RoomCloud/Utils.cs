using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoomCloud
{
    public class Utils
    {
        public static string Retorna_CPF(string CPF_CNPJ)
        {
            string Resultado = "";
            if (!string.IsNullOrEmpty(CPF_CNPJ) && CPF_CNPJ.Length > 10)
            {
                if (Regex.Replace(CPF_CNPJ, "[^0-9]+", "").Length == 11)
                {
                    Resultado = CPF_CNPJ;
                }
            }
            return Resultado;
        }

        public static string Retorna_CNPJ(string CPF_CNPJ)
        {
            string Resultado = "";
            if (!string.IsNullOrEmpty(CPF_CNPJ) && CPF_CNPJ.Length > 10)
            {
                if (Regex.Replace(CPF_CNPJ, "[^0-9]+", "").Length == 14)
                {
                    Resultado = CPF_CNPJ;
                }
            }
            return Resultado;
        }

        public static int Retorna_IDTipoPessoa(string Tipo_Pessoa)
        {
            int Resultado = 0;
            if (!string.IsNullOrEmpty(Tipo_Pessoa))
            {
                if (Tipo_Pessoa == "PessoaFisica")
                {
                    Resultado = 1;
                }
                else if (Tipo_Pessoa == "PessoaJuridica")
                {
                    Resultado = 2;
                }
            }
            return Resultado;
        }

        public static string Retorna_DDD(string NumeroFone)
        {
            string Resultado = "";
            if (!string.IsNullOrEmpty(NumeroFone) && NumeroFone.Length > 10)
            {
                if (NumeroFone.IndexOf("(", 0) > 0)
                {
                    Resultado = NumeroFone.Substring(1, 2);
                }
                else
                {
                    Resultado = NumeroFone.Substring(0, 2);
                }
            }
            return Resultado;
        }

        public static string Retorna_Fone(string NumeroFone)
        {
            string Resultado = "";
            if (!string.IsNullOrEmpty(NumeroFone))
            {
                if (NumeroFone.Length > 10)
                {
                    if (NumeroFone.IndexOf("(", 0) > 0)
                    {
                        Resultado = NumeroFone.Substring(4);
                    }
                    else
                    {
                        Resultado = NumeroFone.Substring(2);
                    }
                }
                else
                {
                    Resultado = NumeroFone;
                }
            }
            return Resultado;
        }

        public static string Retorna_SoNumeros(string Texto)
        {
            string Resultado = "";
            if (!string.IsNullOrEmpty(Texto))
            {
                Regex Regular = new Regex(@"[^\d]");
                Resultado = Regular.Replace(Texto, "");
            }
            return Resultado;
        }

        public static string Retorna_CodigoBarras(string Texto)
        {
            string CodigoBarras = "";
            if (!string.IsNullOrEmpty(Texto))
            {
                switch (Texto.Length)
                {
                    case 7:
                        CodigoBarras = "0" + Texto;
                        break;
                    case 8:
                        CodigoBarras = Texto;
                        break;
                    case 11:
                        CodigoBarras = "00" + Texto;
                        break;
                    case 12:
                        CodigoBarras = "0" + Texto;
                        break;
                    case 13:
                        CodigoBarras = Texto;
                        break;
                    case 14:
                        CodigoBarras = Texto;
                        break;
                    default:
                        break;
                }
            }
            return CodigoBarras;
        }
    }

    //public class TLog
    //{

    //    public string Api { get; set; }
    //    public ServicosWlog Tarefa { get; set; }
    //    public string Descricao { get; set; }
    //    public string Sku { get; set; }
    //    public double? Preco1 { get; set; }
    //    public double? Preco2 { get; set; }
    //    public int? Estoque { get; set; }
    //    public int? Filial { get; set; }
    //    public string XML_Produto { get; set; }
    //    public string Json_Produto { get; set; }
    //    public int? Pedido { get; set; }
    //    public int? Pedido_Externo { get; set; }
    //    public string Pedido_Status { get; set; }
    //    public string Pedido_NFs { get; set; }
    //    public string Json_Pedido { get; set; }
    //    public DateTime Inicio_Tarefa { get; set; }
    //    public DateTime Fim_Tarefa { get; set; }
    //    public int? Tempo_Execucao { get; set; }

    //    public TLog()
    //    {
    //        Sku = null;
    //        Preco1 = null;
    //        Preco2 = null;
    //        Estoque = null;
    //        Filial = null;
    //        XML_Produto = null;
    //        Json_Produto = null;
    //        Pedido = null;
    //        Pedido_Externo = null;
    //        Pedido_Status = null;
    //        Pedido_NFs = null;
    //        Json_Pedido = null;
    //    }

    //    public static void Inserir(string Api, ServicosWlog Servico, Produto_Estoque Estoque, Produto_Preco Preco, int? Pedido, int? PedidoExterno, Acao StatusPedido, string Xml, string Json, DateTime InicioTarefa, DateTime FimTarefa, int TempoExecucao)
    //    {
    //        TLog Log = new TLog();
    //        try
    //        {
    //            Log.Api = Api;
    //            Log.Tarefa = Servico;
    //            Log.Inicio_Tarefa = InicioTarefa;
    //            Log.Fim_Tarefa = FimTarefa;
    //            Log.Tempo_Execucao = TempoExecucao;
    //            switch (Servico.GetHashCode())
    //            {
    //                case 5:
    //                    Log.Descricao = "Importação de Produtos";
    //                    Log.XML_Produto = Xml;
    //                    Insert(Log);
    //                    break;
    //                case 6:
    //                    Log.Descricao = "Importação de Preços";
    //                    Log.Sku = Preco.sku;
    //                    Log.Preco1 = Preco.preco1;
    //                    Log.Preco2 = Preco.preco2;
    //                    Log.Json_Produto = Json;
    //                    Insert(Log);
    //                    break;
    //                case 7:
    //                    Log.Descricao = "Importação de Estoque Geral";
    //                    Log.Sku = Estoque.sku;
    //                    Log.Estoque = Estoque.saldo.Value;
    //                    Log.Json_Produto = Json;
    //                    Insert(Log);
    //                    break;
    //                case 8:
    //                    Log.Descricao = "Importação de Estoque Por Filial";
    //                    Log.Sku = Estoque.sku;
    //                    Log.Estoque = Estoque.saldo.Value;
    //                    Log.Filial = Estoque.filial.Value;
    //                    Log.Json_Produto = Json;
    //                    Insert(Log);
    //                    break;
    //                case 9:
    //                    Log.Descricao = "Importação de Status dos Pedidos";
    //                    Log.Pedido = Pedido;
    //                    Log.Pedido_Externo = PedidoExterno;
    //                    Log.Pedido_Status = StatusPedido.status.ToString();
    //                    Log.Pedido_NFs = StatusPedido.nota.ToString();
    //                    Log.Json_Pedido = Json;
    //                    Insert(Log);
    //                    break;
    //                case 11:
    //                    Log.Descricao = "Exportação de Pedidos";
    //                    Log.Pedido = Pedido;
    //                    Log.Pedido_Externo = PedidoExterno;
    //                    Log.Json_Pedido = Json;
    //                    Insert(Log);
    //                    break;
    //                case 13:
    //                    Log.Descricao = "Processa Status dos Pedidos";
    //                    Log.Pedido = Pedido;
    //                    Log.Pedido_Externo = PedidoExterno;
    //                    Log.Json_Pedido = Json;
    //                    Insert(Log);
    //                    break;
    //            }
    //        }
    //        catch
    //        {
    //            throw;
    //        }
    //    }

    //    private static void Insert(TLog Log)
    //    {
    //        AcessaDados objAcessoDados = null;
    //        SqlCommand oSqlCommand = new SqlCommand();
    //        try
    //        {
    //            objAcessoDados = new AcessaDados(ConfigurationManager.ConnectionStrings["ChlebaDataSource"].ConnectionString);
    //            objAcessoDados.Open();
    //            oSqlCommand = LoadParametrosInserir(Log);
    //            objAcessoDados.ExecuteReaderScalar(oSqlCommand);
    //        }
    //        catch
    //        {
    //            throw;
    //        }
    //        finally
    //        {
    //            objAcessoDados.Close();
    //        }
    //    }

    //    private static SqlCommand LoadParametrosInserir(TLog Log)
    //    {
    //        var objSqlCommand = new SqlCommand("[DBO].[USP_WS_Log_Insert]");
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Api", SqlDbType.VarChar)).Value = Log.Api;
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Tarefa", SqlDbType.TinyInt)).Value = Log.Tarefa.GetHashCode();
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Sku", SqlDbType.VarChar)).Value = ((Log.Sku == null) ? (object)DBNull.Value : Log.Sku);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Preco1", SqlDbType.Decimal)).Value = ((Log.Preco1 == null) ? (object)DBNull.Value : Log.Preco1);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Preco2", SqlDbType.Decimal)).Value = ((Log.Preco2 == null) ? (object)DBNull.Value : Log.Preco2);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Estoque", SqlDbType.Int)).Value = ((Log.Estoque == null) ? (object)DBNull.Value : Log.Estoque);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Filial", SqlDbType.Int)).Value = ((Log.Filial == null) ? (object)DBNull.Value : Log.Filial);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Xml_Produto", SqlDbType.Xml)).Value = ((Log.XML_Produto == null) ? (object)DBNull.Value : Log.XML_Produto);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Json_Produto", SqlDbType.Text)).Value = ((Log.Json_Produto == null) ? (object)DBNull.Value : Log.Json_Produto);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Order_id", SqlDbType.Int)).Value = ((Log.Pedido == null) ? (object)DBNull.Value : Log.Pedido);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Pedidov", SqlDbType.Int)).Value = ((Log.Pedido_Externo == null) ? (object)DBNull.Value : Log.Pedido_Externo);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Order_Status", SqlDbType.VarChar)).Value = ((Log.Pedido_Status == null) ? (object)DBNull.Value : Log.Pedido_Status);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Order_Nfs", SqlDbType.VarChar)).Value = ((Log.Pedido_NFs == null) ? (object)DBNull.Value : Log.Pedido_NFs);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@Json_Pedido", SqlDbType.Text)).Value = ((Log.Json_Pedido == null) ? (object)DBNull.Value : Log.Json_Pedido);
    //        objSqlCommand.Parameters.Add(new SqlParameter("@InicioProcesso", SqlDbType.DateTime)).Value = Log.Inicio_Tarefa;
    //        objSqlCommand.Parameters.Add(new SqlParameter("@FimProcesso", SqlDbType.DateTime)).Value = Log.Fim_Tarefa;
    //        objSqlCommand.Parameters.Add(new SqlParameter("@TempoExec", SqlDbType.Int)).Value = Log.Tempo_Execucao;
    //        return objSqlCommand;
    //    }
    //}
}
