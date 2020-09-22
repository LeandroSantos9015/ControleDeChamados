namespace Mensagens.Mensagem.UserControls.SimNao
{
    partial class UCPergunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPergunta));
            this.btnNao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.reciclar = new System.Windows.Forms.Label();
            this.btnSim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNao
            // 
            resources.ApplyResources(this.btnNao, "btnNao");
            this.btnNao.Name = "btnNao";
            this.btnNao.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
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
            // lblDescricao
            // 
            resources.ApplyResources(this.lblDescricao, "lblDescricao");
            this.lblDescricao.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblDescricao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDescricao.ForeColor = System.Drawing.Color.White;
            this.lblDescricao.Name = "lblDescricao";
            // 
            // reciclar
            // 
            resources.ApplyResources(this.reciclar, "reciclar");
            this.reciclar.BackColor = System.Drawing.Color.DarkGreen;
            this.reciclar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reciclar.ForeColor = System.Drawing.Color.Blue;
            this.reciclar.Name = "reciclar";
            // 
            // btnSim
            // 
            resources.ApplyResources(this.btnSim, "btnSim");
            this.btnSim.Name = "btnSim";
            this.btnSim.UseVisualStyleBackColor = true;
            // 
            // UCPergunta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reciclar);
            this.Name = "UCPergunta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label reciclar;
        private System.Windows.Forms.Button btnSim;


    }
}
