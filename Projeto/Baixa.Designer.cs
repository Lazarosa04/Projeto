namespace Projeto
{
    partial class Baixa
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
            this.TBBaixaDataIn = new System.Windows.Forms.TextBox();
            this.TBBaixaDataFim = new System.Windows.Forms.TextBox();
            this.BBaixaVoltar = new System.Windows.Forms.Button();
            this.BBaixaAdd = new System.Windows.Forms.Button();
            this.RBBaixaRazao = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBBaixaDataIn
            // 
            this.TBBaixaDataIn.Location = new System.Drawing.Point(96, 106);
            this.TBBaixaDataIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBBaixaDataIn.Name = "TBBaixaDataIn";
            this.TBBaixaDataIn.Size = new System.Drawing.Size(292, 31);
            this.TBBaixaDataIn.TabIndex = 0;
            // 
            // TBBaixaDataFim
            // 
            this.TBBaixaDataFim.Location = new System.Drawing.Point(96, 214);
            this.TBBaixaDataFim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBBaixaDataFim.Name = "TBBaixaDataFim";
            this.TBBaixaDataFim.Size = new System.Drawing.Size(292, 31);
            this.TBBaixaDataFim.TabIndex = 1;
            // 
            // BBaixaVoltar
            // 
            this.BBaixaVoltar.Location = new System.Drawing.Point(278, 606);
            this.BBaixaVoltar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BBaixaVoltar.Name = "BBaixaVoltar";
            this.BBaixaVoltar.Size = new System.Drawing.Size(112, 36);
            this.BBaixaVoltar.TabIndex = 2;
            this.BBaixaVoltar.Text = "Voltar";
            this.BBaixaVoltar.UseVisualStyleBackColor = true;
            this.BBaixaVoltar.Click += new System.EventHandler(this.BBaixaVoltar_Click_1);
            // 
            // BBaixaAdd
            // 
            this.BBaixaAdd.Location = new System.Drawing.Point(96, 606);
            this.BBaixaAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BBaixaAdd.Name = "BBaixaAdd";
            this.BBaixaAdd.Size = new System.Drawing.Size(112, 36);
            this.BBaixaAdd.TabIndex = 3;
            this.BBaixaAdd.Text = "Adicionar";
            this.BBaixaAdd.UseVisualStyleBackColor = true;
            this.BBaixaAdd.Click += new System.EventHandler(this.BBaixaAdd_Click);
            // 
            // RBBaixaRazao
            // 
            this.RBBaixaRazao.Location = new System.Drawing.Point(96, 306);
            this.RBBaixaRazao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBBaixaRazao.Name = "RBBaixaRazao";
            this.RBBaixaRazao.Size = new System.Drawing.Size(292, 257);
            this.RBBaixaRazao.TabIndex = 4;
            this.RBBaixaRazao.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Razão";
            // 
            // Baixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 703);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RBBaixaRazao);
            this.Controls.Add(this.BBaixaAdd);
            this.Controls.Add(this.BBaixaVoltar);
            this.Controls.Add(this.TBBaixaDataFim);
            this.Controls.Add(this.TBBaixaDataIn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Baixa";
            this.Text = "Baixa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBBaixaDataIn;
        private System.Windows.Forms.TextBox TBBaixaDataFim;
        private System.Windows.Forms.Button BBaixaVoltar;
        private System.Windows.Forms.Button BBaixaAdd;
        private System.Windows.Forms.RichTextBox RBBaixaRazao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
