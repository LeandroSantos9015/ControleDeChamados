namespace View.UserControlPadrao
{
    partial class UCPadrao
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.grp = new System.Windows.Forms.GroupBox();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(67, 44);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(331, 20);
            this.txtDescricao.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(67, 18);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 20);
            this.txtId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(3, 47);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(58, 13);
            this.descLabel.TabIndex = 1;
            this.descLabel.Text = "Descrição:";
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtId);
            this.grp.Controls.Add(this.descLabel);
            this.grp.Controls.Add(this.txtDescricao);
            this.grp.Controls.Add(this.label1);
            this.grp.Location = new System.Drawing.Point(3, -1);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(407, 72);
            this.grp.TabIndex = 2;
            this.grp.TabStop = false;
            this.grp.Text = "Identificação";
            // 
            // UCPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp);
            this.Name = "UCPadrao";
            this.Size = new System.Drawing.Size(413, 74);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.GroupBox grp;
    }
}
