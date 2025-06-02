namespace Projeto
{
    partial class Ocorrencias
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
            this.LBOcorrList = new System.Windows.Forms.ListBox();
            this.LBOcorrBomb = new System.Windows.Forms.ListBox();
            this.LBOcorrVia = new System.Windows.Forms.ListBox();
            this.LBOcorrEquip = new System.Windows.Forms.ListBox();
            this.BOcorrReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBOcorrList
            // 
            this.LBOcorrList.FormattingEnabled = true;
            this.LBOcorrList.ItemHeight = 16;
            this.LBOcorrList.Location = new System.Drawing.Point(16, 25);
            this.LBOcorrList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBOcorrList.Name = "LBOcorrList";
            this.LBOcorrList.Size = new System.Drawing.Size(339, 196);
            this.LBOcorrList.TabIndex = 4;
            // 
            // LBOcorrBomb
            // 
            this.LBOcorrBomb.FormattingEnabled = true;
            this.LBOcorrBomb.ItemHeight = 16;
            this.LBOcorrBomb.Location = new System.Drawing.Point(413, 27);
            this.LBOcorrBomb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBOcorrBomb.Name = "LBOcorrBomb";
            this.LBOcorrBomb.Size = new System.Drawing.Size(183, 196);
            this.LBOcorrBomb.TabIndex = 5;
            // 
            // LBOcorrVia
            // 
            this.LBOcorrVia.FormattingEnabled = true;
            this.LBOcorrVia.ItemHeight = 16;
            this.LBOcorrVia.Location = new System.Drawing.Point(605, 27);
            this.LBOcorrVia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBOcorrVia.Name = "LBOcorrVia";
            this.LBOcorrVia.Size = new System.Drawing.Size(183, 196);
            this.LBOcorrVia.TabIndex = 6;
            // 
            // LBOcorrEquip
            // 
            this.LBOcorrEquip.FormattingEnabled = true;
            this.LBOcorrEquip.ItemHeight = 16;
            this.LBOcorrEquip.Location = new System.Drawing.Point(225, 242);
            this.LBOcorrEquip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBOcorrEquip.Name = "LBOcorrEquip";
            this.LBOcorrEquip.Size = new System.Drawing.Size(339, 196);
            this.LBOcorrEquip.TabIndex = 7;
            // 
            // BOcorrReturn
            // 
            this.BOcorrReturn.Location = new System.Drawing.Point(715, 410);
            this.BOcorrReturn.Margin = new System.Windows.Forms.Padding(4);
            this.BOcorrReturn.Name = "BOcorrReturn";
            this.BOcorrReturn.Size = new System.Drawing.Size(73, 28);
            this.BOcorrReturn.TabIndex = 8;
            this.BOcorrReturn.Text = "Voltar";
            this.BOcorrReturn.UseVisualStyleBackColor = true;
            this.BOcorrReturn.Click += new System.EventHandler(this.BOcorrReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ocorrências";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bombeiros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Viaturas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Equpamentos";
            // 
            // Ocorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BOcorrReturn);
            this.Controls.Add(this.LBOcorrEquip);
            this.Controls.Add(this.LBOcorrVia);
            this.Controls.Add(this.LBOcorrBomb);
            this.Controls.Add(this.LBOcorrList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Ocorrencias";
            this.Text = "Ocorrências";
            this.Load += new System.EventHandler(this.Ocorrencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBOcorrList;
        private System.Windows.Forms.ListBox LBOcorrBomb;
        private System.Windows.Forms.ListBox LBOcorrVia;
        private System.Windows.Forms.ListBox LBOcorrEquip;
        private System.Windows.Forms.Button BOcorrReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
