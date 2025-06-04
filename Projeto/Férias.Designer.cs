namespace Projeto
{
    partial class Férias
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BFeriasAdd = new System.Windows.Forms.Button();
            this.BFeriasVoltar = new System.Windows.Forms.Button();
            this.TBFeriasFim = new System.Windows.Forms.TextBox();
            this.TBFériasIn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data Fim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Data Início";
            // 
            // BFeriasAdd
            // 
            this.BFeriasAdd.Location = new System.Drawing.Point(36, 196);
            this.BFeriasAdd.Name = "BFeriasAdd";
            this.BFeriasAdd.Size = new System.Drawing.Size(75, 23);
            this.BFeriasAdd.TabIndex = 11;
            this.BFeriasAdd.Text = "Adicionar";
            this.BFeriasAdd.UseVisualStyleBackColor = true;
            // 
            // BFeriasVoltar
            // 
            this.BFeriasVoltar.Location = new System.Drawing.Point(157, 196);
            this.BFeriasVoltar.Name = "BFeriasVoltar";
            this.BFeriasVoltar.Size = new System.Drawing.Size(75, 23);
            this.BFeriasVoltar.TabIndex = 10;
            this.BFeriasVoltar.Text = "Voltar";
            this.BFeriasVoltar.UseVisualStyleBackColor = true;
            // 
            // TBFeriasFim
            // 
            this.TBFeriasFim.Location = new System.Drawing.Point(36, 115);
            this.TBFeriasFim.Name = "TBFeriasFim";
            this.TBFeriasFim.Size = new System.Drawing.Size(196, 22);
            this.TBFeriasFim.TabIndex = 9;
            // 
            // TBFériasIn
            // 
            this.TBFériasIn.Location = new System.Drawing.Point(36, 46);
            this.TBFériasIn.Name = "TBFériasIn";
            this.TBFériasIn.Size = new System.Drawing.Size(196, 22);
            this.TBFériasIn.TabIndex = 8;
            // 
            // Férias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 244);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BFeriasAdd);
            this.Controls.Add(this.BFeriasVoltar);
            this.Controls.Add(this.TBFeriasFim);
            this.Controls.Add(this.TBFériasIn);
            this.Name = "Férias";
            this.Text = "Férias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BFeriasAdd;
        private System.Windows.Forms.Button BFeriasVoltar;
        private System.Windows.Forms.TextBox TBFeriasFim;
        private System.Windows.Forms.TextBox TBFériasIn;
    }
}
