using DevExpress.XtraEditors.ViewInfo;
using Interfaces.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Chamados;

namespace Controladores.Chamados
{
    public class CtrlInteracoes
    {
        public IUCInteracao InteracaoView { get; set; }

        public CtrlInteracoes(Int64? IdChamado)
        {
            this.InteracaoView = new UCInteracoes();

            CarregaInteracoes(null);

            this.DelegarEventos();

            this.InteracaoView.UCInteracaoView.Show();
        }

        private void DelegarEventos()
        {
            this.InteracaoView.LblUsuario.Click += LblUsuario_Click;




        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {
            //this.InteracaoView.RchDesc.Lines.ToString();

            CarregaInteracoes(this.InteracaoView.TextDesc.Text);
        }

        private void CarregaInteracoes(string texto)
        {
            if (texto is null)
                for (int i = 0; i < 50; i++)
                    texto += "linha ";

            this.InteracaoView.TextDesc.Text = texto;

            this.InteracaoView.TextDesc.Properties.ScrollBars = ScrollBars.None;
            DevExpress.XtraEditors.ViewInfo.MemoEditViewInfo vi = this.InteracaoView.TextDesc.GetViewInfo() as DevExpress.XtraEditors.ViewInfo.MemoEditViewInfo;
            DevExpress.Utils.Drawing.GraphicsCache cache = new DevExpress.Utils.Drawing.GraphicsCache(this.InteracaoView.TextDesc.CreateGraphics());
            int h = (vi as DevExpress.XtraEditors.ViewInfo.IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
            DevExpress.Utils.Drawing.ObjectInfoArgs args = new DevExpress.Utils.Drawing.ObjectInfoArgs();
            args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
            Rectangle rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
            cache.Dispose();
            this.InteracaoView.TextDesc.Height = rect.Height;

            this.InteracaoView.LblNumero.Text = "1";
            this.InteracaoView.LblUsuario.Text = "Leandro Andrade dos Santos";

        }
    }
}