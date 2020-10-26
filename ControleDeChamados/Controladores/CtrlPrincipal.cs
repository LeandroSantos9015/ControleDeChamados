using Controladores.Cadastros;
using Controladores.Chamados;
using Customizados;
using Enumeradores;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;


namespace Controladores
{
    public class CtrlPrincipal
    {
        public ITelaPrincipal Principal { get; set; }


        public CtrlPrincipal()
        {
            this.Principal = new FrmPrincipal();

            this.DelegarEventos();

            this.CarregaToolStripComboBox();

            // this.TesteExcecao();
        }

        private void TesteExcecao()
        {
            try
            {
                string valor = "";

                valor = null;

                valor.ToString();
            }
            catch { throw new Exception("Posso customizar a mensagem"); }

        }

        private void CarregaToolStripComboBox()
        {
            this.Principal.CmbAtivo.ComboBox.DataSource = SetDataSource.Carregar(typeof(EAtivo));
            this.Principal.CmbAtivo.ComboBox.DisplayMember = SetDataSource.Mostrador;
            this.Principal.CmbAtivo.ComboBox.ValueMember = SetDataSource.Valor;
        }

        private void DelegarEventos()
        {
            this.Principal.MudarUsuarioToolStripMenuItem.Click += MudarUsuárioToolStripMenuItem_Click;
            this.Principal.ChamadosToolStripMenuItem.Click += ChamadoToolStripMenuItem_Click;
            this.Principal.CategoriaToolStripMenuItem.Click += CategoriaToolStripMenuItem_Click;
            this.Principal.DepartamentoToolStripMenuItem.Click += DepartamentoToolStripMenuItem_Click;
            this.Principal.StatusToolStripMenuItem.Click += StatusToolStripMenuItem_Click;
            this.Principal.EtapaToolStripMenuItem.Click += EtapaToolStripMenuItem_Click;

        }

        private void StatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CtrlStatus(Principal);
        }

        private void EtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CtrlEtapa(Principal);
        }

        private void DepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CtrlDepartamento(Principal);
        }

        private void CategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CtrlCategoria(Principal);
        }

        private void ChamadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CtrlChamado(Principal);
        }

        private void MudarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // simular null ref excp
            string valor = "";
            valor = null;
            valor.ToString();
        }
    }
}
