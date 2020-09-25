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
                Formulario = this.ChamadoView,
                Descricao = "Descrição do chamado aqui",
                DescricaoLabel = "Assunto",
                Id = 9992111
            };

        public CtrlChamado(ITelaPrincipal Pai) : base(Pai)
        {
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
            //this.ChamadoView.FlwInteracoes.Controls.Add(interacoes2.InteracaoView.UCInteracaoView);

            int tamanho = this.ChamadoView.FlwInteracoes.VerticalScroll.Maximum - this.ChamadoView.FlwInteracoes.VerticalScroll.LargeChange;

            //bug --> tem q setar 2 vezes pra funcionar
            this.ChamadoView.FlwInteracoes.VerticalScroll.Value = tamanho;
            this.ChamadoView.FlwInteracoes.VerticalScroll.Value = tamanho;

        }

        public override void BtnNovo_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

    }
}