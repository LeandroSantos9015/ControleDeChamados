namespace View.Chamados
{
    partial class UCInteracoes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.lblInteracao = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(72, 3);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(89, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome do Usuário";
            // 
            // lblInteracao
            // 
            this.lblInteracao.AutoSize = true;
            this.lblInteracao.Location = new System.Drawing.Point(6, 3);
            this.lblInteracao.Name = "lblInteracao";
            this.lblInteracao.Size = new System.Drawing.Size(55, 13);
            this.lblInteracao.TabIndex = 2;
            this.lblInteracao.Text = "Nº. 99999";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(9, 19);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textEdit1.Size = new System.Drawing.Size(372, 40);
            this.textEdit1.TabIndex = 4;
            this.textEdit1.UseOptimizedRendering = true;
            // 
            // UCInteracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblInteracao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textEdit1);
            this.Name = "UCInteracoes";
            this.Size = new System.Drawing.Size(388, 71);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblInteracao;
        private DevExpress.XtraEditors.MemoEdit textEdit1;
    }
}
