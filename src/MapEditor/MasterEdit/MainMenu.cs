using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using masterEdit.masterxmldata;
using masterEdit.tools;
using System.IO;


namespace masterEdit
{

    public partial class MainForm : Form
    {
        public Bitmap myBitmap;
        innerCategoryList stCategory = new innerCategoryList();
        public MainForm()
        {
            InitializeComponent();
            InitializeAllMasterXml();
        }

        public void InitializeAllMasterXml()
        {
            DirectoryInfo TheFolder = new DirectoryInfo(@"masterXmlFolder");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                innerMaster innermaster = new innerMaster();

                innermaster.master = (Master)XmlSerializer.LoadFromXml("masterXmlFolder/" + NextFile.Name, innermaster.master.GetType());
                innermaster.name = NextFile.Name;

                if (innermaster.master != null)
                {
                    int index = categorybox.FindString(innermaster.master.Category);
                    if (index < 0)
                    {
                        //视图
                        categorybox.Items.Add(innermaster.master.Category);

                        innerCategory oneCategory = new innerCategory();
                        oneCategory.categoryname = innermaster.master.Category;
                        oneCategory.innerMasterList.Add(innermaster);
                        stCategory.categorylist.Add(oneCategory);
                    }
                    else
                    {
                        stCategory.categorylist[index].innerMasterList.Add(innermaster);
                       
                    }
                }
            }

            if (categorybox.Items.Count > 0)
            {
                categorybox.SelectedIndex = 0;
                MasterList.Items.Clear();
                for (int i = 0; i < stCategory.categorylist[categorybox.SelectedIndex].innerMasterList.Count; ++i)
                {
                    MasterList.Items.Add(stCategory.categorylist[categorybox.SelectedIndex].innerMasterList[i].name);
                }
            }
           

        }
        

        private void MasterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryindex = categorybox.SelectedIndex;
            int masterindex = MasterList.SelectedIndex;
            if (masterindex < 0)
                return;

