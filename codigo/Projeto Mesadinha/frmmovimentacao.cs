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
    public partial class frmmovimentacao : Form
    {
        public frmmovimentacao()
        {
            InitializeComponent();
        }

        ConexaoBD bd = new ConexaoBD();
        string sql;
        private void frmmovimentacao_Load(object sender, EventArgs e)
        {
            Listar();
            Contas();
        }
        public void Listar()
        {
            // sql = "select id as ID, NOME from CATEGORIAS";
            sql = "select MOVIMENTACAO.ID as ID, MOVIMENTACAO.VALOR_MOVI as VALOR, MOVIMENTACAO.DATA as DATA, CONTAS.NOME as NOME from MOVIMENTACAO join CONTAS on CONTAS.ID = MOVIMENTACAO.ID_CONTA";
            dtg_listarmovimentcao.DataSource = bd.ConsultarTabelas(sql);

            //cbx_conta.DataSource = bd.ConsultarTabelas(sql);
            //cbx_conta.DisplayMember = "NOME";
            //cbx_conta.ValueMember = "MOVIMENTACAO.ID_CONTA";
        }

        public void Contas()
        {
            sql = "select id, nome from CONTAS";
            cbx_conta.DataSource = bd.ConsultarTabelas(sql);
            cbx_conta.DisplayMember = "nome";
            cbx_conta.ValueMember = "id";

        }
        public void Limpar()
        
        {
            txt_idMovi.Clear();
            cbx_conta.SelectedIndex = -1;
            txt_valor.Clear();
            dtp_data.Text = DateTime.Now.ToString();
            cbx_conta.Focus();
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frm_menu voltar = new frm_menu();
            voltar.ShowDialog();
            this.Visible = true;
        }

        private void btn_adicionarMovi_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dtp_data.Text);
            sql = string.Format("insert into MOVIMENTACAO values(null,'{0}', '{1}', '{2}'",txt_valor.Text, dt.ToString("yyyy-MM-dd"), cbx_conta.SelectedValue.ToString());
            bd.AlterarTabelas(sql);
            MessageBox.Show("Conta Cadastrada", "Cadastrar Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dtp_data.Text);
            sql = string.Format("update MOVIMENTACAO set VALOR_MOVI = '{0}', DATA ='{1}', ID_CONTA = '{2}' where ID = '{3}'" ,txt_valor.Text, dt.ToString("yyyy-MM-dd"), cbx_conta.SelectedValue.ToString(), txt_idMovi.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Conta Alterada", "Alterar Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dtp_data.Text);
            sql = string.Format("delete from MOVIMENTACAO where id = '{0}'", txt_idMovi.Text, txt_valor.Text, dt.ToString("yyyy-MM-dd"), cbx_conta.SelectedValue.ToString());
            bd.AlterarTabelas(sql);
            MessageBox.Show("Conta Deletada", "Excluir Conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void dtg_listarmovimentcao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idMovi.Text = dtg_listarmovimentcao.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_valor.Text = dtg_listarmovimentcao.Rows[e.RowIndex].Cells[1].Value.ToString();            
            dtp_data.Text = dtg_listarmovimentcao.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbx_conta.Text = dtg_listarmovimentcao.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
    }
}
