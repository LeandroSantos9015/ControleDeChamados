using Enumeradores;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosSistema;

namespace Controladores
{
    public abstract class CtrlBotoes : AValidacaoMensagens
    {
        public ITelaPrincipal PrincipalView { get; set; }

        public bool TelaPDVEstaFechada = true;

        public bool[] ultimoEventoBotoes = new bool[] { true, false, true, false, false, false, false, true, true };

        //public CtrlBotoes(ITelaPrincipal PrincipalView) { }

        //public CtrlBotoes(ITelaPrincipal PrincipalView, Form formulario, bool[] botoesPai)
        //{
        //    DelegarEventosPai(PrincipalView);

        //    formulario.FormClosing += FormClosing;

        //    formulario.Tag = botoesPai;

        //    formulario.Activated += FormAtivado;

        //    formulario.Deactivate += FormDesativado;
        //}

        //private void FormAtivado(object sender, EventArgs e)
        //{
        //    bool[] v = (sender as Form).Tag as bool[];

        //    HabilitaDesabilitaBotoesPai(new bool[] { v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7] }, PrincipalView);

        //    DelegarEventosPai(PrincipalView);

        //}

        //private void FormDesativado(object sender, EventArgs e)
        //{
        //    bool[] v = (sender as Form).Tag as bool[];

        //    HabilitaDesabilitaBotoesPai(new bool[] { v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7] }, PrincipalView);

        //    RetirarEventosPai(PrincipalView);
        //}


        #region Métodos para manipulação entre form filho e pai

        public virtual void HabilitaDesabilitaBotoesPai(bool[] valor, ITelaPrincipal PrincipalView)
        {
            this.PrincipalView = PrincipalView;

            this.PrincipalView.BtnNovo.Enabled = valor[0];

            this.PrincipalView.BtnCancelar.Enabled = valor.Length > 1 ? valor[1] : false;

            this.PrincipalView.BtnPesquisar.Enabled = valor.Length > 2 ? valor[2] : false;

            this.PrincipalView.BtnConfirmar.Enabled = valor.Length > 3 ? valor[3] : false;

            this.PrincipalView.BtnSalvar.Enabled = valor.Length > 4 ? valor[4] : false;

            this.PrincipalView.BtnExcluir.Enabled = valor.Length > 5 ? valor[5] : false;

            this.PrincipalView.BtnImprimir.Enabled = valor.Length > 6 ? valor[6] : false;

            this.PrincipalView.BtnAjuda.Enabled = valor.Length > 7 ? valor[7] : false;

            this.PrincipalView.CmbAtivo.Enabled = valor.Length > 8 ? valor[8] : false;

            this.PrincipalView.CmbAtivo.Enabled = valor[0];

        }

        public void DelegarEventosPai(ITelaPrincipal PrincipalView)
        {
            this.PrincipalView = PrincipalView;

            this.PrincipalView.BtnNovo.Click += BtnNovo_Click;

            this.PrincipalView.BtnCancelar.Click += BtnCancelar_Click;

            this.PrincipalView.BtnPesquisar.Click += BtnPesquisar_Click;

            this.PrincipalView.BtnConfirmar.Click += BtnConfirmar_Click;

            this.PrincipalView.BtnSalvar.Click += BtnSalvar_Click;

            this.PrincipalView.BtnExcluir.Click += BtnExcluir_Click;

            this.PrincipalView.BtnImprimir.Click += BtnImprimir_Click;

            this.PrincipalView.BtnAjuda.Click += BtnAjuda_Click;
            
        }

        public void RetirarEventosPai(ITelaPrincipal PrincipalView)
        {
            this.PrincipalView.BtnNovo.Click -= BtnNovo_Click;

            this.PrincipalView.BtnCancelar.Click -= BtnCancelar_Click;

            this.PrincipalView.BtnPesquisar.Click -= BtnPesquisar_Click;

            this.PrincipalView.BtnConfirmar.Click -= BtnConfirmar_Click;

            this.PrincipalView.BtnSalvar.Click -= BtnSalvar_Click;

            this.PrincipalView.BtnExcluir.Click -= BtnExcluir_Click;

            this.PrincipalView.BtnImprimir.Click -= BtnImprimir_Click;

            this.PrincipalView.BtnAjuda.Click -= BtnAjuda_Click;
        }


        #region Em teste
        public void DefinirComportamentoEventos(object[] componente)
        {

            int qtdComponentes = componente.Length;


            IList<TextBox> Text = new List<TextBox>();
            IList<ComboBox> Combo = new List<ComboBox>();



            // Casting de adaptação
            for (int i = 0; i < qtdComponentes; i++)
            {
                if ((componente[i] as TextBox) != null)
                    Text.Add(componente[i] as TextBox);

                if ((componente[i] as ComboBox) != null)
                    Combo.Add(componente[i] as ComboBox);


            }

            EventoComponente(Text.Cast<Object>().ToList());

            EventoComponente(Combo.Cast<Object>().ToList());

        }

