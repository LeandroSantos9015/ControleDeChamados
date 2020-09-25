namespace Customizados.Mensagem
{
    partial class FrmMensagem
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
            this.flwPainel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flwPainel
            // 
            this.flwPainel.AutoSize = true;
            this.flwPainel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flwPainel.BackColor = System.Drawing.Color.Transparent;
            this.flwPainel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwPainel.Location = new System.Drawing.Point(0, 0);
            this.flwPainel.Name = "flwPainel";
            this.flwPainel.Size = new System.Drawing.Size(269, 123);
            this.flwPainel.TabIndex = 0;
            // 
            // FrmMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(269, 123);
            this.Controls.Add(this.flwPainel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMensagem";
            this.Text = "Titulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwPainel;

    }
}