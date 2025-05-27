namespace Projeto
{
    partial class Bombeiro
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TBV1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BBRem = new System.Windows.Forms.Button();
            this.BBEdit = new System.Windows.Forms.Button();
            this.BBReturn = new System.Windows.Forms.Button();
            this.BBAdd = new System.Windows.Forms.Button();
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
            // TBV1
            // 
            this.TBV1.Location = new System.Drawing.Point(379, 38);
            this.TBV1.Name = "TBV1";
            this.TBV1.Size = new System.Drawing.Size(332, 22);
            this.TBV1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(379, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 22);
            this.textBox1.TabIndex = 6;
            // 
            // BBRem
            // 
            this.BBRem.Location = new System.Drawing.Point(609, 360);
            this.BBRem.Name = "BBRem";
            this.BBRem.Size = new System.Drawing.Size(75, 23);
            this.BBRem.TabIndex = 11;
            this.BBRem.Text = "Remover";
            this.BBRem.UseVisualStyleBackColor = true;
            // 
            // BBEdit
            // 
            this.BBEdit.Location = new System.Drawing.Point(511, 360);
            this.BBEdit.Name = "BBEdit";
            this.BBEdit.Size = new System.Drawing.Size(75, 23);
            this.BBEdit.TabIndex = 10;
            this.BBEdit.Text = "Editar";
            this.BBEdit.UseVisualStyleBackColor = true;
            // 
            // BBReturn
            // 
            this.BBReturn.Location = new System.Drawing.Point(713, 410);
            this.BBReturn.Name = "BBReturn";
            this.BBReturn.Size = new System.Drawing.Size(75, 23);
            this.BBReturn.TabIndex = 9;
            this.BBReturn.Text = "Voltar";
            this.BBReturn.UseVisualStyleBackColor = true;
            // 
            // BBAdd
            // 
            this.BBAdd.Location = new System.Drawing.Point(418, 360);
            this.BBAdd.Name = "BBAdd";
            this.BBAdd.Size = new System.Drawing.Size(75, 23);
            this.BBAdd.TabIndex = 8;
            this.BBAdd.Text = "Adicionar";
            this.BBAdd.UseVisualStyleBackColor = true;
            // 
            // Bombeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BBRem);
            this.Controls.Add(this.BBEdit);
            this.Controls.Add(this.BBReturn);
            this.Controls.Add(this.BBAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TBV1);
            this.Controls.Add(this.listBox1);
            this.Name = "Bombeiro";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Bombeiro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox TBV1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BBRem;
        private System.Windows.Forms.Button BBEdit;
        private System.Windows.Forms.Button BBReturn;
        private System.Windows.Forms.Button BBAdd;
    }
}
