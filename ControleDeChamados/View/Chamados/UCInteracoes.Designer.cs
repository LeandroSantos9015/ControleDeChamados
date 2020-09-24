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
            this.label = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(3, 3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(19, 13);
            this.label.TabIndex = 1;
            this.label.Text = "...";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(3, 19);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textEdit1.Size = new System.Drawing.Size(359, 18);
            this.textEdit1.TabIndex = 4;
            this.textEdit1.UseOptimizedRendering = true;
            // 
            // UCInteracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label);
            this.Name = "UCInteracoes";
            this.Size = new System.Drawing.Size(365, 40);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private DevExpress.XtraEditors.MemoEdit textEdit1;
    }
}
