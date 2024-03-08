using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Mesadinha
{
    class Login
    {

        private static string nome;
        private static string id;
        private static string email;
        private static string senha1;
        

        public bool ValidarUsuario(string usuario, string senha)
        {
            ConexaoBD bd = new ConexaoBD();
            DataTable resultado = new DataTable();
            string sql = string.Format("select * from usuario where email = '{0}' and senha = '{1}'", usuario, senha);
            resultado = bd.ConsultarTabelas(sql);


            if (resultado.Rows.Count > 0)
            {
                id = resultado.Rows[0]["id"].ToString();
                nome = resultado.Rows[0]["nome"].ToString();
                email = resultado.Rows[0]["email"].ToString();
                senha1 = resultado.Rows[0]["senha"].ToString();

                return true;
				
            }
            else
            {
                return false;
            }           
        }

        public string UsuarioLogado()
        {
            return nome;
        }

        public string IdUsuario()
        {
            return id;
        }

        public string EmailUsuario()
        {
            return email;
        }

        public string SenhaUsuario()
        {
            return senha1;
        }
    }
}
