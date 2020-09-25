using Controladores.TelaPadrao;
using Interfaces;
using Interfaces.Cadastros;
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
    public class CtrlDepartamento : CtrlTelaPadrao
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

        public CtrlDepartamento(ITelaPrincipal Pai) : base(Pai)
        {
            this.DelegarEventos();

        }

        private void DelegarEventos()
        {
            
        }
    }
}
