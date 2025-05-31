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
            this.BVAdd = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BVReturn = new System.Windows.Forms.Button();
            this.LBV_List = new System.Windows.Forms.ListBox();
            this.TBV1 = new System.Windows.Forms.TextBox();
            this.TBV2 = new System.Windows.Forms.TextBox();
            this.BVEdit = new System.Windows.Forms.Button();
            this.BVRem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BVAdd
            // 
            this.BVAdd.Location = new System.Drawing.Point(314, 297);
            this.BVAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BVAdd.Name = "BVAdd";
            this.BVAdd.Size = new System.Drawing.Size(56, 19);
            this.BVAdd.TabIndex = 0;
            this.BVAdd.Text = "Adicionar";
            this.BVAdd.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ligeiro",
            "Pesado"});
            this.comboBox1.Location = new System.Drawing.Point(305, 188);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // BVReturn
            // 
            this.BVReturn.Location = new System.Drawing.Point(535, 337);
            this.BVReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BVReturn.Name = "BVReturn";
            this.BVReturn.Size = new System.Drawing.Size(56, 19);
            this.BVReturn.TabIndex = 2;
            this.BVReturn.Text = "Voltar";
            this.BVReturn.UseVisualStyleBackColor = true;
            this.BVReturn.Click += new System.EventHandler(this.BVReturn_Click);
            // 
            // LBV_List
            // 
            this.LBV_List.FormattingEnabled = true;
            this.LBV_List.Location = new System.Drawing.Point(9, 10);
            this.LBV_List.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LBV_List.Name = "LBV_List";
            this.LBV_List.Size = new System.Drawing.Size(255, 342);
            this.LBV_List.TabIndex = 3;
            this.LBV_List.SelectedIndexChanged += new System.EventHandler(this.LBV_List_SelectedIndexChanged);
            // 
            // TBV1
            // 
            this.TBV1.Location = new System.Drawing.Point(305, 42);
            this.TBV1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBV1.Name = "TBV1";
            this.TBV1.Size = new System.Drawing.Size(250, 20);
            this.TBV1.TabIndex = 4;
            // 
            // TBV2
            // 
            this.TBV2.Location = new System.Drawing.Point(305, 113);
            this.TBV2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBV2.Name = "TBV2";
            this.TBV2.Size = new System.Drawing.Size(250, 20);
            this.TBV2.TabIndex = 5;
            // 
            // BVEdit
            // 
            this.BVEdit.Location = new System.Drawing.Point(383, 297);
            this.BVEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BVEdit.Name = "BVEdit";
            this.BVEdit.Size = new System.Drawing.Size(56, 19);
            this.BVEdit.TabIndex = 6;
            this.BVEdit.Text = "Editar";
            this.BVEdit.UseVisualStyleBackColor = true;
            // 
            // BVRem
            // 
            this.BVRem.Location = new System.Drawing.Point(457, 297);
            this.BVRem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BVRem.Name = "BVRem";
            this.BVRem.Size = new System.Drawing.Size(56, 19);
            this.BVRem.TabIndex = 7;
            this.BVRem.Text = "Remover";
            this.BVRem.UseVisualStyleBackColor = true;
            // 
            // Viatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.BVRem);
            this.Controls.Add(this.BVEdit);
            this.Controls.Add(this.TBV2);
            this.Controls.Add(this.TBV1);
            this.Controls.Add(this.LBV_List);
            this.Controls.Add(this.BVReturn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BVAdd);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Viatura";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Viatura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BVAdd;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BVReturn;
        private System.Windows.Forms.ListBox LBV_List;
        private System.Windows.Forms.TextBox TBV1;
        private System.Windows.Forms.TextBox TBV2;
        private System.Windows.Forms.Button BVEdit;
        private System.Windows.Forms.Button BVRem;
    }
}
