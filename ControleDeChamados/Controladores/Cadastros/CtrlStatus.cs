using Controladores.TelaPadrao;
using Interfaces;
using Interfaces.Cadastros;
using Modelos.Cadastro;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Cadastros;

namespace Controladores.Cadastros
{
    public class CtrlStatus : CtrlTelaPadrao
    {
        public IDepartamento DepartamentoView = new FrmDepartamento();

        public override ModelTelaPadrao ModeloTelaPadrao =>
           new ModelTelaPadrao
           {
               Formulario = this.DepartamentoView,
               Descricao = "Departamento",
               DescricaoLabel = "Descrição",
               Id = null
           };

        public CtrlStatus(ITelaPrincipal Pai) : base(Pai)
        {
            this.DelegarEventos();

        }

        private void DelegarEventos()
        {

        }

        public override object ValoresTelaPadrao()
        {
            ModelTelaPadrao tela = base.TelaParaObjeto();

            return new ModeloStatus
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
            };
        }
    }
}
