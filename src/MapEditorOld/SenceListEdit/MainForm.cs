using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditToolsApp.myclass;
using EditToolsApp.tools;
using EditToolsApp.tabforms;

namespace EditToolsApp
{
    public partial class edittools : Form
    {
        public Root root;
        public TreeNode rootNode;

        public edittools()
        {
            InitializeComponent();
            InitializeXml();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void InitializeXml()
        {
            root = new Root();
            root = (Root)XmlSerializer.LoadFromXml(@"senctionlist/sectionlist.xml", root.GetType());

            rootNode = new TreeNode("章节编辑");
            if (root != null)
            {
                for (int i = 0; i < root.sections.Count(); ++i)
                {
                    TreeNode myTreeSenctionNode = new TreeNode(root.sections[i].sectionTitle);
                    rootNode.Nodes.Add(myTreeSenctionNode);
                    for (int j = 0; j < root.sections[i].sences.Count(); ++j)
                    {
                        TreeNode myTreeSenceNode = new TreeNode(root.sections[i].sences[j].senceTitle);
                        rootNode.Nodes[i].Nodes.Add(myTreeSenceNode);
                    }
                }
                section_view.Nodes.Add(rootNode);
            }
            else
            {
                root = new Root();

                Section section = new Section();
                section.sectionTitle = "章节1";
               
                root.sections = new List<Section>();
                root.sections.Add(section);
                Sence sence = new Sence();
                sence.senceTitle = "关卡1";
                root.sections[0].sences = new List<Sence>();
                root.sections[0].sences.Add(sence);

                TreeNode myTreeSenctionNode = new TreeNode("章节1");
                rootNode.Nodes.Add(myTreeSenctionNode);
               
                TreeNode myTreeSenceNode = new TreeNode("关卡1");
                rootNode.Nodes[0].Nodes.Add(myTreeSenceNode);
                
                section_view.Nodes.Add(rootNode);
            }
          
        }

        public void update_section_view(int index)
        {
           
            if (index < root.sections.Count && index < rootNode.Nodes.Count)
            {
                rootNode.Nodes[index].Text = root.sections[index].sectionTitle;
            }
            //section_view.Refresh();
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }

        public void update_sence_view(int index1, int index2)
        {
            if (index1 < root.sections.Count && index1 < rootNode.Nodes.Count)
            {
                if (index2 < root.sections[index1].sences.Count && index2 < rootNode.Nodes[index1].Nodes.Count)
                {
                    rootNode.Nodes[index1].Nodes[index2].Text = root.sections[index1].sences[index2].senceTitle;
                }
            }
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }
        
        private void section_view_Click(object sender, EventArgs e)
        {
            //章节点击
            if (section_view.SelectedNode.Level == 1)
            {
                tabControl.Controls.Clear();
                TabPage tbMobile = new TabPage(section_view.SelectedNode.Text);
                sectionEditForm From = new sectionEditForm(this, section_view.SelectedNode.Index);
                From.show_section_from();
                tabControl.Controls.Add(tbMobile);
                tbMobile.Controls.Add(From);
            }
            else if (section_view.SelectedNode.Level == 2)
            {
                tabControl.Controls.Clear();
                TabPage tbMobile = new TabPage(section_view.SelectedNode.Text);
                senceEditForm From = new senceEditForm(this, section_view.SelectedNode.Parent.Index, section_view.SelectedNode.Index);
                From.show_sence_from();
                tabControl.Controls.Add(tbMobile);
                tbMobile.Controls.Add(From);
            }
        }

        private void section_view_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Level == 0)
                {
                    Point pos = new Point(e.Node.Bounds.X + e.Node.Bounds.Width, e.Node.Bounds.Y + e.Node.Bounds.Height / 2);
                    this.treeview_rootMenuStrp.Show(this.section_view, pos);
                }
                else if (e.Node.Level == 1)
                {
                    Point pos = new Point(e.Node.Bounds.X + e.Node.Bounds.Width, e.Node.Bounds.Y + e.Node.Bounds.Height / 2);
                    this.treeview_sectionMenuStrip.Show(this.section_view, pos);
                }
                else if (e.Node.Level == 2)
                {
                    Point pos = new Point(e.Node.Bounds.X + e.Node.Bounds.Width, e.Node.Bounds.Y + e.Node.Bounds.Height / 2);
                    this.treeview_senceMenuStrip.Show(this.section_view, pos);
                }
                 
            }
        }

        public void set_default_sectionitem(int index, Section new_section)
        {
            string strI = index.ToString();
            new_section.sectionTitle = "章节 " + strI;
            new_section.sectionDesc = "这是章节" + strI + "的描述";
            new_section.sectionBackGroundPic = "section_map" + strI;
        }

        public void set_default_senceitem(int index, Sence new_sence)
        {
            string strI = index.ToString();
            new_sence.senceTitle = "关卡 " + strI;
            new_sence.senceDesc = "这是关卡" + strI + "的描述";
            new_sence.senceBackGroundPic = "sence_map" + strI;
            new_sence.senceType = "普通关卡";
        }




        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show( "确定保存么？", "提示", MessageBoxButtons.YesNo ) == DialogResult.Yes )
            {
                XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
            }

        }

        private void 增加章节ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //数据层
            int section_num = 0;
            Section new_section = new Section();
 
            section_num = root.sections.Count();
            set_default_sectionitem(section_num, new_section);

            root.sections.Add(new_section);

            //试图层
            TreeNode myTreeNode = new TreeNode(new_section.sectionTitle);
            rootNode.Nodes.Add(myTreeNode);
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }

        private void 删除章节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //先找到改节点删除数据层和视图层

            int index = section_view.SelectedNode.Index;
            if (index < root.sections.Count() && index < rootNode.Nodes.Count)
            {
                root.sections.Remove(root.sections[index]);
                rootNode.Nodes.Remove(section_view.SelectedNode);
            }
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }


        private void 增加关卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //数据层 试图层
            int index = section_view.SelectedNode.Index;
            if (index < root.sections.Count() && index < rootNode.Nodes.Count)
            {
                Sence new_sence = new Sence();
                if (root.sections[index].sences == null)
                {
                    root.sections[index].sences = new List<Sence>();
                }
                set_default_senceitem(root.sections[index].sences.Count, new_sence);
                root.sections[index].sences.Add(new_sence);
                TreeNode myTreeNode = new TreeNode(new_sence.senceTitle);
                rootNode.Nodes[index].Nodes.Add(myTreeNode);
            }
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }


        private void 删除关卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //先找到改节点删除数据层和视图层

            int index = section_view.SelectedNode.Index;
            int parentindex = section_view.SelectedNode.Parent.Index;
            if (parentindex < root.sections.Count() && parentindex < rootNode.Nodes.Count && index < root.sections[parentindex].sences.Count() && index < rootNode.Nodes[parentindex].Nodes.Count)
            {
                root.sections[parentindex].sences.Remove(root.sections[parentindex].sences[index]);
                rootNode.Nodes[parentindex].Nodes.Remove(section_view.SelectedNode);
            }
            XmlSerializer.SaveToXml(@"senctionlist/sectionlist.xml", root, root.GetType(), "");
        }

    }
}
