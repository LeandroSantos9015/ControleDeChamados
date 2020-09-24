using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces.UserControls;
using DevExpress.XtraEditors;

namespace View.Chamados
{
    public partial class UCInteracoes : UserControl, IUCInteracao
    {
        public UCInteracoes() { InitializeComponent(); }

        private Int64? id { get; set; }

        public UserControl UCInteracaoView => this;

        public Label Label => label;

        public MemoEdit TextDesc => textEdit1;

        public Int64? Id => this.id;
    }
}