        private void EventoComponente(IList<Object> componentes)
        {
            // casting
            if (componentes.GetType().Equals("ComboBox"))
            {
                foreach (ComboBox cmb in componentes)
                {

                }
            }

            if (componentes.GetType().Equals("TextBox"))
            {
                foreach (TextBox txt in componentes)
                {
                    txt.KeyPress += Validadores.ApenasNumeros;
                }
            }





        }
        #endregion


        public object KeyDown_Pai()
        {
            throw new NotImplementedException();
        }

        private void KeyDown_Pai(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    //notaFiscalToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F7:
                    // clienteToolStripMenuItem1_Click(sender, e);
                    break;
                case Keys.F8:
                    // contabilistaToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F9:
                    // empresaToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F2:
                    // gerarArquivoToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F3:
                    //  imprimirToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F4:
                    //  saldoISSToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F12:
                    //  sairToolStripMenuItem_Click(sender, e);
                    break;
            }

        }

        public virtual void RetirarEventosPai()
        {
            this.PrincipalView.BtnNovo.Click -= BtnNovo_Click;

            this.PrincipalView.BtnCancelar.Click -= BtnCancelar_Click;

            this.PrincipalView.BtnPesquisar.Click -= BtnPesquisar_Click;

            this.PrincipalView.BtnConfirmar.Click -= BtnConfirmar_Click;

            this.PrincipalView.BtnSalvar.Click -= BtnSalvar_Click;

            this.PrincipalView.BtnExcluir.Click -= BtnExcluir_Click;

            this.PrincipalView.BtnImprimir.Click -= BtnImprimir_Click;

            this.PrincipalView.BtnAjuda.Click -= BtnAjuda_Click;
        }

        public int HabilitaDesabilitaSequenciaBotoes(TextBox texto)
        {
            if (this.PrincipalView.BtnNovo.Pressed)
            {
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { false, true, false, false, true, false, false, true, true }, PrincipalView);

                texto.Enabled = false;
                texto.Text = String.Empty;
            }

            else if (this.PrincipalView.BtnCancelar.Pressed)
            {
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { true, false, true, false, false, false, false, true, true }, PrincipalView);
                texto.Enabled = true;
                texto.Text = String.Empty;
            }

            else if (this.PrincipalView.BtnPesquisar.Pressed)
            {
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { false, true, false, false, true, true, false, true, true }, PrincipalView);
                texto.Enabled = false;
            }

            else if (this.PrincipalView.BtnConfirmar.Pressed)
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { false, true, false, false, true, false, false, true, true }, PrincipalView);

            else if (this.PrincipalView.BtnSalvar.Pressed)
            {
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { true, false, true, false, false, false, false, true, true }, PrincipalView);
                texto.Enabled = true;
            }

            else if (this.PrincipalView.BtnExcluir.Pressed)
            {
                HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { true, false, true, false, false, false, false, true, true }, PrincipalView);
                texto.Enabled = true;
            }

            //else if (this.PrincipalView.BtnImprimir.Pressed)
            //    HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { false, true, false, false, true, false, false, true });

            //else if (this.PrincipalView.BtnAjuda.Pressed)
            //    HabilitaDesabilitaBotoesPai(ultimoEventoBotoes = new bool[] { false, true, false, false, true, false, false, true });

            return (int)(EAtivo)this.PrincipalView.CmbAtivo.ComboBox.SelectedValue;
        }

        public virtual void BtnImprimir_Click(object sender, EventArgs e)
        {
            Alerta("", "Função não implementada!");

        }

        public virtual void BtnExcluir_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnSalvar_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnConfirmar_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnPesquisar_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnCancelar_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnNovo_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        public virtual void BtnAjuda_Click(object sender, EventArgs e) { Alerta(this.PrincipalView.PrincipalView.Text, "Função não implementada!"); }

        #endregion

        public void MensagemExclusaoLogica()
        {
            MessageBox.Show("Ao excluir, o sistema apenas irá deixar o cadastro inativo\n" +
                            "Podendo ser localizado posteriormente pelo filtro acima\n" +
                            "Selecionando a opção TODOS ou INATIVO");
        }

        //Metodos overrides para serem sobrescritos
        public virtual void AntesSalvar() { }


        public virtual void FormClosing(object sender, FormClosingEventArgs e)
        {
            bool btnNovo = this.PrincipalView.BtnNovo.Enabled;
            bool btnSalvar = this.PrincipalView.BtnSalvar.Enabled;

            if (btnNovo && !btnSalvar) return;


            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = Pergunta("Cadastros", "O formulário está em modo de edição\nDeseja fechar sem salvar?");  //MessageBox.Show(this, "Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }



        // teste novo

        //protected void FormAtivado(object sender, EventArgs e)
        //{
        //    HabilitaDesabilitaBotoesPai(ultimoEventoBotoes, PrincipalView);
        //    DelegarEventosPai(PrincipalView);

        //}

        //protected void FormDesativado(object sender, EventArgs e)
        //{
        //    HabilitaDesabilitaBotoesPai(new bool[] { false, false, false, false, false, false, false, false }, PrincipalView);
        //    RetirarEventosPai(PrincipalView);
        //}

    }
}
