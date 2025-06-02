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
            this.button1 = new System.Windows.Forms.Button();
            this.BERem = new System.Windows.Forms.Button();
            this.BEEdit = new System.Windows.Forms.Button();
            this.BEAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBOcorrList
            // 
            this.LBOcorrList.FormattingEnabled = true;
            this.LBOcorrList.Location = new System.Drawing.Point(12, 20);
            this.LBOcorrList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrList.Name = "LBOcorrList";
            this.LBOcorrList.Size = new System.Drawing.Size(255, 160);
            this.LBOcorrList.TabIndex = 4;
            // 
            // LBOcorrBomb
            // 
            this.LBOcorrBomb.FormattingEnabled = true;
            this.LBOcorrBomb.Location = new System.Drawing.Point(293, 20);
            this.LBOcorrBomb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrBomb.Name = "LBOcorrBomb";
            this.LBOcorrBomb.Size = new System.Drawing.Size(138, 160);
            this.LBOcorrBomb.TabIndex = 5;
            // 
            // LBOcorrVia
            // 
            this.LBOcorrVia.FormattingEnabled = true;
            this.LBOcorrVia.Location = new System.Drawing.Point(437, 20);
            this.LBOcorrVia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrVia.Name = "LBOcorrVia";
            this.LBOcorrVia.Size = new System.Drawing.Size(138, 160);
            this.LBOcorrVia.TabIndex = 6;
            // 
            // LBOcorrEquip
            // 
            this.LBOcorrEquip.FormattingEnabled = true;
            this.LBOcorrEquip.Location = new System.Drawing.Point(437, 204);
            this.LBOcorrEquip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBOcorrEquip.Name = "LBOcorrEquip";
            this.LBOcorrEquip.Size = new System.Drawing.Size(138, 160);
            this.LBOcorrEquip.TabIndex = 7;
            // 
            // BOcorrReturn
            // 
            this.BOcorrReturn.Location = new System.Drawing.Point(322, 331);
            this.BOcorrReturn.Name = "BOcorrReturn";
            this.BOcorrReturn.Size = new System.Drawing.Size(60, 19);
            this.BOcorrReturn.TabIndex = 8;
            this.BOcorrReturn.Text = "Voltar";
            this.BOcorrReturn.UseVisualStyleBackColor = true;
            this.BOcorrReturn.Click += new System.EventHandler(this.BOcorrReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ocorrências";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bombeiros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Viaturas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Equpamentos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 331);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 19);
            this.button1.TabIndex = 29;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BERem
            // 
            this.BERem.Location = new System.Drawing.Point(243, 331);
            this.BERem.Margin = new System.Windows.Forms.Padding(2);
            this.BERem.Name = "BERem";
            this.BERem.Size = new System.Drawing.Size(74, 19);
            this.BERem.TabIndex = 28;
            this.BERem.Text = "Remover";
            this.BERem.UseVisualStyleBackColor = true;
            // 
            // BEEdit
            // 
            this.BEEdit.Location = new System.Drawing.Point(169, 331);
            this.BEEdit.Margin = new System.Windows.Forms.Padding(2);
            this.BEEdit.Name = "BEEdit";
            this.BEEdit.Size = new System.Drawing.Size(69, 19);
            this.BEEdit.TabIndex = 27;
            this.BEEdit.Text = "Editar";
            this.BEEdit.UseVisualStyleBackColor = true;
            // 
            // BEAdd
            // 
            this.BEAdd.Location = new System.Drawing.Point(100, 331);
            this.BEAdd.Margin = new System.Windows.Forms.Padding(2);
            this.BEAdd.Name = "BEAdd";
            this.BEAdd.Size = new System.Drawing.Size(65, 19);
            this.BEAdd.TabIndex = 26;
            this.BEAdd.Text = "Adicionar";
            this.BEAdd.UseVisualStyleBackColor = true;
            // 
            // Ocorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BERem);
            this.Controls.Add(this.BEEdit);
            this.Controls.Add(this.BEAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BOcorrReturn);
            this.Controls.Add(this.LBOcorrEquip);
            this.Controls.Add(this.LBOcorrVia);
            this.Controls.Add(this.LBOcorrBomb);
            this.Controls.Add(this.LBOcorrList);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BERem;
        private System.Windows.Forms.Button BEEdit;
        private System.Windows.Forms.Button BEAdd;
    }
}
