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
using System.Xml.Serialization;
using System.IO;
namespace WarriorEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            WarriorTemplate wt = new WarriorTemplate();

            wt.name = name.Text;
            wt.catogory = category.Text;
            wt.width = float.Parse(width.Text);



            XmlSerializer xs = new XmlSerializer(typeof(WarriorTemplate));
            FileStream fs=new FileStream(filePath.Text,FileMode.Create);
            xs.Serialize(fs, wt);
        }
    }
}
