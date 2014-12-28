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
    public partial class sectionEditForm : Form
    {
        Section show_setcion;
        edittools rootFrom;
        int index;
        public sectionEditForm(edittools parentFrom,int Index)
        {
            InitializeComponent();
            index = Index;
            show_setcion = parentFrom.root.sections[index];
            rootFrom = parentFrom;
           
        }

        public void show_section_from()
        {
            this.textBox2.Text = show_setcion.sectionTitle;
            this.textBox3.Text = show_setcion.sectionDesc;
            this.PicPathText.Text = show_setcion.sectionBackGroundPic;
            this.TopLevel = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Show();
        }

        private void section_buttton_save_Click(object sender, EventArgs e)
        {
            show_setcion.sectionTitle = this.textBox2.Text;
            show_setcion.sectionDesc = this.textBox3.Text;
            show_setcion.sectionBackGroundPic = this.PicPathText.Text;
            rootFrom.update_section_view(index);
        }

        private void PicPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileName != ""))
            {
                SencePicData.ImageLocation = openfile.FileName;
                PicPathText.Text = openfile.SafeFileName;
            }
        }

      
    }
}
