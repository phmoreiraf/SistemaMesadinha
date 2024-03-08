using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Mesadinha
{
    public partial class frmalterarperfil : Form
    {
        public frmalterarperfil()
        {
            InitializeComponent();
        }
      
        ConexaoBD bd = new ConexaoBD();
        string sql;

        Login objlogin = new Login();

        private void frmtrocarsenha_Load(object sender, EventArgs e)
        {
            ID();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frm_menu voltar = new frm_menu();
            voltar.ShowDialog();
            this.Visible = true;
        }

        public void ID()
        {
            txt_id.Text = objlogin.IdUsuario();
            txt_nome.Text = objlogin.UsuarioLogado();
            txt_email.Text = objlogin.EmailUsuario();
            txt_senha.Text = objlogin.SenhaUsuario();
        }

       
        private void btn_alterar_Click(object sender, EventArgs e)
        {

                sql = string.Format("update USUARIO set NOME = '{0}', EMAIL ='{1}', SENHA = '{2}' where ID = '{3}'", txt_id.Text, txt_nome.Text , txt_email.Text, txt_senha.Text);

                bd.AlterarTabelas(sql);
                MessageBox.Show("Usuario Alterado", "Alterar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_id.Focus();
                
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
