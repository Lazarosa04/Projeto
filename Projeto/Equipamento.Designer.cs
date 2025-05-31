namespace Projeto
{
    partial class Equipamento
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

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TEV1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BERem = new System.Windows.Forms.Button();
            this.BEEdit = new System.Windows.Forms.Button();
            this.BEReturn = new System.Windows.Forms.Button();
            this.BEAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(324, 420);
            this.listBox1.TabIndex = 0;
            // 
            // TEV1
            // 
            this.TEV1.Location = new System.Drawing.Point(379, 38);
            this.TEV1.Name = "TEV1";
            this.TEV1.Size = new System.Drawing.Size(332, 22);
            this.TEV1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(379, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 22);
            this.textBox1.TabIndex = 6;
            // 
            // BERem
            // 
            this.BERem.Location = new System.Drawing.Point(609, 360);
            this.BERem.Name = "BERem";
            this.BERem.Size = new System.Drawing.Size(75, 23);
            this.BERem.TabIndex = 11;
            this.BERem.Text = "Remover";
            this.BERem.UseVisualStyleBackColor = true;
            // 
            // BEEdit
            // 
            this.BEEdit.Location = new System.Drawing.Point(511, 360);
            this.BEEdit.Name = "BEEdit";
            this.BEEdit.Size = new System.Drawing.Size(75, 23);
            this.BEEdit.TabIndex = 10;
            this.BEEdit.Text = "Editar";
            this.BEEdit.UseVisualStyleBackColor = true;
            // 
            // BEReturn
            // 
            this.BEReturn.Location = new System.Drawing.Point(713, 410);
            this.BEReturn.Name = "BEReturn";
            this.BEReturn.Size = new System.Drawing.Size(75, 23);
            this.BEReturn.TabIndex = 9;
            this.BEReturn.Text = "Voltar";
            this.BEReturn.UseVisualStyleBackColor = true;
            // 
            // BEAdd
            // 
            this.BEAdd.Location = new System.Drawing.Point(418, 360);
            this.BEAdd.Name = "BEAdd";
            this.BEAdd.Size = new System.Drawing.Size(75, 23);
            this.BEAdd.TabIndex = 8;
            this.BEAdd.Text = "Adicionar";
            this.BEAdd.UseVisualStyleBackColor = true;
            // 
            // Equipamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BERem);
            this.Controls.Add(this.BEEdit);
            this.Controls.Add(this.BEReturn);
            this.Controls.Add(this.BEAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TEV1);
            this.Controls.Add(this.listBox1);
            this.Name = "Equipamento";
            this.Text = "Equipamento";
            this.Load += new System.EventHandler(this.Equipamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox TEV1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BERem;
        private System.Windows.Forms.Button BEEdit;
        private System.Windows.Forms.Button BEReturn;
        private System.Windows.Forms.Button BEAdd;
    }
}