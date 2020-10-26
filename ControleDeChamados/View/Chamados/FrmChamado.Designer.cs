namespace View.Chamados
{
    partial class FrmChamado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.flwInteracoes = new System.Windows.Forms.FlowLayoutPanel();
            this.flwPrincipal = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAbertoPor = new System.Windows.Forms.TextBox();
            this.cbmOperador = new System.Windows.Forms.ComboBox();
            this.cbmEtapa = new System.Windows.Forms.ComboBox();
            this.cbmStatus = new System.Windows.Forms.ComboBox();
            this.cbmCategoria = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbmPrioridade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dteSolucao = new System.Windows.Forms.DateTimePicker();
            this.dteAbertura = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInteragir = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.grp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.flwInteracoes);
            this.grp1.Location = new System.Drawing.Point(153, 188);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(394, 202);
            this.grp1.TabIndex = 0;
            this.grp1.TabStop = false;
            this.grp1.Text = "Interações";
            // 
            // flwInteracoes
            // 
            this.flwInteracoes.AutoScroll = true;
            this.flwInteracoes.Location = new System.Drawing.Point(1, 13);
            this.flwInteracoes.Name = "flwInteracoes";
            this.flwInteracoes.Size = new System.Drawing.Size(387, 183);
            this.flwInteracoes.TabIndex = 1;
            // 
            // flwPrincipal
            // 
            this.flwPrincipal.Location = new System.Drawing.Point(6, 0);
            this.flwPrincipal.Name = "flwPrincipal";
            this.flwPrincipal.Size = new System.Drawing.Size(545, 82);
            this.flwPrincipal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Etapa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data de Abertura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Previsão de Solução:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Aberto por:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Operador:";
            // 
            // txtAbertoPor
            // 
            this.txtAbertoPor.Location = new System.Drawing.Point(71, 13);
            this.txtAbertoPor.Name = "txtAbertoPor";
            this.txtAbertoPor.Size = new System.Drawing.Size(458, 20);
            this.txtAbertoPor.TabIndex = 3;
            // 
            // cbmOperador
            // 
            this.cbmOperador.FormattingEnabled = true;
            this.cbmOperador.Location = new System.Drawing.Point(71, 39);
            this.cbmOperador.Name = "cbmOperador";
            this.cbmOperador.Size = new System.Drawing.Size(277, 21);
            this.cbmOperador.TabIndex = 4;
            // 
            // cbmEtapa
            // 
            this.cbmEtapa.FormattingEnabled = true;
            this.cbmEtapa.Location = new System.Drawing.Point(71, 66);
            this.cbmEtapa.Name = "cbmEtapa";
            this.cbmEtapa.Size = new System.Drawing.Size(106, 21);
            this.cbmEtapa.TabIndex = 4;
            // 
            // cbmStatus
            // 
            this.cbmStatus.FormattingEnabled = true;
            this.cbmStatus.Location = new System.Drawing.Point(242, 66);
            this.cbmStatus.Name = "cbmStatus";
            this.cbmStatus.Size = new System.Drawing.Size(106, 21);
            this.cbmStatus.TabIndex = 4;
            // 
            // cbmCategoria
            // 
            this.cbmCategoria.FormattingEnabled = true;
            this.cbmCategoria.Location = new System.Drawing.Point(423, 66);
            this.cbmCategoria.Name = "cbmCategoria";
            this.cbmCategoria.Size = new System.Drawing.Size(106, 21);
            this.cbmCategoria.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbmPrioridade);
            this.groupBox1.Controls.Add(this.cbmCategoria);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbmStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbmEtapa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbmOperador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAbertoPor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações";
            // 
            // cbmPrioridade
            // 
            this.cbmPrioridade.FormattingEnabled = true;
            this.cbmPrioridade.Location = new System.Drawing.Point(423, 39);
            this.cbmPrioridade.Name = "cbmPrioridade";
            this.cbmPrioridade.Size = new System.Drawing.Size(106, 21);
            this.cbmPrioridade.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Prioridade:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dteSolucao);
            this.groupBox2.Controls.Add(this.dteAbertura);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 113);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrega";
            // 
            // dteSolucao
            // 
            this.dteSolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteSolucao.Location = new System.Drawing.Point(11, 84);
            this.dteSolucao.Name = "dteSolucao";
            this.dteSolucao.Size = new System.Drawing.Size(105, 20);
            this.dteSolucao.TabIndex = 3;
            // 
            // dteAbertura
            // 
            this.dteAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteAbertura.Location = new System.Drawing.Point(11, 36);
            this.dteAbertura.Name = "dteAbertura";
            this.dteAbertura.Size = new System.Drawing.Size(105, 20);
            this.dteAbertura.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInteragir);
            this.groupBox3.Controls.Add(this.btnAtender);
            this.groupBox3.Location = new System.Drawing.Point(12, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 83);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estágios";
            // 
            // btnInteragir
            // 
            this.btnInteragir.Location = new System.Drawing.Point(9, 50);
            this.btnInteragir.Name = "btnInteragir";
            this.btnInteragir.Size = new System.Drawing.Size(120, 23);
            this.btnInteragir.TabIndex = 0;
            this.btnInteragir.Text = "Interagir";
            this.btnInteragir.UseVisualStyleBackColor = true;
            // 
            // btnAtender
            // 
            this.btnAtender.Location = new System.Drawing.Point(9, 19);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(120, 23);
            this.btnAtender.TabIndex = 0;
            this.btnAtender.Text = "Atender";
            this.btnAtender.UseVisualStyleBackColor = true;
            // 
            // FrmChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 394);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.flwPrincipal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp1);
            this.Name = "FrmChamado";
            this.Text = "Cadastro de Chamado";
            this.grp1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.FlowLayoutPanel flwPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAbertoPor;
        private System.Windows.Forms.ComboBox cbmOperador;
        private System.Windows.Forms.ComboBox cbmEtapa;
        private System.Windows.Forms.ComboBox cbmStatus;
        private System.Windows.Forms.ComboBox cbmCategoria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dteSolucao;
        private System.Windows.Forms.DateTimePicker dteAbertura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInteragir;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.FlowLayoutPanel flwInteracoes;
        private System.Windows.Forms.ComboBox cbmPrioridade;
        private System.Windows.Forms.Label label8;
    }
}