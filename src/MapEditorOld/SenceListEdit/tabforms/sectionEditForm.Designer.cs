namespace EditToolsApp.tabforms
{
    partial class sectionEditForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PicPathText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.section_buttton_save = new System.Windows.Forms.Button();
            this.PicPathButton = new System.Windows.Forms.Button();
            this.SencePicData = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SencePicData)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 21);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "章节标题";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "章节描述";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 87);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(182, 21);
            this.textBox3.TabIndex = 3;
            // 
            // PicPathText
            // 
            this.PicPathText.Location = new System.Drawing.Point(93, 127);
            this.PicPathText.Name = "PicPathText";
            this.PicPathText.Size = new System.Drawing.Size(182, 21);
            this.PicPathText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "背景图";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PicPathText);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 300);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.PicPathButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.section_buttton_save);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 302);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本属性";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.SencePicData);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(27, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 93);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片预览";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // section_buttton_save
            // 
            this.section_buttton_save.Location = new System.Drawing.Point(392, 274);
            this.section_buttton_save.Name = "section_buttton_save";
            this.section_buttton_save.Size = new System.Drawing.Size(75, 23);
            this.section_buttton_save.TabIndex = 7;
            this.section_buttton_save.Text = "保存";
            this.section_buttton_save.UseVisualStyleBackColor = true;
            this.section_buttton_save.Click += new System.EventHandler(this.section_buttton_save_Click);
            // 
            // PicPathButton
            // 
            this.PicPathButton.Location = new System.Drawing.Point(281, 127);
            this.PicPathButton.Name = "PicPathButton";
            this.PicPathButton.Size = new System.Drawing.Size(75, 23);
            this.PicPathButton.TabIndex = 13;
            this.PicPathButton.Text = "选择";
            this.PicPathButton.UseVisualStyleBackColor = true;
            this.PicPathButton.Click += new System.EventHandler(this.PicPathButton_Click);
            // 
            // SencePicData
            // 
            this.SencePicData.Location = new System.Drawing.Point(6, 20);
            this.SencePicData.Name = "SencePicData";
            this.SencePicData.Size = new System.Drawing.Size(428, 67);
            this.SencePicData.TabIndex = 8;
            this.SencePicData.TabStop = false;
            // 
            // sectionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 302);
            this.Controls.Add(this.panel1);
            this.Name = "sectionEditForm";
            this.Text = "章节编辑器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SencePicData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox PicPathText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button section_buttton_save;
        private System.Windows.Forms.Button PicPathButton;
        private System.Windows.Forms.PictureBox SencePicData;
    }
}