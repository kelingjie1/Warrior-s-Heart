namespace MapEditor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mFloorHeight = new System.Windows.Forms.NumericUpDown();
            this.mWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.wGuardingDistance = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.wLevel = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.wName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wPath = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.aY = new System.Windows.Forms.NumericUpDown();
            this.aX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.aName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseImage = new System.Windows.Forms.Button();
            this.aImage = new System.Windows.Forms.TextBox();
            this.map = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.addAdornment = new System.Windows.Forms.Button();
            this.addWarrior = new System.Windows.Forms.Button();
            this.aHeight = new System.Windows.Forms.NumericUpDown();
            this.aWidth = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.wX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mFloorHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mWidth)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wGuardingDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLevel)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aX)).BeginInit();
            this.map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wX)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(738, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(200, 489);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mFloorHeight);
            this.tabPage1.Controls.Add(this.mWidth);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mFloorHeight
            // 
            this.mFloorHeight.Location = new System.Drawing.Point(83, 39);
            this.mFloorHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.mFloorHeight.Name = "mFloorHeight";
            this.mFloorHeight.Size = new System.Drawing.Size(103, 21);
            this.mFloorHeight.TabIndex = 2;
            this.mFloorHeight.ValueChanged += new System.EventHandler(this.MapSize_ValueChanged);
            // 
            // mWidth
            // 
            this.mWidth.Location = new System.Drawing.Point(83, 12);
            this.mWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.mWidth.Name = "mWidth";
            this.mWidth.Size = new System.Drawing.Size(103, 21);
            this.mWidth.TabIndex = 1;
            this.mWidth.ValueChanged += new System.EventHandler(this.MapSize_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "FloorHeight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.wX);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.wGuardingDistance);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.wLevel);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.wName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.wPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "战士属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // wGuardingDistance
            // 
            this.wGuardingDistance.Location = new System.Drawing.Point(113, 85);
            this.wGuardingDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.wGuardingDistance.Name = "wGuardingDistance";
            this.wGuardingDistance.Size = new System.Drawing.Size(72, 21);
            this.wGuardingDistance.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "GuardingDistance";
            // 
            // wLevel
            // 
            this.wLevel.Location = new System.Drawing.Point(41, 61);
            this.wLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.wLevel.Name = "wLevel";
            this.wLevel.Size = new System.Drawing.Size(144, 21);
            this.wLevel.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Path";
            // 
            // wName
            // 
            this.wName.Location = new System.Drawing.Point(41, 7);
            this.wName.Name = "wName";
            this.wName.Size = new System.Drawing.Size(144, 21);
            this.wName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Name";
            // 
            // wPath
            // 
            this.wPath.FormattingEnabled = true;
            this.wPath.Location = new System.Drawing.Point(41, 34);
            this.wPath.Name = "wPath";
            this.wPath.Size = new System.Drawing.Size(144, 20);
            this.wPath.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.aHeight);
            this.tabPage3.Controls.Add(this.aWidth);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.aY);
            this.tabPage3.Controls.Add(this.aX);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.aName);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.chooseImage);
            this.tabPage3.Controls.Add(this.aImage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(192, 463);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "装饰品属性";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // aY
            // 
            this.aY.Location = new System.Drawing.Point(112, 65);
            this.aY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.aY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.aY.Name = "aY";
            this.aY.Size = new System.Drawing.Size(65, 21);
            this.aY.TabIndex = 7;
            this.aY.ValueChanged += new System.EventHandler(this.aY_ValueChanged);
            // 
            // aX
            // 
            this.aX.Location = new System.Drawing.Point(41, 65);
            this.aX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.aX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.aX.Name = "aX";
            this.aX.Size = new System.Drawing.Size(65, 21);
            this.aX.TabIndex = 6;
            this.aX.ValueChanged += new System.EventHandler(this.aX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Image";
            // 
            // aName
            // 
            this.aName.Location = new System.Drawing.Point(41, 10);
            this.aName.Name = "aName";
            this.aName.Size = new System.Drawing.Size(148, 21);
            this.aName.TabIndex = 4;
            this.aName.TextChanged += new System.EventHandler(this.aName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "XY";
            // 
            // chooseImage
            // 
            this.chooseImage.Location = new System.Drawing.Point(151, 33);
            this.chooseImage.Name = "chooseImage";
            this.chooseImage.Size = new System.Drawing.Size(38, 23);
            this.chooseImage.TabIndex = 1;
            this.chooseImage.Text = "...";
            this.chooseImage.UseVisualStyleBackColor = true;
            // 
            // aImage
            // 
            this.aImage.Location = new System.Drawing.Point(41, 33);
            this.aImage.Name = "aImage";
            this.aImage.Size = new System.Drawing.Size(104, 21);
            this.aImage.TabIndex = 0;
            this.aImage.TextChanged += new System.EventHandler(this.aImage_TextChanged);
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.Control;
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.map.Controls.Add(this.label2);
            this.map.Location = new System.Drawing.Point(15, 68);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(717, 501);
            this.map.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // addAdornment
            // 
            this.addAdornment.Location = new System.Drawing.Point(15, 13);
            this.addAdornment.Name = "addAdornment";
            this.addAdornment.Size = new System.Drawing.Size(111, 49);
            this.addAdornment.TabIndex = 4;
            this.addAdornment.Text = "添加装饰品";
            this.addAdornment.UseVisualStyleBackColor = true;
            this.addAdornment.Click += new System.EventHandler(this.addAdornment_Click);
            // 
            // addWarrior
            // 
            this.addWarrior.Location = new System.Drawing.Point(132, 13);
            this.addWarrior.Name = "addWarrior";
            this.addWarrior.Size = new System.Drawing.Size(111, 49);
            this.addWarrior.TabIndex = 5;
            this.addWarrior.Text = "添加战士";
            this.addWarrior.UseVisualStyleBackColor = true;
            this.addWarrior.Click += new System.EventHandler(this.addWarrior_Click);
            // 
            // aHeight
            // 
            this.aHeight.Location = new System.Drawing.Point(112, 92);
            this.aHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aHeight.Name = "aHeight";
            this.aHeight.Size = new System.Drawing.Size(65, 21);
            this.aHeight.TabIndex = 10;
            this.aHeight.ValueChanged += new System.EventHandler(this.aHeight_ValueChanged);
            // 
            // aWidth
            // 
            this.aWidth.Location = new System.Drawing.Point(41, 92);
            this.aWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aWidth.Name = "aWidth";
            this.aWidth.Size = new System.Drawing.Size(65, 21);
            this.aWidth.TabIndex = 9;
            this.aWidth.ValueChanged += new System.EventHandler(this.aWidth_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "Size";
            // 
            // wX
            // 
            this.wX.Location = new System.Drawing.Point(41, 112);
            this.wX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.wX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.wX.Name = "wX";
            this.wX.Size = new System.Drawing.Size(65, 21);
            this.wX.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "X";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(861, 13);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(76, 39);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 581);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.addWarrior);
            this.Controls.Add(this.addAdornment);
            this.Controls.Add(this.map);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mFloorHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mWidth)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wGuardingDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLevel)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aX)).EndInit();
            this.map.ResumeLayout(false);
            this.map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wX)).EndInit();
            this.ResumeLayout(false);

        }







        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown mFloorHeight;
        private System.Windows.Forms.NumericUpDown mWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.Button addAdornment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox wPath;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button chooseImage;
        private System.Windows.Forms.TextBox aImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox wName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown aY;
        private System.Windows.Forms.NumericUpDown aX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addWarrior;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown wLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown wGuardingDistance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown wX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown aHeight;
        private System.Windows.Forms.NumericUpDown aWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Save;
    }
}

