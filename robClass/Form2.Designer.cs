namespace robClass
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.MaxCredit = new System.Windows.Forms.TextBox();
            this.SelCredit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InfoList = new System.Windows.Forms.ListBox();
            this.ClassList = new System.Windows.Forms.ListBox();
            this.StartRob = new System.Windows.Forms.Button();
            this.AddClass = new System.Windows.Forms.Button();
            this.RemoveClass = new System.Windows.Forms.Button();
            this.ClassChosen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClassTimeChosen = new System.Windows.Forms.ComboBox();
            this.StopRob = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上限";
            // 
            // MaxCredit
            // 
            this.MaxCredit.Location = new System.Drawing.Point(175, 6);
            this.MaxCredit.Name = "MaxCredit";
            this.MaxCredit.ReadOnly = true;
            this.MaxCredit.Size = new System.Drawing.Size(34, 22);
            this.MaxCredit.TabIndex = 2;
            this.MaxCredit.TabStop = false;
            this.MaxCredit.Text = "0";
            this.MaxCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelCredit
            // 
            this.SelCredit.Location = new System.Drawing.Point(252, 6);
            this.SelCredit.Name = "SelCredit";
            this.SelCredit.ReadOnly = true;
            this.SelCredit.Size = new System.Drawing.Size(34, 22);
            this.SelCredit.TabIndex = 4;
            this.SelCredit.TabStop = false;
            this.SelCredit.Text = "0";
            this.SelCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "已選";
            // 
            // InfoList
            // 
            this.InfoList.FormattingEnabled = true;
            this.InfoList.ItemHeight = 12;
            this.InfoList.Items.AddRange(new object[] {
            "取得必要資訊中"});
            this.InfoList.Location = new System.Drawing.Point(-3, 247);
            this.InfoList.Name = "InfoList";
            this.InfoList.Size = new System.Drawing.Size(436, 76);
            this.InfoList.TabIndex = 5;
            this.InfoList.SelectedIndexChanged += new System.EventHandler(this.InfoList_SelectedIndexChanged);
            // 
            // ClassList
            // 
            this.ClassList.FormattingEnabled = true;
            this.ClassList.ItemHeight = 12;
            this.ClassList.Location = new System.Drawing.Point(-3, 88);
            this.ClassList.Name = "ClassList";
            this.ClassList.Size = new System.Drawing.Size(436, 124);
            this.ClassList.TabIndex = 6;
            // 
            // StartRob
            // 
            this.StartRob.Location = new System.Drawing.Point(112, 218);
            this.StartRob.Name = "StartRob";
            this.StartRob.Size = new System.Drawing.Size(100, 23);
            this.StartRob.TabIndex = 7;
            this.StartRob.Text = "開始";
            this.StartRob.UseVisualStyleBackColor = true;
            this.StartRob.Click += new System.EventHandler(this.StartRob_Click);
            // 
            // AddClass
            // 
            this.AddClass.Location = new System.Drawing.Point(331, 60);
            this.AddClass.Name = "AddClass";
            this.AddClass.Size = new System.Drawing.Size(41, 23);
            this.AddClass.TabIndex = 8;
            this.AddClass.Text = "新增";
            this.AddClass.UseVisualStyleBackColor = true;
            this.AddClass.Click += new System.EventHandler(this.AddClass_Click);
            // 
            // RemoveClass
            // 
            this.RemoveClass.Location = new System.Drawing.Point(378, 60);
            this.RemoveClass.Name = "RemoveClass";
            this.RemoveClass.Size = new System.Drawing.Size(41, 23);
            this.RemoveClass.TabIndex = 9;
            this.RemoveClass.Text = "移除";
            this.RemoveClass.UseVisualStyleBackColor = true;
            this.RemoveClass.Click += new System.EventHandler(this.RemoveClass_Click);
            // 
            // ClassChosen
            // 
            this.ClassChosen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassChosen.FormattingEnabled = true;
            this.ClassChosen.Location = new System.Drawing.Point(151, 34);
            this.ClassChosen.Name = "ClassChosen";
            this.ClassChosen.Size = new System.Drawing.Size(268, 20);
            this.ClassChosen.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "課程";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "時間";
            // 
            // ClassTimeChosen
            // 
            this.ClassTimeChosen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassTimeChosen.FormattingEnabled = true;
            this.ClassTimeChosen.Location = new System.Drawing.Point(42, 34);
            this.ClassTimeChosen.Name = "ClassTimeChosen";
            this.ClassTimeChosen.Size = new System.Drawing.Size(68, 20);
            this.ClassTimeChosen.TabIndex = 13;
            this.ClassTimeChosen.SelectedIndexChanged += new System.EventHandler(this.ClassTimeChosen_SelectedIndexChanged);
            // 
            // StopRob
            // 
            this.StopRob.Location = new System.Drawing.Point(219, 218);
            this.StopRob.Name = "StopRob";
            this.StopRob.Size = new System.Drawing.Size(100, 23);
            this.StopRob.TabIndex = 14;
            this.StopRob.Text = "停止";
            this.StopRob.UseVisualStyleBackColor = true;
            this.StopRob.Click += new System.EventHandler(this.StopRob_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(354, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 22);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 322);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StopRob);
            this.Controls.Add(this.ClassTimeChosen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClassChosen);
            this.Controls.Add(this.RemoveClass);
            this.Controls.Add(this.AddClass);
            this.Controls.Add(this.StartRob);
            this.Controls.Add(this.ClassList);
            this.Controls.Add(this.InfoList);
            this.Controls.Add(this.SelCredit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxCredit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選課系統 v0.5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MaxCredit;
        private System.Windows.Forms.TextBox SelCredit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox InfoList;
        private System.Windows.Forms.ListBox ClassList;
        private System.Windows.Forms.Button StartRob;
        private System.Windows.Forms.Button AddClass;
        private System.Windows.Forms.Button RemoveClass;
        private System.Windows.Forms.ComboBox ClassChosen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ClassTimeChosen;
        private System.Windows.Forms.Button StopRob;
        private System.Windows.Forms.TextBox textBox1;
    }
}