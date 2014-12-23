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
        Thumb chooseObj;
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
            if (dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                imageDir.Text = dialog.SelectedPath;
            }
        }

        private void openWarriorDir(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                warriorDir.Text = dialog.SelectedPath;
            }
            SaveSetting();
        }

        private void openMapDir(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapDir.Text = dialog.SelectedPath;
            }
            SaveSetting();
        }

        private void openFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog()==true)
            {
                currentFilePath.Text = dialog.FileName;
            }
            SaveSetting();
        }

        Thumb createObj()
        {
            Thumb obj = new Thumb();
            obj.Width = 100;
            obj.Height = 100;
            Canvas.SetLeft(obj, 0);
            Canvas.SetTop(obj, 0);
            obj.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            obj.DragDelta += obj_DragDelta;
            obj.PreviewMouseLeftButtonDown += obj_MouseDown;
            obj.PreviewMouseLeftButtonUp += obj_MouseUp;
            obj.IsEnabled = true;
            return obj;
        }

        private void obj_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        void obj_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Thumb obj = sender as Thumb;
            chooseObj = obj;
            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment!=null)
            {
                tabControl.SelectedIndex = 2;
            }
            else if (warrior!=null)
            {
                tabControl.SelectedIndex = 1;
            }
        }

        void obj_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb obj = sender as Thumb;
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
            Thumb obj = createObj();
            Adornment adornment = new Adornment();
            obj.Tag = adornment;
            map.Children.Add(obj);
        }

        private void createWarrior(object sender, RoutedEventArgs e)
        {
            Thumb obj = createObj();
            Warrior warrior = new Warrior();
            obj.Tag = warrior;
            map.Children.Add(obj);
        }

        void UpdateData(Thumb obj)
        {
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

        void UpdateUI(Thumb obj)
        {
            Adornment adornment = obj.Tag as Adornment;
            Warrior warrior = obj.Tag as Warrior;
            if (adornment != null)
            {
                obj.Height = adornment.height;
                obj.Width = adornment.width;
                Canvas.SetLeft(obj, adornment.x - adornment.width / 2);
                Canvas.SetTop(obj, EditorY(adornment.y + adornment.height / 2));

                adornmentName.Text = adornment.name;
                adornmentImage.Text = adornment.image;
                adornmentX.Text = adornment.x.ToString();
                adornmentY.Text = adornment.y.ToString();
                adornmentWidth.Text = adornment.width.ToString();
                adornmentHeight.Text = adornment.height.ToString();
            }
            else if (warrior != null)
            {
                Canvas.SetLeft(obj, warrior.x - obj.Width / 2);
                Canvas.SetTop(obj, EditorY(int.Parse(mapFloorHeight.Text) + (int)obj.Height));

                warriorName.Text = warrior.name;
                warriorTemplate.Text = warrior.path;
                warriorGuardingDistance.Text = warrior.guardingDistance.ToString();
                warriorX.Text = warrior.x.ToString();
                warriorPowerPoint.Text = warrior.powerPoint.ToString();
                warriorAgilityPoint.Text = warrior.agilityPoint.ToString();
                warriorStrongPoint.Text = warrior.strongPoint.ToString();
                warriorIntelligencePoint.Text = warrior.intelligencePoint.ToString();
                
                
            }
        }

        private void mapFloorChange(object sender, RoutedEventArgs e)
        {
            if (map == null)
            {
                return;
            }
            foreach (UIElement ele in map.Children)
            {
                Thumb thumb = ele as Thumb;
                if (thumb == null)
                {
                    continue;
                }

                UpdateUI(thumb);
            }
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

        }

        private void openImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                adornmentImage.Text = GetRelativePath(imageDir.Text, dialog.FileName);
                if (chooseObj!=null&&chooseObj.Tag as Adornment!=null)
                {
                    Adornment adornment = chooseObj.Tag as Adornment;
                    adornment.image = adornmentImage.Text;
                    chooseObj.Background = new ImageBrush(new BitmapImage(new Uri(dialog.FileName)));
                }
            }
        }


    }
}