            innerMaster innermaster = stCategory.categorylist[categoryindex].innerMasterList[masterindex];
            updatedatabase2view(innermaster);
        }

        private void categorybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterList.Items.Clear();
            for (int i = 0; i < stCategory.categorylist[categorybox.SelectedIndex].innerMasterList.Count; ++i)
            {
                MasterList.Items.Add(stCategory.categorylist[categorybox.SelectedIndex].innerMasterList[i].name);
            }
        }

        private void updatedatabase2view(innerMaster innermaster)
        {
            PowerText.Text = innermaster.master.BasicAttr.Power;
            AgilityText.Text = innermaster.master.BasicAttr.Agility;
            StrongText.Text = innermaster.master.BasicAttr.Strong;
            IntelligenceText.Text = innermaster.master.BasicAttr.Intelligence;

            PowerGrowText.Text = innermaster.master.BasicAttr.PowerGrow;
            AgilityGrowText.Text = innermaster.master.BasicAttr.AgilityGrow;
            StrongGrowText.Text = innermaster.master.BasicAttr.StrongGrow;
            IntelligenceGrowText.Text = innermaster.master.BasicAttr.IntelligenceGrow;
            
            categorytext.Text = innermaster.master.Category;
            nametext.Text = innermaster.name;

            HitDelayText.Text = innermaster.master.OtherAttr.HitDelay;
            CollidMaxXText.Text = innermaster.master.OtherAttr.collide.MaxX;
            CollidMinXText.Text = innermaster.master.OtherAttr.collide.MinX;
            CollidMaxYText.Text = innermaster.master.OtherAttr.collide.MaxY;
            CollidMinYText.Text = innermaster.master.OtherAttr.collide.MinY;

            PicXSizeText.Text = innermaster.master.OtherAttr.picInfo.PicXSize;
            PicYSizeText.Text = innermaster.master.OtherAttr.picInfo.PicYSize;
            PicPathText.Text = innermaster.master.OtherAttr.picInfo.PicPath;
          
        }

        private void updateview2database(innerMaster innermaster)
        {
            innermaster.name = nametext.Text;
            innermaster.master.Category = categorytext.Text;
            innermaster.master.Level = "1";

            basicAttr BasicAttr = new basicAttr();
            //基本属性节点
            BasicAttr.Power = PowerText.Text;
            BasicAttr.Agility = AgilityText.Text;
            BasicAttr.Strong = StrongText.Text;
            BasicAttr.Intelligence = IntelligenceText.Text;
            BasicAttr.PowerGrow = PowerGrowText.Text;
            BasicAttr.AgilityGrow = AgilityGrowText.Text;
            BasicAttr.StrongGrow = StrongGrowText.Text;
            BasicAttr.IntelligenceGrow = IntelligenceGrowText.Text;

            otherAttr OtherAttr = new otherAttr();
            OtherAttr.HitDelay = HitDelayText.Text;
            //碰撞节点
            Collide collide = new Collide();
            collide.MaxX = CollidMaxXText.Text;
            collide.MinX = CollidMinXText.Text;
            collide.MaxY = CollidMaxYText.Text;
            collide.MinY = CollidMinYText.Text;
            OtherAttr.collide = collide;

            //图片节点
            PicInfo picInfo = new PicInfo();
            picInfo.PicXSize = PicXSizeText.Text;
            picInfo.PicYSize = PicYSizeText.Text;
            picInfo.PicPath = PicPathText.Text;
            OtherAttr.picInfo = picInfo;

            innermaster.master.BasicAttr = BasicAttr;
            innermaster.master.OtherAttr = OtherAttr;
        }

        private void addmaster_Click(object sender, EventArgs e)
        {
            if (categorytext.Text == "" || nametext.Text == "")
            {
                MessageBox.Show("分类、名字、图片必须填");
                return;
            }

            innerMaster innermaster = new innerMaster();
            updateview2database(innermaster);

            //查找有不有这个分类
            //没有分类 新增结构出来
            int index = categorybox.FindString(innermaster.master.Category);
            if (index < 0)
            {

                innerCategory oneCategory = new innerCategory();
                oneCategory.categoryname = innermaster.master.Category;
                stCategory.categorylist.Add(oneCategory);

                oneCategory.innerMasterList.Add(innermaster);
                categorybox.Items.Add(innermaster.master.Category);
            }//存在，并且选中的分类 立即展示
            else if (categorybox.SelectedIndex == index)
            {
                if (MasterList.FindString(categorytext.Text) < 0)
                {
                    stCategory.categorylist[index].innerMasterList.Add(innermaster);
                    MasterList.Items.Add(innermaster.name);
                }
                else
                {
                    MessageBox.Show("存在相同名字怪物");
                }

            }//存在，并且没有选中的分类 不展示
            else
            {
                for (int i = 0; i < stCategory.categorylist[index].innerMasterList.Count; ++i)
                {
                    if (stCategory.categorylist[index].innerMasterList[i].name == innermaster.name)
                    {
                        MessageBox.Show("存在相同名字怪物");
                        return;
                    }
                }
                stCategory.categorylist[index].innerMasterList.Add(innermaster);
            }
            XmlSerializer.SaveToXml("masterXmlFolder/" + innermaster.name, innermaster.master, innermaster.master.GetType(), "");
            MessageBox.Show("保存成功");
        }

        private void modifymaster_Click(object sender, EventArgs e)
        {
            int masterindex = MasterList.SelectedIndex;
            if (masterindex < 0)
                return;

            int categoryindex = categorybox.SelectedIndex;

            innerMaster innermaster = stCategory.categorylist[categoryindex].innerMasterList[masterindex];
            updateview2database(innermaster);
            categorybox.Text = innermaster.master.Category;
            XmlSerializer.SaveToXml("masterXmlFolder/" + innermaster.name, innermaster.master, innermaster.master.GetType(), "");
            MessageBox.Show("保存成功");
        }

        private void deletmaster_Click(object sender, EventArgs e)
        {
            int masterindex = MasterList.SelectedIndex;
            if (masterindex < 0)
                return;
            int categoryindex = categorybox.SelectedIndex;

            innerMaster innermaster = stCategory.categorylist[categoryindex].innerMasterList[masterindex];
            stCategory.categorylist[categoryindex].innerMasterList.Remove(innermaster);
            MasterList.Items.Clear();
            for (int i = 0; i < stCategory.categorylist[categoryindex].innerMasterList.Count; ++i)
            {
                MasterList.Items.Add(stCategory.categorylist[categoryindex].innerMasterList[i].name);
            }

            if (File.Exists("masterXmlFolder/" + innermaster.name))
            {
                File.Delete("masterXmlFolder/" + innermaster.name);
            }


        }

        private void PicSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileName != ""))
            {
                myBitmap = new Bitmap(openfile.FileName);
                pictureBox.Image = (Image)myBitmap;
                pictureBox.ImageLocation = openfile.FileName;
                PicPathText.Text = openfile.SafeFileName;
                Size size = myBitmap.Size;
                int MinX = size.Width;
                int MaxX = 0;
                int MinY = size.Height;
                int MaxY = 0;
                for (int i = 0; i < size.Width; i = i + 10)
                {
                    for (int j = 0; j < size.Height; j = j + 10)
                    {
                        Color PixeColor = myBitmap.GetPixel(i, j);
                        if (PixeColor.A > 200) //如果不为透明色
                        {
                            if (i < MinX)
                            {
                                MinX = i;
                            }
                            else if (i > MaxX)
                            {
                                MaxX = i;
                            }

                            if (j < MinY)
                            {
                                MinY = j;
                            }
                            else if (j > MaxY)
                            {
                                MaxY = j;
                            }
                        }
                    }
                    
                }
                CollidMinXText.Text = MinX.ToString();
                CollidMaxXText.Text = MaxX.ToString();
                CollidMinYText.Text = MinY.ToString();
                CollidMaxYText.Text = MaxY.ToString();
                PicXSizeText.Text = size.Width.ToString();
                PicYSizeText.Text = size.Height.ToString();
                
            }
       

        }

    }
}
