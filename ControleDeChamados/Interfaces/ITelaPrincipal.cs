using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces
{
    public interface ITelaPrincipal
    {

        Form PrincipalView { get; }

        // Menus
        ToolStripMenuItem MudarUsuarioToolStripMenuItem { get; }
        ToolStripMenuItem ChamadosToolStripMenuItem { get; }
        ToolStripMenuItem CategoriaToolStripMenuItem { get; }
        ToolStripMenuItem DepartamentoToolStripMenuItem { get; }


        // Botões Operações
        ToolStripButton BtnNovo { get; }
        ToolStripButton BtnCancelar { get; }
        ToolStripButton BtnPesquisar { get; }
        ToolStripButton BtnConfirmar { get; }
        ToolStripButton BtnSalvar { get; }
        ToolStripButton BtnExcluir { get; }
        ToolStripButton BtnImprimir { get; }
        ToolStripButton BtnAjuda { get; }
        ToolStripComboBox CmbAtivo { get; }

        // Status Strip
        ToolStripStatusLabel LblLogin { get; }
        ToolStripStatusLabel LblEmpresa { get; }
        ToolStripStatusLabel LblCnpj { get; }
        ToolStripStatusLabel LblData { get; }


    }
}
