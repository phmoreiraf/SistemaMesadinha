using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Mesadinha
{
    class ConexaoBD
    {

        private MySqlConnection conexao;


        public void ConectarBD()
        {
            conexao = new MySqlConnection("persist security info = false;server=localhost;database=projeto_mesadinha;uid=root;pwd=;");
            conexao.Open();
        }

        //insert - delete - update
        public void AlterarTabelas(string sql)
        {

            try
            {
                ConectarBD();
                MySqlCommand comados = new MySqlCommand(sql, conexao);
                comados.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }

        }

        public DataTable ConsultarTabelas(string sql)
        {

            try
            {
                ConectarBD();
                MySqlDataAdapter consultas = new MySqlDataAdapter(sql, conexao);
                DataTable resultado = new DataTable();
                consultas.Fill(resultado);
                return resultado;
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        // Consultar categoria no metodo categoria
        //public DataTable ConsultarCategoria()
        //{

        //MySqlConnection con= new MySqlConnection("persist security info = false;server=localhost;database=projeto_mesadinha;uid=root;pwd=;");
        // string sql = "select id, nome from CATEGORIAS";
        //con.Open();
        //MySqlDataAdapter da = new MySqlDataAdapter(sql, conexao);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //return dt;

        //}
        // Consultar categoria no metodo conta
        //public DataTable ConsultarConta()
        //{

        //MySqlConnection con = new MySqlConnection("persist security info = false;server=localhost;database=projeto_mesadinha;uid=root;pwd=;");
        //string sql = "select id, nome from CONTAS";
        //con.Open();
        //MySqlDataAdapter da = new MySqlDataAdapter(sql, conexao);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //return dt;

        //}
    }
}

