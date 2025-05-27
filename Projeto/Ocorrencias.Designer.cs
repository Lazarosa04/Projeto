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
            this.LBOcorrList.ItemHeight = 16;
            this.LBOcorrList.Location = new System.Drawing.Point(12, 12);
            this.LBOcorrList.Name = "LBOcorrList";
            this.LBOcorrList.Size = new System.Drawing.Size(339, 196);
            this.LBOcorrList.TabIndex = 4;
            // 
            // LBOcorrBomb
            // 
            this.LBOcorrBomb.FormattingEnabled = true;
            this.LBOcorrBomb.ItemHeight = 16;
            this.LBOcorrBomb.Location = new System.Drawing.Point(410, 12);
            this.LBOcorrBomb.Name = "LBOcorrBomb";
            this.LBOcorrBomb.Size = new System.Drawing.Size(183, 196);
            this.LBOcorrBomb.TabIndex = 5;
            // 
            // LBOcorrVia
            // 
            this.LBOcorrVia.FormattingEnabled = true;
            this.LBOcorrVia.ItemHeight = 16;
            this.LBOcorrVia.Location = new System.Drawing.Point(605, 12);
            this.LBOcorrVia.Name = "LBOcorrVia";
            this.LBOcorrVia.Size = new System.Drawing.Size(183, 196);
            this.LBOcorrVia.TabIndex = 6;
            // 
            // LBOcorrEquip
            // 
            this.LBOcorrEquip.FormattingEnabled = true;
            this.LBOcorrEquip.ItemHeight = 16;
            this.LBOcorrEquip.Location = new System.Drawing.Point(194, 231);
            this.LBOcorrEquip.Name = "LBOcorrEquip";
            this.LBOcorrEquip.Size = new System.Drawing.Size(339, 196);
            this.LBOcorrEquip.TabIndex = 7;
            // 
            // BOcorrReturn
            // 
            this.BOcorrReturn.Location = new System.Drawing.Point(627, 380);
            this.BOcorrReturn.Name = "BOcorrReturn";
            this.BOcorrReturn.Size = new System.Drawing.Size(73, 28);
            this.BOcorrReturn.TabIndex = 8;
            this.BOcorrReturn.Text = "Voltar";
            this.BOcorrReturn.UseVisualStyleBackColor = true;
            this.BOcorrReturn.Click += new System.EventHandler(this.BOcorrReturn_Click);
            // 
            // Ocorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BOcorrReturn);
            this.Controls.Add(this.LBOcorrEquip);
            this.Controls.Add(this.LBOcorrVia);
            this.Controls.Add(this.LBOcorrBomb);
            this.Controls.Add(this.LBOcorrList);
            this.Name = "Ocorrencias";
            this.Text = "Ocorrencias";
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