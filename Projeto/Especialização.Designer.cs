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
            this.CBEsp.Location = new System.Drawing.Point(64, 71);
            this.CBEsp.Name = "CBEsp";
            this.CBEsp.Size = new System.Drawing.Size(206, 24);
            this.CBEsp.TabIndex = 30;
            // 
            // BAddEsp
            // 
            this.BAddEsp.Location = new System.Drawing.Point(64, 135);
            this.BAddEsp.Name = "BAddEsp";
            this.BAddEsp.Size = new System.Drawing.Size(114, 24);
            this.BAddEsp.TabIndex = 31;
            this.BAddEsp.Text = "Adicionar";
            this.BAddEsp.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Especializações";
            // 
            // BReturnEsp
            // 
            this.BReturnEsp.Location = new System.Drawing.Point(195, 135);
            this.BReturnEsp.Name = "BReturnEsp";
            this.BReturnEsp.Size = new System.Drawing.Size(75, 24);
            this.BReturnEsp.TabIndex = 35;
            this.BReturnEsp.Text = "Voltar";
            this.BReturnEsp.UseVisualStyleBackColor = true;
            // 
            // Especialização
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 214);
            this.Controls.Add(this.BReturnEsp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BAddEsp);
            this.Controls.Add(this.CBEsp);
            this.Name = "Especialização";
            this.Text = "Especialização";
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
