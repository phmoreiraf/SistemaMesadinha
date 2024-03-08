using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Mesadinha
{
    public partial class telalogin : Form
    {
        public telalogin()
        {
            InitializeComponent();
        }

        ConexaoBD bd = new ConexaoBD();
        string sql;


        Login objLogin = new Login();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmusuarios users = new frmusuarios();
            users.ShowDialog();
            this.Visible = true;
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            if(objLogin.ValidarUsuario(txt_email.Text, txt_senha.Text))
            {
                this.Visible = false;
                frm_menu menu = new frm_menu();
                menu.ShowDialog();
                this.Visible = true;
                txt_senha.Clear();
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
