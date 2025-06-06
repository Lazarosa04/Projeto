namespace Projeto
{
    partial class Especialização
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
            this.CBEsp = new System.Windows.Forms.ComboBox();
            this.BAddEsp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.BReturnEsp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBEsp
            // 
            this.CBEsp.FormattingEnabled = true;
            this.CBEsp.Items.AddRange(new object[] {
            "Incêndio Urbanos",
            "Incêndios Florestais",
            "Salvamento e Desencarceramento",
            "Salvamento Aquático",
            "Formação e Treinamento",
            "Comando e Gestão"});
            this.CBEsp.Location = new System.Drawing.Point(96, 111);
            this.CBEsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBEsp.Name = "CBEsp";
            this.CBEsp.Size = new System.Drawing.Size(307, 33);
            this.CBEsp.TabIndex = 30;
            // 
            // BAddEsp
            // 
            this.BAddEsp.Location = new System.Drawing.Point(96, 211);
            this.BAddEsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BAddEsp.Name = "BAddEsp";
            this.BAddEsp.Size = new System.Drawing.Size(171, 38);
            this.BAddEsp.TabIndex = 31;
            this.BAddEsp.Text = "Adicionar";
            this.BAddEsp.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(92, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "Especializações";
            // 
            // BReturnEsp
            // 
            this.BReturnEsp.Location = new System.Drawing.Point(292, 211);
            this.BReturnEsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BReturnEsp.Name = "BReturnEsp";
            this.BReturnEsp.Size = new System.Drawing.Size(112, 38);
            this.BReturnEsp.TabIndex = 35;
            this.BReturnEsp.Text = "Voltar";
            this.BReturnEsp.UseVisualStyleBackColor = true;
            // 
            // Especialização
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 334);
            this.Controls.Add(this.BReturnEsp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BAddEsp);
            this.Controls.Add(this.CBEsp);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Especialização";
            this.Text = "Especialização";
            this.Load += new System.EventHandler(this.Especialização_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBEsp;
        private System.Windows.Forms.Button BAddEsp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BReturnEsp;
    }
}
