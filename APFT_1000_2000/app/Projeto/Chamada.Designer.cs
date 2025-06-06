namespace Projeto
{
    partial class Chamada
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BBRem = new System.Windows.Forms.Button();
            this.BBEdit = new System.Windows.Forms.Button();
            this.BBReturn = new System.Windows.Forms.Button();
            this.BBAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBChamada = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(668, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 42;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Número";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nome";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(412, 99);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(332, 22);
            this.textBox5.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Data e Hora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Localização";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Origem";
            // 
            // textBox2
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";  // Formato data e hora
            this.dateTimePicker1.ShowUpDown = true; // Mostra control para hora (sem abrir calendário)
            this.dateTimePicker1.Location = new System.Drawing.Point(415, 252);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(332, 22);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // BBRem
            // 
            this.BBRem.Location = new System.Drawing.Point(925, 408);
            this.BBRem.Name = "BBRem";
            this.BBRem.Size = new System.Drawing.Size(75, 24);
            this.BBRem.TabIndex = 31;
            this.BBRem.Text = "Remover";
            this.BBRem.UseVisualStyleBackColor = true;
            // 
            // BBEdit
            // 
            this.BBEdit.Location = new System.Drawing.Point(844, 408);
            this.BBEdit.Name = "BBEdit";
            this.BBEdit.Size = new System.Drawing.Size(75, 24);
            this.BBEdit.TabIndex = 30;
            this.BBEdit.Text = "Editar";
            this.BBEdit.UseVisualStyleBackColor = true;
            // 
            // BBReturn
            // 
            this.BBReturn.Location = new System.Drawing.Point(1005, 408);
            this.BBReturn.Name = "BBReturn";
            this.BBReturn.Size = new System.Drawing.Size(75, 24);
            this.BBReturn.TabIndex = 29;
            this.BBReturn.Text = "Voltar";
            this.BBReturn.UseVisualStyleBackColor = true;
            this.BBReturn.Click += new System.EventHandler(this.BBReturn_Click);
            // 
            // BBAdd
            // 
            this.BBAdd.Location = new System.Drawing.Point(753, 408);
            this.BBAdd.Name = "BBAdd";
            this.BBAdd.Size = new System.Drawing.Size(80, 24);
            this.BBAdd.TabIndex = 28;
            this.BBAdd.Text = "Adicionar";
            this.BBAdd.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(415, 171);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 22);
            this.textBox1.TabIndex = 27;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(15, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(364, 404);
            this.listBox1.TabIndex = 25;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(415, 339);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(332, 22);
            this.textBox3.TabIndex = 43;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(803, 35);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(276, 328);
            this.richTextBox1.TabIndex = 44;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(799, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Descrição";
            // 
            // CBChamada
            // 
            this.CBChamada.FormattingEnabled = true;
            this.CBChamada.Items.AddRange(new object[] {
            "Direta",
            "Redirecionada"});
            this.CBChamada.Location = new System.Drawing.Point(412, 35);
            this.CBChamada.Name = "CBChamada";
            this.CBChamada.Size = new System.Drawing.Size(121, 24);
            this.CBChamada.TabIndex = 46;
            // 
            // Chamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 454);
            this.Controls.Add(this.CBChamada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BBRem);
            this.Controls.Add(this.BBEdit);
            this.Controls.Add(this.BBReturn);
            this.Controls.Add(this.BBAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Chamada";
            this.Text = "Chamada";
            this.Load += new System.EventHandler(this.Chamada_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BBRem;
        private System.Windows.Forms.Button BBEdit;
        private System.Windows.Forms.Button BBReturn;
        private System.Windows.Forms.Button BBAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBChamada;
    }
}
