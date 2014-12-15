using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace MapEditor
{
    public partial class Form1 : Form
    {
        bool mouseDown;
        MyPictureBox chooseObj;
        Point mouseOffset;
        public Form1()
        {
            InitializeComponent();
            ReadSetting();
            MapSize_ValueChanged(null, null);
            mFloorHeight_ValueChanged(null, null);
        }
        public static string GetRelativePath(string src, string dest)
        {
            if (!src.EndsWith("\\")) src += "\\";    //如果不是以"\"结尾的加上"\"
            int intIndex = -1, intPos = src.IndexOf('\\');
            ///以"\"为分界比较从开始处到第一个"\"处对两个地址进行比较,如果相同则扩展到
            ///下一个"\"处;直到比较出不同或第一个地址的结尾.
            while (intPos >= 0)
            {
                intPos++;
                if (string.Compare(src, 0, dest, 0, intPos, true) != 0) break;
                intIndex = intPos;
                intPos = src.IndexOf('\\', intPos);
            }

            ///如果从不是第一个"\"处开始有不同,则从最后一个发现有不同的"\"处开始将strPath2
            ///的后面部分付值给自己,在strPath1的同一个位置开始望后计算每有一个"\"则在strPath2
            ///的前面加上一个"..\"(经过转义后就是"..\\").
            if (intIndex >= 0)
            {
                dest = dest.Substring(intIndex);
                intPos = src.IndexOf("\\", intIndex);
                while (intPos >= 0)
                {
                    dest = "..\\" + dest;
                    intPos = src.IndexOf("\\", intPos + 1);
                }
            }
            //否则直接返回strPath2
            return dest;
        }
        void ReadSetting()
        {
            if (!File.Exists("setting.xml"))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("setting.xml");
            XmlElement root = doc.DocumentElement;
            XmlElement resourcePathNode = (XmlElement)root.GetElementsByTagName("ResourcePath").Item(0);
            resourcePath.Text = resourcePathNode.InnerText;
        }

        private void MapSize_ValueChanged(object sender, EventArgs e)
        {
            map.Size = new Size((int)mapWidth.Value, 640);
            floor.Size = new Size((int)mapWidth.Value, 1);
        }
        private void mFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            floor.Location = new Point(0, map.Height - (int)mapFloorHeight.Value);
        }

        void map_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }
        void object_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            chooseObj = sender as MyPictureBox;
            mouseOffset = new Point(Cursor.Position.X - chooseObj.Location.X, Cursor.Position.Y - chooseObj.Location.Y);
            mouseDown = true;
            UpdateUI();
        }
        void object_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MyPictureBox pic = sender as MyPictureBox;
            if (mouseDown)
            {
                pic.Location = new Point(Cursor.Position.X - mouseOffset.X, Cursor.Position.Y - mouseOffset.Y);
            }
            if (pic.Tag as Warrior != null)
            {
                Warrior warrior = pic.Tag as Warrior;
                
            }
            else if (pic.Tag as Adornment != null)
            {
                Adornment adornment = pic.Tag as Adornment;
                adornment.x = pic.Location.X + map.HorizontalScroll.Value;
                adornment.y = map.Height - pic.Location.Y;
            }
            UpdateUI();
        }
        void object_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDown = false;
        }


        MyPictureBox CreateAdorment()
        {
            MyPictureBox pic = new MyPictureBox();
            Adornment adornment = new Adornment();
            pic.Tag = adornment;
            //pic.SizeMode = PictureBoxSizeMode.StretchImage;
            //pic.BorderStyle = BorderStyle.FixedSingle;
            pic.MouseDown += object_MouseDown;
            pic.MouseMove += object_MouseMove;
            pic.MouseUp += object_MouseUp;
            map.Controls.Add(pic);
            pic.BringToFront();
            AdjustPictureBox(pic, adornment);
            return pic;
        }
        private void addAdornment_Click(object sender, EventArgs e)
        {
            CreateAdorment();
        }
        MyPictureBox CreateWarrior()
        {
            MyPictureBox pic = new MyPictureBox();
            Warrior warrior = new Warrior();
            pic.Tag = warrior;
            pic.Size = new Size(100, 100);
            //pic.SizeMode = PictureBoxSizeMode.StretchImage;
            //pic.BorderStyle = BorderStyle.FixedSingle;
            pic.MouseDown += object_MouseDown;
            pic.MouseMove += object_MouseMove;
            pic.MouseUp += object_MouseUp;
            pic.BringToFront();
            map.Controls.Add(pic);
            return pic;
        }
        private void addWarrior_Click(object sender, EventArgs e)
        {
            CreateWarrior();
        }

        void AdjustPictureBox(MyPictureBox pic, Warrior warrior)
        {

        }
        void AdjustPictureBox(MyPictureBox pic, Adornment adornment=null)
        {
            if (adornment==null)
            {
                adornment = pic.Tag as Adornment;
            }
            pic.Location = new Point(adornment.x - map.HorizontalScroll.Value, map.Height - adornment.y);
            pic.Size = new Size(adornment.width, adornment.height);
            if (adornment.image == null || adornment.image.Equals(""))
            {
                pic.Image = null;
                pic.Invalidate();
            }
            else
            {
                pic.Image = Image.FromFile(resourcePath.Text + "\\" + adornment.image);
                pic.Invalidate();
            }
        }

        void UpdateUI()
        {
            if (chooseObj==null)
            {
                return;
            }
            if (chooseObj.Tag as Warrior != null)
            {
                Warrior warrior = chooseObj.Tag as Warrior;
                tabControl.SelectedIndex = 1;
            }
            else if (chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                tabControl.SelectedIndex = 2;
                adornmentName.Text = adornment.name;
                adornmentImage.Text = adornment.image;
                adornmentX.Value = adornment.x;
                adornmentY.Value = adornment.y;
                adornmentWidth.Value = adornment.width;
                adornmentHeight.Value = adornment.height;

            }
        }

        private void aName_TextChanged(object sender, EventArgs e)
        {
            if (chooseObj!=null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.name = adornmentName.Text;
            }
        }

        private void aImage_TextChanged(object sender, EventArgs e)
        {
            if (chooseObj != null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.image = adornmentImage.Text;
                if (adornment.image == null || adornment.image.Equals(""))
                {
                    chooseObj.Image = null;
                    chooseObj.Invalidate();
                }
                else
                {
                    chooseObj.Image = Image.FromFile(resourcePath.Text + "\\" + adornmentImage.Text);
                    chooseObj.Invalidate();
                }
            }
        }

        private void aX_ValueChanged(object sender, EventArgs e)
        {
            if (chooseObj != null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.x = (int)adornmentX.Value;
                chooseObj.Location = new Point(adornment.x - map.HorizontalScroll.Value, map.Height - adornment.y);
            }
        }

        private void aY_ValueChanged(object sender, EventArgs e)
        {
            if (chooseObj != null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.y = (int)adornmentY.Value;
                chooseObj.Location = new Point(adornment.x - map.HorizontalScroll.Value, map.Height - adornment.y);
            }
        }

        private void aWidth_ValueChanged(object sender, EventArgs e)
        {
            if (chooseObj != null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.width = (int)adornmentWidth.Value;
                chooseObj.Size = new Size(adornment.width, adornment.height);
            }
        }

        private void aHeight_ValueChanged(object sender, EventArgs e)
        {
            if (chooseObj != null && chooseObj.Tag as Adornment != null)
            {
                Adornment adornment = chooseObj.Tag as Adornment;
                adornment.height = (int)adornmentHeight.Value;
                chooseObj.Size = new Size(adornment.width, adornment.height);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element;
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            element = doc.CreateElement("Width");
            element.InnerText = mapWidth.Value.ToString();
            root.AppendChild(element);
            element = doc.CreateElement("FloorHeight");
            element.InnerText = mapFloorHeight.Value.ToString();
            root.AppendChild(element);
            ///////////////////////////////////////////
            XmlElement warriorNode = doc.CreateElement("Warrior");
            root.AppendChild(warriorNode);
            XmlElement adornmentNode = doc.CreateElement("Adornment");
            root.AppendChild(adornmentNode);
            foreach(Control control in map.Controls)
            {
                MyPictureBox pic = control as MyPictureBox;
                if (pic==null)
                {
                    continue;
                }
                if (pic.Tag as Warrior!=null)
                {
                    
                }
                else if (pic.Tag as Adornment!=null)
                {
                    Adornment adornment = pic.Tag as Adornment;
                    XmlElement node = doc.CreateElement(adornment.name);
                    adornmentNode.AppendChild(node);

                    XmlAttribute attr;
                    attr = doc.CreateAttribute("Image");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.image;

                    attr = doc.CreateAttribute("X");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.x.ToString();

                    attr = doc.CreateAttribute("Y");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.y.ToString();

                    attr = doc.CreateAttribute("Width");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.width.ToString();

                    attr = doc.CreateAttribute("Height");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.height.ToString();
                }
            }


            doc.Save("aa.xml");
        }

        private void chooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(resourcePath.Text);
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                adornmentImage.Text = GetRelativePath(Path.GetFullPath(resourcePath.Text), dialog.FileName);
            }
            
        }

        private void resourcePath_TextChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            XmlElement ele = doc.CreateElement("ResourcePath");
            root.AppendChild(ele);
            ele.InnerText = resourcePath.Text;
            doc.Save("setting.xml");
        }

        private void chooseResourcePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            try
            {
                dialog.SelectedPath = Path.GetFullPath(resourcePath.Text);
            }
            catch (Exception)
            {

                dialog.SelectedPath = Application.StartupPath;
            }
            
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                resourcePath.Text = GetRelativePath(Application.StartupPath, dialog.SelectedPath);
            }
            
           
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                openFilePath.Text = dialog.FileName;
                LoadFormFile(openFilePath.Text);
            }
        }
        void LoadFormFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlElement ele = root.GetElementsByTagName("Width").Item(0) as XmlElement;
            mapWidth.Value = int.Parse(ele.InnerText);
            ele = root.GetElementsByTagName("FloorHeight").Item(0) as XmlElement;
            mapFloorHeight.Value = int.Parse(ele.InnerText);
            XmlElement warriorNode = root.GetElementsByTagName("Warrior").Item(0) as XmlElement;
            XmlElement adornmentNode = root.GetElementsByTagName("Adornment").Item(0) as XmlElement;
            foreach (XmlElement item in adornmentNode.ChildNodes)
            {
                MyPictureBox pic = CreateAdorment();
                Adornment adornment = pic.Tag as Adornment;
                adornment.name = item.Name;
                adornment.image = item.GetAttribute("Image");
                adornment.x = int.Parse(item.GetAttribute("X"));
                adornment.y = int.Parse(item.GetAttribute("Y"));
                adornment.width = int.Parse(item.GetAttribute("Width"));
                adornment.height = int.Parse(item.GetAttribute("Height"));
                AdjustPictureBox(pic, adornment);
            }

        }


  
    }
}
