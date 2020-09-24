using Interfaces.UserControls;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.UserControlPadrao;

namespace Controladores.TelaPadrao
{
    public abstract class CtrlTelaPadrao
    {
        public IUCPadrao IdDescricaoPadrao { get; set; }

        public abstract ModelTelaPadrao ModeloTelaPadrao { get; }

        public CtrlTelaPadrao()
        {
            IdDescricaoPadrao = new UCPadrao();

            ModelTelaPadrao modelo = ModeloTelaPadrao;

            PreencheCamposFormatacao(modelo);

            FlowLayoutPanel painel = modelo.Painel;

            painel.Controls.Add(IdDescricaoPadrao.UCPadraoView);
        }

        private void PreencheCamposFormatacao(ModelTelaPadrao modelo)
        {
            this.IdDescricaoPadrao.Id.Text = modelo.Id is null ? "" : modelo.Id.Value.ToString();
            this.IdDescricaoPadrao.Descricao.Text = modelo.Descricao;
            this.IdDescricaoPadrao.DescricaoLabel.Text = (modelo.DescricaoLabel ?? this.IdDescricaoPadrao.DescricaoLabel.Text) + ":";

            this.IdDescricaoPadrao.Grupo.Width = modelo.Painel.Width - 10;
            this.IdDescricaoPadrao.UCPadraoView.Width = modelo.Painel.Width;
            this.IdDescricaoPadrao.Descricao.Width = modelo.Painel.Width - 83;
        }
    }
}
