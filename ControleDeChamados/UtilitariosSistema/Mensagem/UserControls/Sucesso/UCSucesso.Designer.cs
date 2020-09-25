namespace Customizados.Mensagem.UserControls.Sucesso
{
    partial class UCSucesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSucesso));
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDdescricao = new System.Windows.Forms.Label();
            this.reciclar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.DarkGreen;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            resources.ApplyResources(this.label1, "label1");
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.MintCream;
            this.label1.Name = "label1";
            // 
            // lblDdescricao
            // 
            resources.ApplyResources(this.lblDdescricao, "lblDdescricao");
            this.lblDdescricao.BackColor = System.Drawing.Color.DarkGreen;
            this.lblDdescricao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDdescricao.ForeColor = System.Drawing.Color.White;
            this.lblDdescricao.Name = "lblDdescricao";
            // 
            // reciclar
            // 
            resources.ApplyResources(this.reciclar, "reciclar");
            this.reciclar.BackColor = System.Drawing.Color.DarkGreen;
            this.reciclar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reciclar.ForeColor = System.Drawing.Color.Blue;
            this.reciclar.Name = "reciclar";
            // 
            // UCSucesso
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDdescricao);
            this.Controls.Add(this.reciclar);
            this.Name = "UCSucesso";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDdescricao;
        private System.Windows.Forms.Label reciclar;


    }
}
