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
            this.filePath = new System.Windows.Forms.TabPage();
            this.chooseWarriorDir = new System.Windows.Forms.Button();
            this.warriorDir = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.openFilePath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chooseResourcePath = new System.Windows.Forms.Button();
            this.resourcePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mapFloorHeight = new System.Windows.Forms.NumericUpDown();
            this.mapWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chooseWarriorPath = new System.Windows.Forms.Button();
            this.warriorPath = new System.Windows.Forms.TextBox();
            this.warriorX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.warriorGuardingDistance = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.warriorLevel = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.warriorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.adornmentHeight = new System.Windows.Forms.NumericUpDown();
            this.adornmentWidth = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.adornmentY = new System.Windows.Forms.NumericUpDown();
            this.adornmentX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.adornmentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseImage = new System.Windows.Forms.Button();
            this.adornmentImage = new System.Windows.Forms.TextBox();
            this.map = new System.Windows.Forms.Panel();
            this.floor = new System.Windows.Forms.Label();
            this.addAdornment = new System.Windows.Forms.Button();
            this.addWarrior = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.openFile = new System.Windows.Forms.Button();
            this.deleteObject = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.filePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapFloorHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorGuardingDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorLevel)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentX)).BeginInit();
            this.map.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.filePath);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(815, 58);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(200, 711);
            this.tabControl.TabIndex = 2;
            // 
            // filePath
            // 
            this.filePath.Controls.Add(this.chooseWarriorDir);
            this.filePath.Controls.Add(this.warriorDir);
            this.filePath.Controls.Add(this.label14);
            this.filePath.Controls.Add(this.openFilePath);
            this.filePath.Controls.Add(this.label13);
            this.filePath.Controls.Add(this.chooseResourcePath);
            this.filePath.Controls.Add(this.resourcePath);
            this.filePath.Controls.Add(this.label2);
            this.filePath.Controls.Add(this.mapFloorHeight);
            this.filePath.Controls.Add(this.mapWidth);
            this.filePath.Controls.Add(this.label8);
            this.filePath.Controls.Add(this.label1);
            this.filePath.Location = new System.Drawing.Point(4, 22);
            this.filePath.Name = "filePath";
            this.filePath.Padding = new System.Windows.Forms.Padding(3);
            this.filePath.Size = new System.Drawing.Size(192, 685);
            this.filePath.TabIndex = 0;
            this.filePath.Text = "地图属性";
            this.filePath.UseVisualStyleBackColor = true;
            // 
            // chooseWarriorDir
            // 
            this.chooseWarriorDir.Location = new System.Drawing.Point(151, 151);
            this.chooseWarriorDir.Name = "chooseWarriorDir";
            this.chooseWarriorDir.Size = new System.Drawing.Size(35, 23);
            this.chooseWarriorDir.TabIndex = 10;
            this.chooseWarriorDir.Text = "...";
            this.chooseWarriorDir.UseVisualStyleBackColor = true;
            this.chooseWarriorDir.Click += new System.EventHandler(this.chooseWarriorDir_Click);
            // 
            // warriorDir
            // 
            this.warriorDir.Location = new System.Drawing.Point(10, 154);
            this.warriorDir.Name = "warriorDir";
            this.warriorDir.Size = new System.Drawing.Size(135, 21);
            this.warriorDir.TabIndex = 9;
            this.warriorDir.TextChanged += new System.EventHandler(this.warriorDir_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "战士路径";
            // 
            // openFilePath
            // 
            this.openFilePath.Location = new System.Drawing.Point(10, 243);
            this.openFilePath.Name = "openFilePath";
            this.openFilePath.Size = new System.Drawing.Size(135, 21);
            this.openFilePath.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "文件路径";
            // 
            // chooseResourcePath
            // 
            this.chooseResourcePath.Location = new System.Drawing.Point(151, 109);
            this.chooseResourcePath.Name = "chooseResourcePath";
            this.chooseResourcePath.Size = new System.Drawing.Size(35, 23);
            this.chooseResourcePath.TabIndex = 5;
            this.chooseResourcePath.Text = "...";
            this.chooseResourcePath.UseVisualStyleBackColor = true;
            this.chooseResourcePath.Click += new System.EventHandler(this.chooseResourcePath_Click);
            // 
            // resourcePath
            // 
            this.resourcePath.Location = new System.Drawing.Point(10, 112);
            this.resourcePath.Name = "resourcePath";
            this.resourcePath.Size = new System.Drawing.Size(135, 21);
            this.resourcePath.TabIndex = 4;
            this.resourcePath.TextChanged += new System.EventHandler(this.resourcePath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "资源路径";
            // 
            // mapFloorHeight
            // 
            this.mapFloorHeight.Location = new System.Drawing.Point(83, 39);
            this.mapFloorHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.mapFloorHeight.Name = "mapFloorHeight";
            this.mapFloorHeight.Size = new System.Drawing.Size(103, 21);
            this.mapFloorHeight.TabIndex = 2;
            this.mapFloorHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.mapFloorHeight.ValueChanged += new System.EventHandler(this.mFloorHeight_ValueChanged);
            // 
            // mapWidth
            // 
            this.mapWidth.Location = new System.Drawing.Point(83, 12);
            this.mapWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(103, 21);
            this.mapWidth.TabIndex = 1;
            this.mapWidth.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.mapWidth.ValueChanged += new System.EventHandler(this.MapSize_ValueChanged);
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
            this.tabPage2.Controls.Add(this.chooseWarriorPath);
            this.tabPage2.Controls.Add(this.warriorPath);
            this.tabPage2.Controls.Add(this.warriorX);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.warriorGuardingDistance);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.warriorLevel);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.warriorName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 685);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "战士属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chooseWarriorPath
            // 
            this.chooseWarriorPath.Location = new System.Drawing.Point(147, 32);
            this.chooseWarriorPath.Name = "chooseWarriorPath";
            this.chooseWarriorPath.Size = new System.Drawing.Size(38, 23);
            this.chooseWarriorPath.TabIndex = 15;
            this.chooseWarriorPath.Text = "...";
            this.chooseWarriorPath.UseVisualStyleBackColor = true;
            this.chooseWarriorPath.Click += new System.EventHandler(this.chooseWarriorPath_Click);
            // 
            // warriorPath
            // 
            this.warriorPath.Location = new System.Drawing.Point(42, 35);
            this.warriorPath.Name = "warriorPath";
            this.warriorPath.Size = new System.Drawing.Size(100, 21);
            this.warriorPath.TabIndex = 14;
            this.warriorPath.TextChanged += new System.EventHandler(this.warriorPath_TextChanged);
            // 
            // warriorX
            // 
            this.warriorX.Location = new System.Drawing.Point(41, 112);
            this.warriorX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.warriorX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.warriorX.Name = "warriorX";
            this.warriorX.Size = new System.Drawing.Size(65, 21);
            this.warriorX.TabIndex = 13;
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
            // warriorGuardingDistance
            // 
            this.warriorGuardingDistance.Location = new System.Drawing.Point(113, 85);
            this.warriorGuardingDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.warriorGuardingDistance.Name = "warriorGuardingDistance";
            this.warriorGuardingDistance.Size = new System.Drawing.Size(72, 21);
            this.warriorGuardingDistance.TabIndex = 11;
            this.warriorGuardingDistance.ValueChanged += new System.EventHandler(this.warriorGuardingDistance_ValueChanged);
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
            // warriorLevel
            // 
            this.warriorLevel.Location = new System.Drawing.Point(41, 61);
            this.warriorLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.warriorLevel.Name = "warriorLevel";
            this.warriorLevel.Size = new System.Drawing.Size(144, 21);
            this.warriorLevel.TabIndex = 9;
            this.warriorLevel.ValueChanged += new System.EventHandler(this.warriorLevel_ValueChanged);
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
            // warriorName
            // 
            this.warriorName.Location = new System.Drawing.Point(41, 7);
            this.warriorName.Name = "warriorName";
            this.warriorName.Size = new System.Drawing.Size(144, 21);
            this.warriorName.TabIndex = 6;
            this.warriorName.TextChanged += new System.EventHandler(this.warriorName_TextChanged);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.adornmentHeight);
            this.tabPage3.Controls.Add(this.adornmentWidth);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.adornmentY);
            this.tabPage3.Controls.Add(this.adornmentX);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.adornmentName);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.chooseImage);
            this.tabPage3.Controls.Add(this.adornmentImage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(192, 685);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "装饰品属性";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // adornmentHeight
            // 
            this.adornmentHeight.Location = new System.Drawing.Point(112, 92);
            this.adornmentHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.adornmentHeight.Name = "adornmentHeight";
            this.adornmentHeight.Size = new System.Drawing.Size(65, 21);
            this.adornmentHeight.TabIndex = 10;
            this.adornmentHeight.ValueChanged += new System.EventHandler(this.aHeight_ValueChanged);
            // 
            // adornmentWidth
            // 
            this.adornmentWidth.Location = new System.Drawing.Point(41, 92);
            this.adornmentWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.adornmentWidth.Name = "adornmentWidth";
            this.adornmentWidth.Size = new System.Drawing.Size(65, 21);
            this.adornmentWidth.TabIndex = 9;
            this.adornmentWidth.ValueChanged += new System.EventHandler(this.aWidth_ValueChanged);
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
            // adornmentY
            // 
            this.adornmentY.Location = new System.Drawing.Point(112, 65);
            this.adornmentY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.adornmentY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.adornmentY.Name = "adornmentY";
            this.adornmentY.Size = new System.Drawing.Size(65, 21);
            this.adornmentY.TabIndex = 7;
            this.adornmentY.ValueChanged += new System.EventHandler(this.aY_ValueChanged);
            // 
            // adornmentX
            // 
            this.adornmentX.Location = new System.Drawing.Point(41, 65);
            this.adornmentX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.adornmentX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.adornmentX.Name = "adornmentX";
            this.adornmentX.Size = new System.Drawing.Size(65, 21);
            this.adornmentX.TabIndex = 6;
            this.adornmentX.ValueChanged += new System.EventHandler(this.aX_ValueChanged);
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
            // adornmentName
            // 
            this.adornmentName.Location = new System.Drawing.Point(41, 10);
            this.adornmentName.Name = "adornmentName";
            this.adornmentName.Size = new System.Drawing.Size(148, 21);
            this.adornmentName.TabIndex = 4;
            this.adornmentName.TextChanged += new System.EventHandler(this.aName_TextChanged);
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
            this.chooseImage.Click += new System.EventHandler(this.chooseImage_Click);
            // 
            // adornmentImage
            // 
            this.adornmentImage.Location = new System.Drawing.Point(41, 33);
            this.adornmentImage.Name = "adornmentImage";
            this.adornmentImage.Size = new System.Drawing.Size(104, 21);
            this.adornmentImage.TabIndex = 0;
            this.adornmentImage.TextChanged += new System.EventHandler(this.aImage_TextChanged);
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.map.Controls.Add(this.floor);
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(717, 640);
            this.map.TabIndex = 3;
            // 
            // floor
            // 
            this.floor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.floor.Location = new System.Drawing.Point(186, 374);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(100, 2);
            this.floor.TabIndex = 0;
            this.floor.Text = "label2";
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
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(938, 13);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(76, 39);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.map);
            this.panel.Location = new System.Drawing.Point(15, 68);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(798, 697);
            this.panel.TabIndex = 1;
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(857, 13);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 39);
            this.openFile.TabIndex = 7;
            this.openFile.Text = "打开文件";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // deleteObject
            // 
            this.deleteObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteObject.Location = new System.Drawing.Point(627, 13);
            this.deleteObject.Name = "deleteObject";
            this.deleteObject.Size = new System.Drawing.Size(105, 50);
            this.deleteObject.TabIndex = 16;
            this.deleteObject.Text = "删除";
            this.deleteObject.UseVisualStyleBackColor = true;
            this.deleteObject.Click += new System.EventHandler(this.deleteObject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 781);
            this.Controls.Add(this.deleteObject);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.addWarrior);
            this.Controls.Add(this.addAdornment);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.filePath.ResumeLayout(false);
            this.filePath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapFloorHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warriorX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorGuardingDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warriorLevel)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornmentX)).EndInit();
            this.map.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }







        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage filePath;
        private System.Windows.Forms.NumericUpDown mapFloorHeight;
        private System.Windows.Forms.NumericUpDown mapWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.Button addAdornment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button chooseImage;
        private System.Windows.Forms.TextBox adornmentImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox warriorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown adornmentY;
        private System.Windows.Forms.NumericUpDown adornmentX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adornmentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addWarrior;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown warriorLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown warriorGuardingDistance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown warriorX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown adornmentHeight;
        private System.Windows.Forms.NumericUpDown adornmentWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label floor;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button chooseResourcePath;
        private System.Windows.Forms.TextBox resourcePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox openFilePath;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button chooseWarriorDir;
        private System.Windows.Forms.TextBox warriorDir;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button chooseWarriorPath;
        private System.Windows.Forms.TextBox warriorPath;
        private System.Windows.Forms.Button deleteObject;
    }
}

