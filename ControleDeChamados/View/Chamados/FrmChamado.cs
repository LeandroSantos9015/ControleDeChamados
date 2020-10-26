using Interfaces.Chamados;
using Interfaces.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Chamados
{
    public partial class FrmChamado : Form, IChamado
    {
        public FrmChamado() { InitializeComponent(); }

        public Form Formulario => this;

        public FlowLayoutPanel Painel => this.flwPrincipal;

        public FlowLayoutPanel FlwInteracoes => this.flwInteracoes;

        public TextBox TxtAbertoPor => this.txtAbertoPor;

        public ComboBox CbmOperador => this.cbmOperador;

        public ComboBox CbmPrioridade => this.cbmPrioridade;

        public ComboBox CbmEtapa => this.cbmEtapa;

        public ComboBox CbmStatus => this.cbmStatus;

        public ComboBox CbmCategoria => this.cbmCategoria;

        public DateTimePicker DataAbertura => this.dteAbertura;

        public DateTimePicker DataSolucao => this.dteSolucao;

        public Button BtnAtender => this.btnAtender;

        public Button BtnInteragir => this.btnInteragir;
    }
}
