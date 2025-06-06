namespace Projeto
{
    partial class Manutenção
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button BEAdicionar;
        private System.Windows.Forms.Button BECancelar;
        private System.Windows.Forms.DateTimePicker DTPDataManutencao;
        private System.Windows.Forms.TextBox TBDescricao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelDescricao;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.BEAdicionar = new System.Windows.Forms.Button();
            this.BECancelar = new System.Windows.Forms.Button();
            this.DTPDataManutencao = new System.Windows.Forms.DateTimePicker();
            this.TBDescricao = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BEAdicionar
            // 
            this.BEAdicionar.Location = new System.Drawing.Point(50, 150);
            this.BEAdicionar.Name = "BEAdicionar";
            this.BEAdicionar.Size = new System.Drawing.Size(100, 40);
            this.BEAdicionar.TabIndex = 0;
            this.BEAdicionar.Text = "Adicionar";
            this.BEAdicionar.UseVisualStyleBackColor = true;
            // 
            // BECancelar
            // 
            this.BECancelar.Location = new System.Drawing.Point(170, 150);
            this.BECancelar.Name = "BECancelar";
            this.BECancelar.Size = new System.Drawing.Size(100, 40);
            this.BECancelar.TabIndex = 1;
            this.BECancelar.Text = "Cancelar";
            this.BECancelar.UseVisualStyleBackColor = true;
            // 
            // DTPDataManutencao
            // 
            this.DTPDataManutencao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataManutencao.Location = new System.Drawing.Point(50, 40);
            this.DTPDataManutencao.Name = "DTPDataManutencao";
            this.DTPDataManutencao.Size = new System.Drawing.Size(220, 31);
            this.DTPDataManutencao.TabIndex = 2;
            // 
            // TBDescricao
            // 
            this.TBDescricao.Location = new System.Drawing.Point(50, 100);
            this.TBDescricao.Name = "TBDescricao";
            this.TBDescricao.Size = new System.Drawing.Size(220, 31);
            this.TBDescricao.TabIndex = 3;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(50, 15);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(48, 25);
            this.labelData.TabIndex = 4;
            this.labelData.Text = "Data";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(50, 75);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(83, 25);
            this.labelDescricao.TabIndex = 5;
            this.labelDescricao.Text = "Descrição";
            // 
            // Manutenção
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 220);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.TBDescricao);
            this.Controls.Add(this.DTPDataManutencao);
            this.Controls.Add(this.BECancelar);
            this.Controls.Add(this.BEAdicionar);
            this.Name = "Manutenção";
            this.Text = "Adicionar Manutenção";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
