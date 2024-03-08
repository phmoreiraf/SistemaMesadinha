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
    public partial class frmusuarios : Form
    {
        public frmusuarios()
        {
            InitializeComponent();          
        }

        
        ConexaoBD bd = new ConexaoBD();
        string sql;

        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            telalogin voltar = new telalogin();
            voltar.ShowDialog();
            this.Visible = true;
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if(txt_senha.Text == txt_csenha.Text)
            {
                sql = string.Format("insert into usuario values (null,'{0}','{1}','{2}',null,null)", txt_nome.Text, txt_email.Text, txt_senha.Text);
                bd.AlterarTabelas(sql);
                MessageBox.Show("Usuario Cadastrado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("As senhas nao conferi!");
                txt_nome.Focus();
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
