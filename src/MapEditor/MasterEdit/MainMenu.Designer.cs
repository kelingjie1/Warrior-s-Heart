namespace masterEdit
{
    partial class MainForm
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
            this.categorybox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MasterList = new System.Windows.Forms.ListBox();
            this.deletmaster = new System.Windows.Forms.Button();
            this.addmaster = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.nametext = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.categorytext = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.StrongGrowText = new System.Windows.Forms.TextBox();
            this.StrongText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.IntelligenceGrowText = new System.Windows.Forms.TextBox();
            this.IntelligenceText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AgilityGrowText = new System.Windows.Forms.TextBox();
            this.AgilityText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PowerGrowText = new System.Windows.Forms.TextBox();
            this.PowerText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PicYSizeText = new System.Windows.Forms.TextBox();
            this.PicXSizeText = new System.Windows.Forms.TextBox();
            this.PicSelectButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PicPathText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CollidMaxYText = new System.Windows.Forms.TextBox();
            this.CollidMinYText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CollidMaxXText = new System.Windows.Forms.TextBox();
            this.CollidMinXText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HitDelayText = new System.Windows.Forms.TextBox();
            this.modifymaster = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // categorybox
            // 
            this.categorybox.FormattingEnabled = true;
            this.categorybox.Location = new System.Drawing.Point(25, 35);
            this.categorybox.Name = "categorybox";
            this.categorybox.Size = new System.Drawing.Size(170, 20);
            this.categorybox.TabIndex = 0;
            this.categorybox.SelectedIndexChanged += new System.EventHandler(this.categorybox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MasterList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 446);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人物列表";
            // 
            // MasterList
            // 
            this.MasterList.FormattingEnabled = true;
            this.MasterList.ItemHeight = 12;
            this.MasterList.Location = new System.Drawing.Point(13, 49);
            this.MasterList.Name = "MasterList";
            this.MasterList.ScrollAlwaysVisible = true;
            this.MasterList.Size = new System.Drawing.Size(170, 352);
            this.MasterList.TabIndex = 0;
            this.MasterList.SelectedIndexChanged += new System.EventHandler(this.MasterList_SelectedIndexChanged);
            // 
            // deletmaster
            // 
            this.deletmaster.Location = new System.Drawing.Point(770, 419);
            this.deletmaster.Name = "deletmaster";
            this.deletmaster.Size = new System.Drawing.Size(75, 33);
            this.deletmaster.TabIndex = 9;
            this.deletmaster.Text = "删除";
            this.deletmaster.UseVisualStyleBackColor = true;
            this.deletmaster.Click += new System.EventHandler(this.deletmaster_Click);
            // 
            // addmaster
            // 
            this.addmaster.Location = new System.Drawing.Point(625, 419);
            this.addmaster.Name = "addmaster";
            this.addmaster.Size = new System.Drawing.Size(75, 33);
            this.addmaster.TabIndex = 8;
            this.addmaster.Text = "新增";
            this.addmaster.UseVisualStyleBackColor = true;
            this.addmaster.Click += new System.EventHandler(this.addmaster_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.nametext);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.categorytext);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.StrongGrowText);
            this.groupBox2.Controls.Add(this.StrongText);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.IntelligenceGrowText);
            this.groupBox2.Controls.Add(this.IntelligenceText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.AgilityGrowText);
            this.groupBox2.Controls.Add(this.AgilityText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PowerGrowText);
            this.groupBox2.Controls.Add(this.PowerText);
            this.groupBox2.Location = new System.Drawing.Point(231, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 187);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本属性";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(21, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 20;
            this.label26.Text = "名字(必填)";
            // 
            // nametext
            // 
            this.nametext.Location = new System.Drawing.Point(87, 158);
            this.nametext.Name = "nametext";
            this.nametext.Size = new System.Drawing.Size(100, 21);
            this.nametext.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 136);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 18;
            this.label22.Text = "分类(必填)";
            // 
            // categorytext
            // 
            this.categorytext.Location = new System.Drawing.Point(87, 134);
            this.categorytext.Name = "categorytext";
            this.categorytext.Size = new System.Drawing.Size(100, 21);
            this.categorytext.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(180, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "成长";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "成长";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "体力";
            // 
            // StrongGrowText
            // 
            this.StrongGrowText.Location = new System.Drawing.Point(228, 104);
            this.StrongGrowText.Name = "StrongGrowText";
            this.StrongGrowText.Size = new System.Drawing.Size(100, 21);
            this.StrongGrowText.TabIndex = 13;
            // 
            // StrongText
            // 
            this.StrongText.Location = new System.Drawing.Point(56, 104);
            this.StrongText.Name = "StrongText";
            this.StrongText.Size = new System.Drawing.Size(100, 21);
            this.StrongText.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(180, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "成长";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "智力";
            // 
            // IntelligenceGrowText
            // 
            this.IntelligenceGrowText.Location = new System.Drawing.Point(228, 77);
            this.IntelligenceGrowText.Name = "IntelligenceGrowText";
            this.IntelligenceGrowText.Size = new System.Drawing.Size(100, 21);
            this.IntelligenceGrowText.TabIndex = 9;
            // 
            // IntelligenceText
            // 
            this.IntelligenceText.Location = new System.Drawing.Point(56, 77);
            this.IntelligenceText.Name = "IntelligenceText";
            this.IntelligenceText.Size = new System.Drawing.Size(100, 21);
            this.IntelligenceText.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "敏捷";
            // 
            // AgilityGrowText
            // 
            this.AgilityGrowText.Location = new System.Drawing.Point(228, 50);
            this.AgilityGrowText.Name = "AgilityGrowText";
            this.AgilityGrowText.Size = new System.Drawing.Size(100, 21);
            this.AgilityGrowText.TabIndex = 5;
            // 
            // AgilityText
            // 
            this.AgilityText.Location = new System.Drawing.Point(56, 50);
            this.AgilityText.Name = "AgilityText";
            this.AgilityText.Size = new System.Drawing.Size(100, 21);
            this.AgilityText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "成长";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "力量";
            // 
            // PowerGrowText
            // 
            this.PowerGrowText.Location = new System.Drawing.Point(228, 23);
            this.PowerGrowText.Name = "PowerGrowText";
            this.PowerGrowText.Size = new System.Drawing.Size(100, 21);
            this.PowerGrowText.TabIndex = 1;
            // 
            // PowerText
            // 
            this.PowerText.Location = new System.Drawing.Point(56, 23);
            this.PowerText.Name = "PowerText";
            this.PowerText.Size = new System.Drawing.Size(100, 21);
            this.PowerText.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.textBox24);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.textBox25);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.textBox26);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBox20);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.textBox21);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.textBox22);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.textBox15);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.textBox16);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(626, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 401);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它属性(不可编辑)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 315);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 38;
            this.label23.Text = "魔法防御";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(78, 312);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(100, 21);
            this.textBox24.TabIndex = 37;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 287);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 36;
            this.label24.Text = "物理防御";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(78, 284);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(100, 21);
            this.textBox25.TabIndex = 35;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(30, 260);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 34;
            this.label25.Text = "加速度";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(78, 257);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(100, 21);
            this.textBox26.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 231);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 32;
            this.label18.Text = "移动速度";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(78, 228);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 21);
            this.textBox19.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 204);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 30;
            this.label19.Text = "攻击范围";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(78, 201);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 21);
            this.textBox20.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 177);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 28;
            this.label20.Text = "攻击间隔";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(78, 174);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(100, 21);
            this.textBox21.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 148);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 26;
            this.label21.Text = "魔法攻击";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(78, 145);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 21);
            this.textBox22.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "物理攻击";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "击退";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(78, 116);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 21);
            this.textBox15.TabIndex = 23;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(78, 35);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 21);
            this.textBox18.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 22;
            this.label15.Text = "生命值";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(78, 62);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 21);
            this.textBox17.TabIndex = 19;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(78, 89);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 21);
            this.textBox16.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "击退抵抗";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PicYSizeText);
            this.groupBox4.Controls.Add(this.PicXSizeText);
            this.groupBox4.Controls.Add(this.PicSelectButton);
            this.groupBox4.Controls.Add(this.pictureBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.PicPathText);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.CollidMaxYText);
            this.groupBox4.Controls.Add(this.CollidMinYText);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.CollidMaxXText);
            this.groupBox4.Controls.Add(this.CollidMinXText);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.HitDelayText);
            this.groupBox4.Location = new System.Drawing.Point(231, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 253);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "高级属性";
            // 
            // PicYSizeText
            // 
            this.PicYSizeText.Location = new System.Drawing.Point(192, 99);
            this.PicYSizeText.Name = "PicYSizeText";
            this.PicYSizeText.Size = new System.Drawing.Size(100, 21);
            this.PicYSizeText.TabIndex = 23;
            // 
            // PicXSizeText
            // 
            this.PicXSizeText.Location = new System.Drawing.Point(73, 99);
            this.PicXSizeText.Name = "PicXSizeText";
            this.PicXSizeText.Size = new System.Drawing.Size(100, 21);
            this.PicXSizeText.TabIndex = 22;
            // 
            // PicSelectButton
            // 
            this.PicSelectButton.Location = new System.Drawing.Point(246, 122);
            this.PicSelectButton.Name = "PicSelectButton";
            this.PicSelectButton.Size = new System.Drawing.Size(46, 23);
            this.PicSelectButton.TabIndex = 21;
            this.PicSelectButton.Text = "选择";
            this.PicSelectButton.UseVisualStyleBackColor = true;
            this.PicSelectButton.Click += new System.EventHandler(this.PicSelectButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(20, 163);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(99, 79);
            this.pictureBox.TabIndex = 20;
            this.pictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "图片";
            // 
            // PicPathText
            // 
            this.PicPathText.Location = new System.Drawing.Point(73, 125);
            this.PicPathText.Name = "PicPathText";
            this.PicPathText.Size = new System.Drawing.Size(166, 21);
            this.PicPathText.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "图片大小";
            // 
            // CollidMaxYText
            // 
            this.CollidMaxYText.Location = new System.Drawing.Point(192, 72);
            this.CollidMaxYText.Name = "CollidMaxYText";
            this.CollidMaxYText.Size = new System.Drawing.Size(100, 21);
            this.CollidMaxYText.TabIndex = 16;
            // 
            // CollidMinYText
            // 
            this.CollidMinYText.Location = new System.Drawing.Point(73, 72);
            this.CollidMinYText.Name = "CollidMinYText";
            this.CollidMinYText.Size = new System.Drawing.Size(100, 21);
            this.CollidMinYText.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "碰撞大小";
            // 
            // CollidMaxXText
            // 
            this.CollidMaxXText.Location = new System.Drawing.Point(192, 46);
            this.CollidMaxXText.Name = "CollidMaxXText";
            this.CollidMaxXText.Size = new System.Drawing.Size(100, 21);
            this.CollidMaxXText.TabIndex = 13;
            // 
            // CollidMinXText
            // 
            this.CollidMinXText.Location = new System.Drawing.Point(73, 46);
            this.CollidMinXText.Name = "CollidMinXText";
            this.CollidMinXText.Size = new System.Drawing.Size(100, 21);
            this.CollidMinXText.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "命中延迟";
            // 
            // HitDelayText
            // 
            this.HitDelayText.Location = new System.Drawing.Point(73, 19);
            this.HitDelayText.Name = "HitDelayText";
            this.HitDelayText.Size = new System.Drawing.Size(100, 21);
            this.HitDelayText.TabIndex = 8;
            // 
            // modifymaster
            // 
            this.modifymaster.Location = new System.Drawing.Point(699, 419);
            this.modifymaster.Name = "modifymaster";
            this.modifymaster.Size = new System.Drawing.Size(75, 33);
            this.modifymaster.TabIndex = 10;
            this.modifymaster.Text = "修改";
            this.modifymaster.UseVisualStyleBackColor = true;
            this.modifymaster.Click += new System.EventHandler(this.modifymaster_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 470);
            this.Controls.Add(this.modifymaster);
            this.Controls.Add(this.deletmaster);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.addmaster);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.categorybox);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "任务编辑器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox categorybox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox MasterList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AgilityGrowText;
        private System.Windows.Forms.TextBox AgilityText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PowerGrowText;
        private System.Windows.Forms.TextBox PowerText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deletmaster;
        private System.Windows.Forms.Button addmaster;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox StrongGrowText;
        private System.Windows.Forms.TextBox StrongText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox IntelligenceGrowText;
        private System.Windows.Forms.TextBox IntelligenceText;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PicPathText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CollidMaxYText;
        private System.Windows.Forms.TextBox CollidMinYText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CollidMaxXText;
        private System.Windows.Forms.TextBox CollidMinXText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HitDelayText;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox categorytext;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox nametext;
        private System.Windows.Forms.Button modifymaster;
        private System.Windows.Forms.Button PicSelectButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox PicYSizeText;
        private System.Windows.Forms.TextBox PicXSizeText;
    }
}

