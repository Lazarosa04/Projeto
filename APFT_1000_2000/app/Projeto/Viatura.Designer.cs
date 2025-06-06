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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LBVEquip = new System.Windows.Forms.ListBox();
            this.LBVManu = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BVMAdd = new System.Windows.Forms.Button();
            this.BVMRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BVAdd
            // 
            this.BVAdd.Location = new System.Drawing.Point(112, 371);
            this.BVAdd.Margin = new System.Windows.Forms.Padding(4);
            this.BVAdd.Name = "BVAdd";
            this.BVAdd.Size = new System.Drawing.Size(116, 28);
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
            this.comboBox1.Location = new System.Drawing.Point(300, 146);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // BVReturn
            // 
            this.BVReturn.Location = new System.Drawing.Point(464, 371);
            this.BVReturn.Margin = new System.Windows.Forms.Padding(4);
            this.BVReturn.Name = "BVReturn";
            this.BVReturn.Size = new System.Drawing.Size(86, 28);
            this.BVReturn.TabIndex = 2;
            this.BVReturn.Text = "Voltar";
            this.BVReturn.UseVisualStyleBackColor = true;
            this.BVReturn.Click += new System.EventHandler(this.BVReturn_Click);
            // 
            // LBV_List
            // 
            this.LBV_List.FormattingEnabled = true;
            this.LBV_List.ItemHeight = 16;
            this.LBV_List.Location = new System.Drawing.Point(12, 12);
            this.LBV_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBV_List.Name = "LBV_List";
            this.LBV_List.Size = new System.Drawing.Size(264, 244);
            this.LBV_List.TabIndex = 3;
            this.LBV_List.SelectedIndexChanged += new System.EventHandler(this.LBV_List_SelectedIndexChanged);
            // 
            // TBV1
            // 
            this.TBV1.Location = new System.Drawing.Point(301, 34);
            this.TBV1.Margin = new System.Windows.Forms.Padding(4);
            this.TBV1.Name = "TBV1";
            this.TBV1.Size = new System.Drawing.Size(332, 22);
            this.TBV1.TabIndex = 4;
            // 
            // TBV2
            // 
            this.TBV2.Location = new System.Drawing.Point(301, 88);
            this.TBV2.Margin = new System.Windows.Forms.Padding(4);
            this.TBV2.Name = "TBV2";
            this.TBV2.Size = new System.Drawing.Size(332, 22);
            this.TBV2.TabIndex = 5;
            // 
            // BVEdit
            // 
            this.BVEdit.Location = new System.Drawing.Point(251, 371);
            this.BVEdit.Margin = new System.Windows.Forms.Padding(4);
            this.BVEdit.Name = "BVEdit";
            this.BVEdit.Size = new System.Drawing.Size(82, 28);
            this.BVEdit.TabIndex = 6;
            this.BVEdit.Text = "Editar";
            this.BVEdit.UseVisualStyleBackColor = true;
            // 
            // BVRem
            // 
            this.BVRem.Location = new System.Drawing.Point(360, 371);
            this.BVRem.Margin = new System.Windows.Forms.Padding(4);
            this.BVRem.Name = "BVRem";
            this.BVRem.Size = new System.Drawing.Size(83, 28);
            this.BVRem.TabIndex = 7;
            this.BVRem.Text = "Remover";
            this.BVRem.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ano";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Matrícula";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LBVEquip
            // 
            this.LBVEquip.FormattingEnabled = true;
            this.LBVEquip.ItemHeight = 16;
            this.LBVEquip.Location = new System.Drawing.Point(697, 34);
            this.LBVEquip.Name = "LBVEquip";
            this.LBVEquip.Size = new System.Drawing.Size(389, 116);
            this.LBVEquip.TabIndex = 27;
            // 
            // LBVManu
            // 
            this.LBVManu.FormattingEnabled = true;
            this.LBVManu.ItemHeight = 16;
            this.LBVManu.Location = new System.Drawing.Point(697, 200);
            this.LBVManu.Name = "LBVManu";
            this.LBVManu.Size = new System.Drawing.Size(389, 116);
            this.LBVManu.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Equipamentos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Manutenções";
            // 
            // BVMAdd
            // 
            this.BVMAdd.Location = new System.Drawing.Point(743, 323);
            this.BVMAdd.Margin = new System.Windows.Forms.Padding(4);
            this.BVMAdd.Name = "BVMAdd";
            this.BVMAdd.Size = new System.Drawing.Size(116, 28);
            this.BVMAdd.TabIndex = 31;
            this.BVMAdd.Text = "Adicionar";
            this.BVMAdd.UseVisualStyleBackColor = true;
            // 
            // BVMRemove
            // 
            this.BVMRemove.Location = new System.Drawing.Point(894, 323);
            this.BVMRemove.Margin = new System.Windows.Forms.Padding(4);
            this.BVMRemove.Name = "BVMRemove";
            this.BVMRemove.Size = new System.Drawing.Size(105, 28);
            this.BVMRemove.TabIndex = 32;
            this.BVMRemove.Text = "Remover";
            this.BVMRemove.UseVisualStyleBackColor = true;
            // 
            // Viatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 412);
            this.Controls.Add(this.BVMRemove);
            this.Controls.Add(this.BVMAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBVManu);
            this.Controls.Add(this.LBVEquip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BVRem);
            this.Controls.Add(this.BVEdit);
            this.Controls.Add(this.TBV2);
            this.Controls.Add(this.TBV1);
            this.Controls.Add(this.LBV_List);
            this.Controls.Add(this.BVReturn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BVAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Viatura";
            this.Text = "Viaturas";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox LBVEquip;
        private System.Windows.Forms.ListBox LBVManu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BVMAdd;
        private System.Windows.Forms.Button BVMRemove;
    }
}
