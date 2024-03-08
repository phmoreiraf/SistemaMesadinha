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
    public partial class frmcategoria : Form
    {
        public frmcategoria()
        {
            InitializeComponent();
        }
		
        ConexaoBD bd = new ConexaoBD();
        string sql;
		
        private void frmcategoria_Load(object sender, EventArgs e)
        {
            Listar();
        }


        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frm_menu voltar = new frm_menu();
            voltar.ShowDialog();
            this.Visible = true;
        }

        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmcontas addconta = new frmcontas();
            addconta.ShowDialog();
            this.Visible = true;
        }

        public void Limpar()
        {
            txt_id.Clear();
            txt_adicionar.Clear();
        }

        private void btn_adicionarCategoria_Click(object sender, EventArgs e)
        {
            sql = string.Format("insert into CATEGORIAS values(null,'{0}')", txt_adicionar.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Categoria inserida", "Adicionar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_adicionar.Clear();
        }

        public void Listar()
        {
            // sql = "select id as ID, NOME from CATEGORIAS";
           sql = "select * from CATEGORIAS";
           dtg_listarcategoria.DataSource = bd.ConsultarTabelas(sql);
        }

        private void dtg_listarcategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dtg_listarcategoria.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_adicionar.Text = dtg_listarcategoria.Rows[e.RowIndex].Cells[1].Value.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = string.Format("delete from CATEGORIAS where id = '{0}'", txt_adicionar.Text, txt_id.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Categoria Deletada", "Excluir Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            sql = string.Format("update CATEGORIAS set NOME = '{0}' where ID = '{1}'", txt_adicionar.Text, txt_id.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Categoria Alterada", "Alterar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmcategoria cate = new frmcategoria();
            cate.ShowDialog();
            this.Visible = true;
        }

        private void movimentacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmmovimentacao movimentar = new frmmovimentacao();
            movimentar.ShowDialog();
            this.Visible = true;
        }
    }
}
