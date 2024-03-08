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
    public partial class frm_menu : Form
    {
        public frm_menu()
        {
            InitializeComponent();
           
        }

        public static string receitasA;
        public static string despesasA;


        ConexaoBD bd = new ConexaoBD();
        string sql;

        Login objLogin = new Login();

       
        private void frm_menu_Load(object sender, EventArgs e)
        {

            Receitas();
            Despesas();
            Saldos();
            lblUsuario.Text = "Seja Bem Vindo! - " + objLogin.UsuarioLogado() + " - com o ID: "  + objLogin.IdUsuario() + ". ";
           
        }


        public void Receitas()
        {

            DataTable resultados = new DataTable();
            sql = "select sum(MOVIMENTACAO.VALOR_MOVI) as RECEITAS from CONTAS join MOVIMENTACAO on CONTAS.ID = MOVIMENTACAO.ID_CONTA where CONTAS.TIPO_CONTA = 'Receitas';"; 
            resultados = bd.ConsultarTabelas(sql);
            receitasA = resultados.Rows[0]["RECEITAS"].ToString();
            lbl_despesas.Text = receitasA;

        }

        public void Despesas()
        {
            
            DataTable resultado = new DataTable();
            sql = "select sum(MOVIMENTACAO.VALOR_MOVI) as DESPESAS from CONTAS join MOVIMENTACAO on CONTAS.ID = MOVIMENTACAO.ID_CONTA where CONTAS.TIPO_CONTA = 'Despesas';";
            resultado = bd.ConsultarTabelas(sql);
            despesasA = resultado.Rows[0]["DESPESAS"].ToString();
            lbl_receitas.Text = despesasA;

        }

        public void Saldos()
        {
            double receita, despesa;
            double.TryParse(lbl_receitas.Text, out receita);
            double.TryParse(lbl_despesas.Text, out despesa);
            lbl_saldo.Text = (receita - despesa).ToString();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusuarios cad = new frmusuarios();
            cad.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trocarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmalterarperfil trocar = new frmalterarperfil();
            trocar.ShowDialog();
            this.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmcategoria cate = new frmcategoria();
            cate.ShowDialog();
            this.Visible = true;
        }

        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmcontas addconta = new frmcontas();
            addconta.ShowDialog();
            this.Visible = true;
        }

        private void movimentacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmmovimentacao movimentar = new frmmovimentacao();
            movimentar.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void alterarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmalterarperfil alterar = new frmalterarperfil();
            alterar.ShowDialog();
            this.Visible = true;
        }

        private void lbl_receitas_Click(object sender, EventArgs e)
        {
            
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
