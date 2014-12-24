using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;
using System.Xml;

namespace MapEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Image chooseObj;
        Point mousePos;
        public MainWindow()
        {
            InitializeComponent();
            ReadSetting();
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
        int GameY(int y)
        {
            return (int)map.Height - y;
        }
        int EditorY(int y)
        {
            return (int)map.Height - y;
        }

        void SaveSetting()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            XmlElement ele = doc.CreateElement("ImageDir");
            root.AppendChild(ele);
            ele.InnerText = imageDir.Text;
            ele = doc.CreateElement("WarriorDir");
            root.AppendChild(ele);
            ele.InnerText = warriorDir.Text;
            ele = doc.CreateElement("MapDir");
            root.AppendChild(ele);
            ele.InnerText = mapDir.Text;
            doc.Save("setting.xml");
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
            XmlElement ele = (XmlElement)root.GetElementsByTagName("ImageDir").Item(0);
            imageDir.Text = ele.InnerText;
            ele = (XmlElement)root.GetElementsByTagName("WarriorDir").Item(0);
            warriorDir.Text = ele.InnerText;
            ele = (XmlElement)root.GetElementsByTagName("MapDir").Item(0);
            mapDir.Text = ele.InnerText;
        }
        private void openImageDir(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            try
            {
                dialog.SelectedPath = (new Uri(imageDir.Text)).AbsoluteUri;
            }
            catch { }
            if (dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                imageDir.Text = dialog.SelectedPath;
            }
            SaveSetting();
        }

        private void openWarriorDir(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            try
            {
                dialog.SelectedPath = (new Uri(warriorDir.Text)).AbsoluteUri;
            }
            catch { }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                warriorDir.Text = dialog.SelectedPath;
            }
            SaveSetting();
        }

        private void openMapDir(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            try
            {
                dialog.SelectedPath = (new Uri(mapDir.Text)).AbsoluteUri;
            }
            catch { }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapDir.Text = dialog.SelectedPath;
            }
            SaveSetting();
        }

        private void openFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            try
            {
                dialog.InitialDirectory = (new Uri(mapDir.Text)).AbsoluteUri;
            }
            catch { }
            if (dialog.ShowDialog()==true)
            {
                currentFilePath.Text = dialog.FileName;
            }
            LoadFormFile(currentFilePath.Text);


        }
        void LoadFormFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            map.Children.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlElement ele = root.GetElementsByTagName("Width").Item(0) as XmlElement;
            mapWidth.Text = ele.InnerText;
            ele = root.GetElementsByTagName("FloorHeight").Item(0) as XmlElement;
            mapFloorHeight.Text = ele.InnerText;

            XmlElement adornmentNode = root.GetElementsByTagName("Adornment").Item(0) as XmlElement;
            foreach (XmlElement item in adornmentNode.ChildNodes)
            {
                Image obj = createObj();
                Adornment adornment = new Adornment();
                obj.Tag = adornment;
                adornment.name = item.Name;
                adornment.image = item.GetAttribute("Image");
                adornment.x = int.Parse(item.GetAttribute("X"));
                adornment.y = int.Parse(item.GetAttribute("Y"));
                adornment.width = int.Parse(item.GetAttribute("Width"));
                adornment.height = int.Parse(item.GetAttribute("Height"));
                bool.TryParse(item.GetAttribute("Locked"), out adornment.locked);
                UpdateUI(obj);
            }
            XmlElement warriorNode = root.GetElementsByTagName("Warrior").Item(0) as XmlElement;
            foreach (XmlElement item in warriorNode.ChildNodes)
            {
                Image obj = createObj();
                Warrior warrior = new Warrior();
                obj.Tag = warrior;
                warrior.name = item.Name;
                warrior.path = item.GetAttribute("WarriorTemplate");
                if (!warrior.path.Equals(""))
                {
                    warrior.template = new WarriorTemplate(warriorDir.Text + "\\" + warrior.path);
                }
                warrior.x = int.Parse(item.GetAttribute("X"));
                warrior.powerPoint = int.Parse(item.GetAttribute("PowerPoint"));
                warrior.agilityPoint = int.Parse(item.GetAttribute("AgilityPoint"));
                warrior.strongPoint = int.Parse(item.GetAttribute("StrongPoint"));
                warrior.intelligencePoint = int.Parse(item.GetAttribute("IntelligencePoint"));

                warrior.guardingDistance = int.Parse(item.GetAttribute("GuardingDistance"));

                bool.TryParse(item.GetAttribute("Locked"), out warrior.locked);
                UpdateUI(obj);
            }

        }
        Image createObj()
        {
            Image obj = new Image();
            obj.Width = 100;
            obj.Height = 100;
            Canvas.SetLeft(obj, 0);
            Canvas.SetTop(obj, 0);
            obj.MouseMove += obj_MouseMove;
            obj.PreviewMouseLeftButtonDown += obj_MouseDown;
            obj.PreviewMouseLeftButtonUp += obj_MouseUp;
            obj.IsEnabled = true;
            obj.Source = new BitmapImage(new Uri("none.jpg",UriKind.Relative));
            obj.Stretch = Stretch.Fill;
            map.Children.Add(obj);
            return obj;
        }

        private void obj_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton!=MouseButtonState.Pressed)
            {
                return;
            }
            if (chooseObj==null)
            {
                return;
            }
            Image obj = chooseObj as Image;
            ObjBase ob = obj.Tag as ObjBase;
            if (ob.locked)
            {
                return;
            }
            double xPos = e.GetPosition(null).X - mousePos.X + Canvas.GetLeft(obj);
            double yPos = e.GetPosition(null).Y - mousePos.Y + Canvas.GetTop(obj);
                
            mousePos = e.GetPosition(null);


            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment != null)
            {
                obj.SetValue(Canvas.LeftProperty, xPos);
                obj.SetValue(Canvas.TopProperty, yPos);
                adornment.x = (int)(Canvas.GetLeft(obj) + obj.Width / 2);
                adornment.y = GameY((int)(Canvas.GetTop(obj) + obj.Height / 2));
            }
            else if (warrior != null)
            {
                obj.SetValue(Canvas.LeftProperty, xPos);
                Canvas.SetTop(obj, EditorY(int.Parse(mapFloorHeight.Text) + (int)obj.Height));
                warrior.x = (int)(Canvas.GetLeft(obj) + obj.Width / 2);
            }
            UpdateUI(obj);
        }

        private void obj_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        void obj_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePos = e.GetPosition(null);
            Image obj = sender as Image;
            chooseObj = obj;
            UpdateUI(obj);
        }

        void obj_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Image obj = sender as Image;
            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment != null)
            {
                Canvas.SetLeft(obj, Canvas.GetLeft(obj) + e.HorizontalChange);
                Canvas.SetTop(obj, Canvas.GetTop(obj) + e.VerticalChange);
                adornment.x = (int)(Canvas.GetLeft(obj) + obj.Width / 2);
                adornment.y = GameY((int)(Canvas.GetTop(obj) + obj.Height / 2));
            }
            else if (warrior != null)
            {
                Canvas.SetLeft(obj, Canvas.GetLeft(obj) + e.HorizontalChange);
                Canvas.SetTop(obj, EditorY(int.Parse(mapFloorHeight.Text) + (int)obj.Height));
                warrior.x = (int)(Canvas.GetLeft(obj) + obj.Width / 2);
            }
            UpdateUI(obj);
            
        }
        private void createAdornment(object sender, RoutedEventArgs e)
        {
            Image obj = createObj();
            Adornment adornment = new Adornment();
            obj.Tag = adornment;
            UpdateUI(obj);
        }

        private void createWarrior(object sender, RoutedEventArgs e)
        {
            Image obj = createObj();
            Warrior warrior = new Warrior();
            obj.Tag = warrior;
            UpdateUI(obj);
        }

        void UpdateData(Image obj)
        {
            if (obj==null)
            {
                return;
            }
            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment != null)
            {
                adornment.name = adornmentName.Text;
                adornment.x = int.Parse(adornmentX.Text);
                adornment.y = int.Parse(adornmentY.Text);
                adornment.width = int.Parse(adornmentWidth.Text);
                adornment.height = int.Parse(adornmentHeight.Text);
            }
            else if (warrior != null)
            {
                warrior.x = int.Parse(warriorX.Text);
                warrior.guardingDistance = int.Parse(warriorGuardingDistance.Text);
                warrior.powerPoint = int.Parse(warriorPowerPoint.Text);
                warrior.agilityPoint = int.Parse(warriorAgilityPoint.Text);
                warrior.strongPoint = int.Parse(warriorStrongPoint.Text);
                warrior.intelligencePoint = int.Parse(warriorIntelligencePoint.Text);
            }
            UpdateUI(obj);
        }

        void UpdateUI(Image obj)
        {
            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment != null)
            {
                obj.Height = adornment.height;
                obj.Width = adornment.width;
                Canvas.SetLeft(obj, adornment.x - adornment.width / 2);
                Canvas.SetTop(obj, EditorY(adornment.y + adornment.height / 2));


                if (chooseObj==obj)
                {
                    tabControl.SelectedIndex = 2;
                    adornmentName.Text = adornment.name;
                    adornmentImage.Text = adornment.image;
                    adornmentX.Text = adornment.x.ToString();
                    adornmentY.Text = adornment.y.ToString();
                    adornmentWidth.Text = adornment.width.ToString();
                    adornmentHeight.Text = adornment.height.ToString();
                    locked.IsChecked = adornment.locked;
                }
                

                if (adornment.image!=null&&!adornment.image.Equals(""))
                {
                    obj.Source = new BitmapImage(new Uri(imageDir.Text + "\\" + adornment.image));
                }
            }
            else if (warrior != null)
            {
                Canvas.SetLeft(obj, warrior.x - obj.Width / 2);
                Canvas.SetTop(obj, EditorY(int.Parse(mapFloorHeight.Text) + (int)obj.Height));


                if (chooseObj == obj)
                {
                    tabControl.SelectedIndex = 1;
                    warriorName.Text = warrior.name;
                    warriorTemplate.Text = warrior.path;
                    warriorGuardingDistance.Text = warrior.guardingDistance.ToString();
                    warriorX.Text = warrior.x.ToString();
                    warriorPowerPoint.Text = warrior.powerPoint.ToString();
                    warriorAgilityPoint.Text = warrior.agilityPoint.ToString();
                    warriorStrongPoint.Text = warrior.strongPoint.ToString();
                    warriorIntelligencePoint.Text = warrior.intelligencePoint.ToString();
                    locked.IsChecked = warrior.locked;
                }
                
                if (warrior.template!=null)
                {
                    obj.Source = new BitmapImage(new Uri(imageDir.Text + "\\" + warrior.template.image));
                }
                
            }
        }
        void UpdateMapWidth()
        {
            map.Width = int.Parse(mapWidth.Text);
        }
        private void mapWidthKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateMapWidth();
            }
        }

        private void mapWidthChange(object sender, RoutedEventArgs e)
        {
            UpdateMapWidth();
        }
        void UpdateFloorHeight()
        {
            if (map == null)
            {
                return;
            }
            foreach (UIElement ele in map.Children)
            {
                Image Image = ele as Image;
                if (Image == null)
                {
                    continue;
                }

                UpdateUI(Image);
            }
        }
        private void mapFloorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateFloorHeight();
            }
        }
        private void mapFloorChange(object sender, RoutedEventArgs e)
        {
            UpdateFloorHeight();
        }

        private void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (chooseObj!=null)
                {
                    UpdateData(chooseObj);
                }
            }
        }

        private void TextLostFocus(object sender, RoutedEventArgs e)
        {
            if (chooseObj != null)
            {
                UpdateData(chooseObj);
            }
        }

        private void openWarriorTemplate(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = (new Uri(warriorDir.Text)).AbsoluteUri;
            if (dialog.ShowDialog() == true)
            {
                warriorTemplate.Text = GetRelativePath(warriorDir.Text, dialog.FileName);
                if (chooseObj != null && chooseObj.Tag as Warrior != null)
                {
                    Warrior warrior = chooseObj.Tag as Warrior;
                    warrior.path = warriorTemplate.Text;
                    warrior.template = new WarriorTemplate(dialog.FileName);
                    chooseObj.Source = new BitmapImage(new Uri(imageDir.Text + "\\" + warrior.template.image));
                }
            }
        }

        private void openImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = (new Uri(imageDir.Text)).AbsoluteUri;
            if (dialog.ShowDialog() == true)
            {
                adornmentImage.Text = GetRelativePath(imageDir.Text, dialog.FileName);
                if (chooseObj!=null&&chooseObj.Tag as Adornment!=null)
                {
                    Adornment adornment = chooseObj.Tag as Adornment;
                    adornment.image = adornmentImage.Text;
                    chooseObj.Source = new BitmapImage(new Uri(dialog.FileName));
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            if (chooseObj!=null)
            {
                ObjBase ob = chooseObj.Tag as ObjBase;
                ob.locked = (bool)(sender as CheckBox).IsChecked;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateData(chooseObj);
            XmlDocument doc = new XmlDocument();
            XmlElement element;
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            element = doc.CreateElement("Width");
            element.InnerText = mapWidth.Text;
            root.AppendChild(element);
            element = doc.CreateElement("FloorHeight");
            element.InnerText = mapFloorHeight.Text;
            root.AppendChild(element);
            ///////////////////////////////////////////
            XmlElement adornmentNode = doc.CreateElement("Adornment");
            root.AppendChild(adornmentNode);
            foreach (UIElement ele in map.Children)
            {
                Image obj = ele as Image;
                if (obj == null)
                {
                    continue;
                }
                else if (obj.Tag as Adornment != null)
                {
                    Adornment adornment = obj.Tag as Adornment;
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

                    attr = doc.CreateAttribute("Locked");
                    node.Attributes.Append(attr);
                    attr.Value = adornment.locked.ToString();
                }
            }
            XmlElement warriorNode = doc.CreateElement("Warrior");
            root.AppendChild(warriorNode);
            foreach (UIElement ele in map.Children)
            {
                Image obj = ele as Image;
                if (obj == null)
                {
                    continue;
                }
                else if (obj.Tag as Warrior != null)
                {
                    Warrior warrior = obj.Tag as Warrior;
                    XmlElement node = doc.CreateElement(warrior.name);
                    warriorNode.AppendChild(node);

                    XmlAttribute attr;
                    attr = doc.CreateAttribute("WarriorTemplate");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.path;

                    attr = doc.CreateAttribute("X");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.x.ToString();

                    attr = doc.CreateAttribute("GuardingDistance");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.guardingDistance.ToString();

                    attr = doc.CreateAttribute("PowerPoint");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.powerPoint.ToString();

                    attr = doc.CreateAttribute("AgilityPoint");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.agilityPoint.ToString();

                    attr = doc.CreateAttribute("StrongPoint");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.strongPoint.ToString();

                    attr = doc.CreateAttribute("IntelligencePoint");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.intelligencePoint.ToString();

                    attr = doc.CreateAttribute("Locked");
                    node.Attributes.Append(attr);
                    attr.Value = warrior.locked.ToString();

                }
            }
            if (currentFilePath.Text.Equals(""))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = mapDir.Text;
                if (dialog.ShowDialog() != true)
                {
                    return;
                }
                currentFilePath.Text = dialog.FileName;
            }
            doc.Save(currentFilePath.Text);
        }





    }
}
