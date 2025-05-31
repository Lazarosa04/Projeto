namespace Projeto
{
    partial class Quartel
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
            this.BBomb = new System.Windows.Forms.Button();
            this.BViat = new System.Windows.Forms.Button();
            this.BOcor = new System.Windows.Forms.Button();
            this.BExit = new System.Windows.Forms.Button();
            this.BEquip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BBomb
            // 
            this.BBomb.Location = new System.Drawing.Point(94, 52);
            this.BBomb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BBomb.Name = "BBomb";
            this.BBomb.Size = new System.Drawing.Size(126, 68);
            this.BBomb.TabIndex = 0;
            this.BBomb.Text = "Bombeiros";
            this.BBomb.UseVisualStyleBackColor = true;
            this.BBomb.Click += new System.EventHandler(this.BBomb_Click);
            // 
            // BViat
            // 
            this.BViat.Location = new System.Drawing.Point(242, 52);
            this.BViat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BViat.Name = "BViat";
            this.BViat.Size = new System.Drawing.Size(126, 68);
            this.BViat.TabIndex = 1;
            this.BViat.Text = "Viaturas";
            this.BViat.UseVisualStyleBackColor = true;
            this.BViat.Click += new System.EventHandler(this.BViat_Click);
            // 
            // BOcor
            // 
            this.BOcor.Location = new System.Drawing.Point(94, 144);
            this.BOcor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BOcor.Name = "BOcor";
            this.BOcor.Size = new System.Drawing.Size(126, 68);
            this.BOcor.TabIndex = 2;
            this.BOcor.Text = "Ocorrências";
            this.BOcor.UseVisualStyleBackColor = true;
            this.BOcor.Click += new System.EventHandler(this.BOcor_Click);
            // 
            // BExit
            // 
            this.BExit.Location = new System.Drawing.Point(520, 327);
            this.BExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BExit.Name = "BExit";
            this.BExit.Size = new System.Drawing.Size(56, 19);
            this.BExit.TabIndex = 3;
            this.BExit.Text = "Exit";
            this.BExit.UseVisualStyleBackColor = true;
            this.BExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // BEquip
            // 
            this.BEquip.Location = new System.Drawing.Point(242, 144);
            this.BEquip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BEquip.Name = "BEquip";
            this.BEquip.Size = new System.Drawing.Size(126, 68);
            this.BEquip.TabIndex = 4;
            this.BEquip.Text = "Equipamento";
            this.BEquip.UseVisualStyleBackColor = true;
            this.BEquip.Click += new System.EventHandler(this.BEquip_Click);
            // 
            // Quartel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.BEquip);
            this.Controls.Add(this.BExit);
            this.Controls.Add(this.BOcor);
            this.Controls.Add(this.BViat);
            this.Controls.Add(this.BBomb);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Quartel";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Quartel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BBomb;
        private System.Windows.Forms.Button BViat;
        private System.Windows.Forms.Button BOcor;
        private System.Windows.Forms.Button BExit;
        private System.Windows.Forms.Button BEquip;
    }
}

