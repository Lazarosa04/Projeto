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
            this.SuspendLayout();
            // 
            // LBOcorrList
            // 
            this.LBOcorrList.FormattingEnabled = true;
            this.LBOcorrList.Location = new System.Drawing.Point(9, 10);
            this.LBOcorrList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrList.Name = "LBOcorrList";
            this.LBOcorrList.Size = new System.Drawing.Size(255, 160);
            this.LBOcorrList.TabIndex = 4;
            // 
            // LBOcorrBomb
            // 
            this.LBOcorrBomb.FormattingEnabled = true;
            this.LBOcorrBomb.Location = new System.Drawing.Point(308, 10);
            this.LBOcorrBomb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrBomb.Name = "LBOcorrBomb";
            this.LBOcorrBomb.Size = new System.Drawing.Size(138, 160);
            this.LBOcorrBomb.TabIndex = 5;
            // 
            // LBOcorrVia
            // 
            this.LBOcorrVia.FormattingEnabled = true;
            this.LBOcorrVia.Location = new System.Drawing.Point(454, 10);
            this.LBOcorrVia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrVia.Name = "LBOcorrVia";
            this.LBOcorrVia.Size = new System.Drawing.Size(138, 160);
            this.LBOcorrVia.TabIndex = 6;
            // 
            // LBOcorrEquip
            // 
            this.LBOcorrEquip.FormattingEnabled = true;
            this.LBOcorrEquip.Location = new System.Drawing.Point(146, 188);
            this.LBOcorrEquip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrEquip.Name = "LBOcorrEquip";
            this.LBOcorrEquip.Size = new System.Drawing.Size(255, 160);
            this.LBOcorrEquip.TabIndex = 7;
            // 
            // BOcorrReturn
            // 
            this.BOcorrReturn.Location = new System.Drawing.Point(470, 309);
            this.BOcorrReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BOcorrReturn.Name = "BOcorrReturn";
            this.BOcorrReturn.Size = new System.Drawing.Size(55, 23);
            this.BOcorrReturn.TabIndex = 8;
            this.BOcorrReturn.Text = "Voltar";
            this.BOcorrReturn.UseVisualStyleBackColor = true;
            this.BOcorrReturn.Click += new System.EventHandler(this.BOcorrReturn_Click);
            // 
            // Ocorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.BOcorrReturn);
            this.Controls.Add(this.LBOcorrEquip);
            this.Controls.Add(this.LBOcorrVia);
            this.Controls.Add(this.LBOcorrBomb);
            this.Controls.Add(this.LBOcorrList);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Ocorrencias";
            this.Text = "Ocorrencias";
            this.Load += new System.EventHandler(this.Ocorrencias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBOcorrList;
        private System.Windows.Forms.ListBox LBOcorrBomb;
        private System.Windows.Forms.ListBox LBOcorrVia;
        private System.Windows.Forms.ListBox LBOcorrEquip;
        private System.Windows.Forms.Button BOcorrReturn;
    }
}