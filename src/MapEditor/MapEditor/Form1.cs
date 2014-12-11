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
namespace MapEditor
{
    public partial class Form1 : Form
    {
        bool mouseDown;
        Label chooseLabel;
        Point mouseOffset;
        public Form1()
        {
            InitializeComponent();
            MapSize_ValueChanged(null, null);
            mFloorHeight_ValueChanged(null, null);
        }

        private void MapSize_ValueChanged(object sender, EventArgs e)
        {
            map.Size = new Size((int)mWidth.Value, 640);
            floor.Size = new Size((int)mWidth.Value, 1);
        }
        private void mFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            floor.Location = new Point(0, map.Height - (int)mFloorHeight.Value);
        }

        void map_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }
        void objectLabel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            chooseLabel = sender as Label;
            mouseOffset = new Point(Cursor.Position.X - chooseLabel.Location.X, Cursor.Position.Y - chooseLabel.Location.Y);
            mouseDown = true;
            UpdateUI();
        }
        void objectLabel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Label label=sender as Label;
            if (mouseDown)
            {
                label.Location = new Point(Cursor.Position.X - mouseOffset.X, Cursor.Position.Y - mouseOffset.Y);
            }
            if (label.Tag as Warrior != null)
            {
                Warrior warrior = label.Tag as Warrior;
                
            }
            else if (label.Tag as Adornment != null)
            {
                Adornment adornment = label.Tag as Adornment;
                adornment.x = label.Location.X + map.HorizontalScroll.Value;
                adornment.y = map.Height - label.Location.Y;
            }
            UpdateUI();
        }
        void objectLabel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void addAdornment_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            Adornment adornment = new Adornment();
            label.Tag = adornment;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.MouseDown += objectLabel_MouseDown;
            label.MouseMove += objectLabel_MouseMove;
            label.MouseUp += objectLabel_MouseUp;
            map.Controls.Add(label);
            AdjustLabel(label, adornment);
        }

        private void addWarrior_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            Warrior warrior = new Warrior();
            label.Tag = warrior;
            label.Size = new Size(100, 100);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.MouseDown += objectLabel_MouseDown;
            label.MouseMove += objectLabel_MouseMove;
            label.MouseUp += objectLabel_MouseUp;
            map.Controls.Add(label);
        }

        void AdjustLabel(Label label, Warrior warrior)
        {

        }
        void AdjustLabel(Label label, Adornment adornment)
        {
            label.Location = new Point(adornment.x-map.HorizontalScroll.Value, adornment.y);
            label.Size = new Size(adornment.width, adornment.height);
        }

        void UpdateUI()
        {
            if (chooseLabel==null)
            {
                return;
            }
            if (chooseLabel.Tag as Warrior != null)
            {
                Warrior warrior = chooseLabel.Tag as Warrior;
                tabControl.SelectedIndex = 1;
            }
            else if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                tabControl.SelectedIndex = 2;
                aName.Text = adornment.name;
                aImage.Text = adornment.image;
                aX.Value = adornment.x;
                aY.Value = adornment.y;
                aWidth.Value = adornment.width;
                aHeight.Value = adornment.height;

            }
        }

        private void aName_TextChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment!=null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.name = aName.Text;
            }
        }

        private void aImage_TextChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.image = aImage.Text;
            }
        }

        private void aX_ValueChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.x = (int)aX.Value;
                chooseLabel.Location = new Point(adornment.x - map.HorizontalScroll.Value, map.Height - adornment.y);
            }
        }

        private void aY_ValueChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.y = (int)aY.Value;
                chooseLabel.Location = new Point(adornment.x - map.HorizontalScroll.Value, map.Height - adornment.y);
            }
        }

        private void aWidth_ValueChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.width = (int)aWidth.Value;
                chooseLabel.Size = new Size(adornment.width, adornment.height);
            }
        }

        private void aHeight_ValueChanged(object sender, EventArgs e)
        {
            if (chooseLabel.Tag as Adornment != null)
            {
                Adornment adornment = chooseLabel.Tag as Adornment;
                adornment.height = (int)aHeight.Value;
                chooseLabel.Size = new Size(adornment.width, adornment.height);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element;
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            element = doc.CreateElement("Width");
            element.InnerText = mWidth.Value.ToString();
            root.AppendChild(element);
            element = doc.CreateElement("FloorHeight");
            element.InnerText = mFloorHeight.Value.ToString();
            root.AppendChild(element);
            ///////////////////////////////////////////
            XmlElement warriorNode = doc.CreateElement("Warrior");
            root.AppendChild(warriorNode);
            XmlElement adornmentNode = doc.CreateElement("Adornment");
            root.AppendChild(adornmentNode);
            foreach(Label label in map.Controls)
            {
                if (label.Tag as Warrior!=null)
                {
                    
                }
                else if (label.Tag as Adornment!=null)
                {
                    Adornment adornment = label.Tag as Adornment;
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
                    attr.Value = adornment.x.ToString();

                    attr = doc.CreateAttribute("Height");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.x.ToString();
                }
            }


            doc.Save("aa.xml");
        }


  
    }
}
