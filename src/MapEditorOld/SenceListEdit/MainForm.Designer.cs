

namespace EditToolsApp
{
    partial class edittools
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
        /// 
      

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.section_view = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.treeview_sectionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加章节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除章节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeview_rootMenuStrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加章节ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeview_senceMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除关卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.treeview_sectionMenuStrip.SuspendLayout();
            this.treeview_rootMenuStrp.SuspendLayout();
            this.treeview_senceMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // section_view
            // 
            this.section_view.Location = new System.Drawing.Point(0, 9);
            this.section_view.Name = "section_view";
            this.section_view.Size = new System.Drawing.Size(169, 332);
            this.section_view.TabIndex = 0;
            this.section_view.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.section_view_NodeMouseClick);
            this.section_view.DoubleClick += new System.EventHandler(this.section_view_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Controls.Add(this.section_view);
            this.groupBox1.Location = new System.Drawing.Point(0, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 442);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(175, 9);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(509, 340);
            this.tabControl.TabIndex = 1;
            // 
            // treeview_sectionMenuStrip
            // 
            this.treeview_sectionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加章节ToolStripMenuItem,
            this.删除章节ToolStripMenuItem});
            this.treeview_sectionMenuStrip.Name = "treeview_sectionMenuStrip";
            this.treeview_sectionMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // 增加章节ToolStripMenuItem
            // 
            this.增加章节ToolStripMenuItem.Name = "增加章节ToolStripMenuItem";
            this.增加章节ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加章节ToolStripMenuItem.Text = "增加关卡";
            this.增加章节ToolStripMenuItem.Click += new System.EventHandler(this.增加关卡ToolStripMenuItem_Click);
            // 
            // 删除章节ToolStripMenuItem
            // 
            this.删除章节ToolStripMenuItem.Name = "删除章节ToolStripMenuItem";
            this.删除章节ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除章节ToolStripMenuItem.Text = "删除章节";
            this.删除章节ToolStripMenuItem.Click += new System.EventHandler(this.删除章节ToolStripMenuItem_Click);
            // 
            // treeview_rootMenuStrp
            // 
            this.treeview_rootMenuStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加章节ToolStripMenuItem1});
            this.treeview_rootMenuStrp.Name = "contextMenuStrip1";
            this.treeview_rootMenuStrp.Size = new System.Drawing.Size(125, 26);
            // 
            // 增加章节ToolStripMenuItem1
            // 
            this.增加章节ToolStripMenuItem1.Name = "增加章节ToolStripMenuItem1";
            this.增加章节ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.增加章节ToolStripMenuItem1.Text = "增加章节";
            this.增加章节ToolStripMenuItem1.Click += new System.EventHandler(this.增加章节ToolStripMenuItem1_Click);
            // 
            // treeview_senceMenuStrip
            // 
            this.treeview_senceMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除关卡ToolStripMenuItem});
            this.treeview_senceMenuStrip.Name = "treeview_senceMenuStrip";
            this.treeview_senceMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // 删除关卡ToolStripMenuItem
            // 
            this.删除关卡ToolStripMenuItem.Name = "删除关卡ToolStripMenuItem";
            this.删除关卡ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除关卡ToolStripMenuItem.Text = "删除关卡";
            this.删除关卡ToolStripMenuItem.Click += new System.EventHandler(this.删除关卡ToolStripMenuItem_Click);
            // 
            // edittools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "edittools";
            this.Text = "场景列表编辑器";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.treeview_sectionMenuStrip.ResumeLayout(false);
            this.treeview_rootMenuStrp.ResumeLayout(false);
            this.treeview_senceMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView section_view;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ContextMenuStrip treeview_sectionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 增加章节ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除章节ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeview_rootMenuStrp;
        private System.Windows.Forms.ToolStripMenuItem 增加章节ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip treeview_senceMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 删除关卡ToolStripMenuItem;

    }
}

