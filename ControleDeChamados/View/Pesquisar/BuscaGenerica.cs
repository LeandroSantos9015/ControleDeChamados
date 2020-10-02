using Interfaces.Pesquisar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorCasaDeCarnes.Pesquisar
{
    public partial class BuscaGenerica : Form, IPesquisar
    {
        public BuscaGenerica()
        {
            InitializeComponent();
        }

        public TextBox TxtPesquisar { get { return this.txtPesquisar; } }

        public DataGridView GrdPesquisar { get { return this.grdPesquisar; } }

        public Form TelaPesquisa { get { return this; } }

       
    }
}
