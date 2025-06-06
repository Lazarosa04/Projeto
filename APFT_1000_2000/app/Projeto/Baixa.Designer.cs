namespace Projeto
{
    partial class Baixa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.BBaixaVoltar = new System.Windows.Forms.Button();
            this.BBaixaAdd = new System.Windows.Forms.Button();
            this.RBBaixaRazao = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(96, 106);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(292, 31);
            this.dateTimePickerInicio.TabIndex = 0;
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFim.Location = new System.Drawing.Point(96, 214);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(292, 31);
            this.dateTimePickerFim.TabIndex = 1;
            // 
            // BBaixaVoltar
            // 
            this.BBaixaVoltar.Location = new System.Drawing.Point(278, 606);
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
            this.BBaixaAdd.Name = "BBaixaAdd";
            this.BBaixaAdd.Size = new System.Drawing.Size(112, 36);
            this.BBaixaAdd.TabIndex = 3;
            this.BBaixaAdd.Text = "Adicionar";
            this.BBaixaAdd.UseVisualStyleBackColor = true;
            // 
            // RBBaixaRazao
            // 
            this.RBBaixaRazao.Location = new System.Drawing.Point(96, 306);
            this.RBBaixaRazao.Name = "RBBaixaRazao";
            this.RBBaixaRazao.Size = new System.Drawing.Size(292, 257);
            this.RBBaixaRazao.TabIndex = 4;
            this.RBBaixaRazao.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 277);
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
            this.Controls.Add(this.dateTimePickerFim);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Name = "Baixa";
            this.Text = "Baixa";
            this.Load += new System.EventHandler(this.Baixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFim;
        private System.Windows.Forms.Button BBaixaVoltar;
        private System.Windows.Forms.Button BBaixaAdd;
        private System.Windows.Forms.RichTextBox RBBaixaRazao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
