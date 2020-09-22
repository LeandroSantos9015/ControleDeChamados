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

        private void DelegarEventos()
        {
            this.Principal.MudarUsuárioToolStripMenuItem.Click += MudarUsuárioToolStripMenuItem_Click;
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
