using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void DelegarEventos()
        {
            
        }
    }
}
