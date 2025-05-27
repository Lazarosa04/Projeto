namespace Projeto
{
    partial class Viatura
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
            this.BVADD = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BVReturn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TBV1 = new System.Windows.Forms.TextBox();
            this.TBV2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BVADD
            // 
            this.BVADD.Location = new System.Drawing.Point(418, 365);
            this.BVADD.Name = "BVADD";
            this.BVADD.Size = new System.Drawing.Size(75, 23);
            this.BVADD.TabIndex = 0;
            this.BVADD.Text = "adicionar";
            this.BVADD.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ligeiro",
            "Pesado"});
            this.comboBox1.Location = new System.Drawing.Point(524, 318);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // BVReturn
            // 
            this.BVReturn.Location = new System.Drawing.Point(664, 365);
            this.BVReturn.Name = "BVReturn";
            this.BVReturn.Size = new System.Drawing.Size(75, 23);
            this.BVReturn.TabIndex = 2;
            this.BVReturn.Text = "voltar";
            this.BVReturn.UseVisualStyleBackColor = true;
            this.BVReturn.Click += new System.EventHandler(this.BVReturn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(339, 420);
            this.listBox1.TabIndex = 3;
            // 
            // TBV1
            // 
            this.TBV1.Location = new System.Drawing.Point(407, 52);
            this.TBV1.Name = "TBV1";
            this.TBV1.Size = new System.Drawing.Size(332, 22);
            this.TBV1.TabIndex = 4;
            // 
            // TBV2
            // 
            this.TBV2.Location = new System.Drawing.Point(407, 139);
            this.TBV2.Name = "TBV2";
            this.TBV2.Size = new System.Drawing.Size(332, 22);
            this.TBV2.TabIndex = 5;
            // 
            // Viatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TBV2);
            this.Controls.Add(this.TBV1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BVReturn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BVADD);
            this.Name = "Viatura";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Viatura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BVADD;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BVReturn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox TBV1;
        private System.Windows.Forms.TextBox TBV2;
    }
}