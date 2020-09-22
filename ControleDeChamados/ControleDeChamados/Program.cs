using Controladores;
using Controladores.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeChamados
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                CtrlPrincipal ctrl = new CtrlPrincipal();
                Application.EnableVisualStyles();
                Application.Run(ctrl.Principal.PrincipalView);
            }
            catch (Exception e)
            {
                //TODO Ainda falta implementar as caixas de dialogo mais amigáveis e talvez colocar em um outro projeto
                CtrlExcecoes.Excecao(e, e.Source);
            }
        }
    }
}