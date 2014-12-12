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

namespace EditToolsApp.tabforms
{
    public partial class senceEditForm : Form
    {
        edittools rootFrom;
        Sence show_sence;
        int sectionindex;
        int senceindex;
        public senceEditForm(edittools parentFrom,int index1, int index2)
        {
            InitializeComponent();
            rootFrom = parentFrom;
            show_sence = parentFrom.root.sections[index1].sences[index2];
            sectionindex = index1;
            senceindex = index2;
        }

        public void show_sence_from()
        {
            this.textBox1.Text = show_sence.senceTitle;
            this.textBox2.Text = show_sence.senceDesc;
            this.PicPathText.Text = show_sence.senceBackGroundPic;
            this.TopLevel = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Show();
        }

        private void 保存关卡_Click(object sender, EventArgs e)
        {
            show_sence.senceTitle = this.textBox1.Text;
            show_sence.senceDesc = this.textBox2.Text;
            show_sence.senceBackGroundPic = this.PicPathText.Text;
            rootFrom.update_sence_view(sectionindex, senceindex);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SencePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileName != ""))
            {
                pictureBox.ImageLocation = openfile.FileName;
                PicPathText.Text = openfile.SafeFileName;
            }
        }

       
    }
}
