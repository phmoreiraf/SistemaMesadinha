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
    public partial class frmcontas : Form
    {
        public frmcontas()
        {
            InitializeComponent();
        }

        ConexaoBD bd = new ConexaoBD();
        string sql;

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frm_menu voltar = new frm_menu();
            voltar.ShowDialog();
            this.Visible = true;
        }

        public void Listar()
        {
            // sql = "select id as ID, NOME from CATEGORIAS";
            sql = "select CONTAS.ID, CONTAS.NOME, CONTAS.TIPO_CONTA, CATEGORIAS.NOME AS CATEGORIAS from CATEGORIAS join CONTAS on CATEGORIAS.ID = CONTAS.ID_CATEGORIAS";
            dtg_listarConta.DataSource = bd.ConsultarTabelas(sql);

            //cbx_categoria.DataSource = bd.ConsultarTabelas(sql);
            //cbx_categoria.DisplayMember = "CATEGORIAS";
            //cbx_categoria.ValueMember = "CONTAS.ID_CATEGORIAS";
        }

        public void Categoria()
        {
            sql = "select id, nome from CATEGORIAS";
            cbx_categoria.DataSource = bd.ConsultarTabelas(sql);
            cbx_categoria.DisplayMember = "nome";
            cbx_categoria.ValueMember = "id";
        }

        public void Limpar()
        {
            txt_nome.Clear();
            txt_idConta.Clear();
            cbx_categoria.SelectedIndex = -1;
            cbx_tipo.SelectedIndex = -1;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_conta_Click(object sender, EventArgs e)
        {

            if (txt_idConta.Text == "")
            {
                sql = string.Format("insert into CONTAS values(null,'{0}', '{1}', '{2}'", txt_nome.Text, cbx_tipo.Text, cbx_categoria.SelectedValue.ToString());
                bd.AlterarTabelas(sql);
                MessageBox.Show("Conta Cadastrada", "Cadastrar Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                Listar();
            }
            else
            {
                MessageBox.Show("Nao foi possivel inserir uma conta");
                txt_nome.Focus();
            }
            
        }

        private void dtg_listarConta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idConta.Text = dtg_listarConta.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_nome.Text = dtg_listarConta.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbx_tipo.Text = dtg_listarConta.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbx_categoria.Text = dtg_listarConta.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            sql = string.Format("update CONTAS set NOME = '{0}', TIPO_CONTA ='{1}', ID_CATEGORIAS = '{2}' where ID = '{3}'",txt_nome.Text, cbx_tipo.Text, cbx_categoria.SelectedValue.ToString(), txt_idConta.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Conta Alterada", "Alterar Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            sql = string.Format("delete from CONTAS where id = '{0}'", txt_nome.Text, cbx_tipo.Text, cbx_categoria.SelectedValue.ToString());
            bd.AlterarTabelas(sql);
            MessageBox.Show("Conta Deletada", "Excluir Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void frmcontas_Load(object sender, EventArgs e)
        {
            Listar();
            Categoria();

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
    }
}
