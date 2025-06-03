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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.TEV1.Location = new System.Drawing.Point(379, 63);
            this.TEV1.Name = "TEV1";
            this.TEV1.Size = new System.Drawing.Size(332, 22);
            this.TEV1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(379, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 22);
            this.textBox1.TabIndex = 6;
            // 
            // BERem
            // 
            this.BERem.Location = new System.Drawing.Point(608, 410);
            this.BERem.Name = "BERem";
            this.BERem.Size = new System.Drawing.Size(99, 23);
            this.BERem.TabIndex = 11;
            this.BERem.Text = "Remover";
            this.BERem.UseVisualStyleBackColor = true;
            // 
            // BEEdit
            // 
            this.BEEdit.Location = new System.Drawing.Point(510, 410);
            this.BEEdit.Name = "BEEdit";
            this.BEEdit.Size = new System.Drawing.Size(92, 23);
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
            this.BEAdd.Location = new System.Drawing.Point(417, 410);
            this.BEAdd.Name = "BEAdd";
            this.BEAdd.Size = new System.Drawing.Size(87, 23);
            this.BEAdd.TabIndex = 8;
            this.BEAdd.Text = "Adicionar";
            this.BEAdd.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(379, 223);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 22);
            this.textBox2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Viatura";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Equipamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.BERem);
            this.Controls.Add(this.BEEdit);
            this.Controls.Add(this.BEReturn);
            this.Controls.Add(this.BEAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TEV1);
            this.Controls.Add(this.listBox1);
            this.Name = "Equipamento";
            this.Text = "Equipamentos";
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
