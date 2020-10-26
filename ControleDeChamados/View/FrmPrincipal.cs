using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FrmPrincipal : Form, ITelaPrincipal
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public Form PrincipalView => this;

        public ToolStripMenuItem MudarUsuarioToolStripMenuItem => this.mudarUsuarioToolStripMenuItem;
        public ToolStripMenuItem ChamadosToolStripMenuItem => this.chamadosToolStripMenuItem;
        public ToolStripMenuItem CategoriaToolStripMenuItem => this.categoriaToolStripMenuItem;
        public ToolStripMenuItem DepartamentoToolStripMenuItem => this.departamentoToolStripMenuItem;
        public ToolStripMenuItem StatusToolStripMenuItem => this.statusToolStripMenuItem;
        public ToolStripMenuItem EtapaToolStripMenuItem => this.etapaToolStripMenuItem;


        // Menu de Manipulação

        public ToolStrip StripBotoes { get { return this.toolStrip1; } }
        public ToolStripButton BtnNovo { get { return this.btnNovo1; } }
        public ToolStripButton BtnCancelar { get { return this.btnCancelar1; } }
        public ToolStripButton BtnPesquisar { get { return this.btnPesquisar1; } }
        public ToolStripButton BtnConfirmar { get { return this.btnConfirmar1; } }
        public ToolStripButton BtnSalvar { get { return this.btnSalvar1; } }
        public ToolStripButton BtnExcluir { get { return this.btnExcluir1; } }
        public ToolStripButton BtnImprimir { get { return this.btnImprimir1; } }
        public ToolStripButton BtnAjuda { get { return this.btnAjuda1; } }
        public ToolStripComboBox CmbAtivo { get { return this.cmbAtivo; } }

        // Status Strip
        public ToolStripStatusLabel LblLogin { get { return this.labelLogin; } }
        public ToolStripStatusLabel LblEmpresa { get { return this.labelEmpresa; } }
        public ToolStripStatusLabel LblCnpj { get { return this.labelCnpj; } }
        public ToolStripStatusLabel LblData { get { return this.labelData; } }

    }
}
