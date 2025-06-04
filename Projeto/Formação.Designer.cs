namespace Projeto
{
    partial class Formação
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
            this.CBForm = new System.Windows.Forms.ComboBox();
            this.BFormExit = new System.Windows.Forms.Button();
            this.BAddFormação = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBForm
            // 
            this.CBForm.FormattingEnabled = true;
            this.CBForm.Items.AddRange(new object[] {
            "Incêndio Urbanos",
            "Incêndios Florestais",
            "Salvamento e Desencarceramento",
            "Salvamento Aquático",
            "Formação e Treinamento",
            "Comando e Gestão"});
            this.CBForm.Location = new System.Drawing.Point(55, 54);
            this.CBForm.Name = "CBForm";
            this.CBForm.Size = new System.Drawing.Size(206, 24);
            this.CBForm.TabIndex = 33;
            // 
            // BFormExit
            // 
            this.BFormExit.Location = new System.Drawing.Point(186, 112);
            this.BFormExit.Name = "BFormExit";
            this.BFormExit.Size = new System.Drawing.Size(75, 24);
            this.BFormExit.TabIndex = 37;
            this.BFormExit.Text = "Voltar";
            this.BFormExit.UseVisualStyleBackColor = true;
            // 
            // BAddFormação
            // 
            this.BAddFormação.Location = new System.Drawing.Point(55, 112);
            this.BAddFormação.Name = "BAddFormação";
            this.BAddFormação.Size = new System.Drawing.Size(115, 24);
            this.BAddFormação.TabIndex = 36;
            this.BAddFormação.Text = "Adicionar";
            this.BAddFormação.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Formações";
            // 
            // Formação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 183);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BFormExit);
            this.Controls.Add(this.BAddFormação);
            this.Controls.Add(this.CBForm);
            this.Name = "Formação";
            this.Text = "Formação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBForm;
        private System.Windows.Forms.Button BFormExit;
        private System.Windows.Forms.Button BAddFormação;
        private System.Windows.Forms.Label label9;
    }
}
