namespace Projeto
{
    partial class Férias
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BFeriasAdd = new System.Windows.Forms.Button();
            this.BFeriasVoltar = new System.Windows.Forms.Button();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data Fim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Data Início";
            // 
            // BFeriasAdd
            // 
            this.BFeriasAdd.Location = new System.Drawing.Point(54, 306);
            this.BFeriasAdd.Name = "BFeriasAdd";
            this.BFeriasAdd.Size = new System.Drawing.Size(112, 36);
            this.BFeriasAdd.TabIndex = 11;
            this.BFeriasAdd.Text = "Adicionar";
            this.BFeriasAdd.UseVisualStyleBackColor = true;
            // 
            // BFeriasVoltar
            // 
            this.BFeriasVoltar.Location = new System.Drawing.Point(236, 306);
            this.BFeriasVoltar.Name = "BFeriasVoltar";
            this.BFeriasVoltar.Size = new System.Drawing.Size(112, 36);
            this.BFeriasVoltar.TabIndex = 10;
            this.BFeriasVoltar.Text = "Voltar";
            this.BFeriasVoltar.UseVisualStyleBackColor = true;
            this.BFeriasVoltar.Click += new System.EventHandler(this.BFeriasVoltar_Click_1);
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Location = new System.Drawing.Point(54, 180);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(292, 31);
            this.dateTimePickerFim.TabIndex = 9;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(54, 72);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(292, 31);
            this.dateTimePickerInicio.TabIndex = 8;
            // 
            // Férias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BFeriasAdd);
            this.Controls.Add(this.BFeriasVoltar);
            this.Controls.Add(this.dateTimePickerFim);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Name = "Férias";
            this.Text = "Férias";
            this.Load += new System.EventHandler(this.Férias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BFeriasAdd;
        private System.Windows.Forms.Button BFeriasVoltar;
        private System.Windows.Forms.DateTimePicker dateTimePickerFim;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
    }
}
