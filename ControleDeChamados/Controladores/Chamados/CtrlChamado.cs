using Controladores.TelaPadrao;
using Interfaces;
using Interfaces.Chamados;
using Interfaces.UserControls;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Chamados;

namespace Controladores.Chamados
{
    public class CtrlChamado : CtrlTelaPadrao
    {
        public IChamado ChamadoView = new FrmChamado();

        public override ModelTelaPadrao ModeloTelaPadrao =>
            new ModelTelaPadrao
            {
                Painel = this.ChamadoView.FlwPrincipal,
                Descricao = "Descrição do chamado aqui",
                DescricaoLabel = "Assunto",
                Id = 9992111
            };

        public CtrlChamado(ITelaPrincipal Pai) : base()
        {
            this.ChamadoView.ChamadosView.StartPosition = FormStartPosition.CenterScreen;

            this.ChamadoView.ChamadosView.MdiParent = Pai.PrincipalView;

            this.ChamadoView.ChamadosView.Show();

            this.TelaInteracoes();

            this.DelegarEventos();

        }

        private void DelegarEventos()
        {

        }

        private void TelaInteracoes()
        {
            CtrlInteracoes interacoes = new CtrlInteracoes(null);
            this.ChamadoView.FlwInteracoes.Controls.Add(interacoes.InteracaoView.UCInteracaoView);
        }
    }
}