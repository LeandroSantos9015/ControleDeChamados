﻿using Interfaces.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Cadastros
{
    public partial class FrmPrioridade : Form, IPrioridade
    {
        public FrmPrioridade() { InitializeComponent(); }

        public FlowLayoutPanel Painel => flwPanel;

        public Form Formulario => this;

       
    }
}
