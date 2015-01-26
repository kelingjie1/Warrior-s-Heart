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
using Microsoft.Win32;
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
            try
            {
                wt.name = name.Text;
                wt.catogory = category.Text;
                wt.resource = resource.Text;
                wt.width = float.Parse(width.Text);
                wt.height = float.Parse(height.Text);
                wt.colliderWidth = float.Parse(colliderWidth.Text);
                wt.colliderHeight = float.Parse(colliderHeight.Text);
                wt.colliderCenterX = float.Parse(colliderCenterX.Text);
                wt.colliderCenterY = float.Parse(colliderCenterY.Text);
                wt.animationDic.Add("attack", new AnimationInfo("attack", float.Parse(attackTime.Text)));
                wt.animationDic.Add("move", new AnimationInfo("move", float.Parse(moveTime.Text)));
                wt.animationDic.Add("knockback", new AnimationInfo("knockback", float.Parse(knockbackTime.Text)));
                wt.animationDic.Add("idle", new AnimationInfo("idle", float.Parse(idleTime.Text)));
                wt.animationDic.Add("spellbegin", new AnimationInfo("spellbegin", float.Parse(spellbeginTime.Text)));
                wt.animationDic.Add("spellend", new AnimationInfo("spellend", float.Parse(spellendTime.Text)));
                wt.animationDic.Add("die", new AnimationInfo("die", float.Parse(dieTime.Text)));
                wt.hitDelay = float.Parse(hitDelay.Text);
                wt.knockbackExpression = knockbackExpression.Text;
                wt.antiKnockbackExpression = antiKnockbackExpression.Text;
                wt.physicalAttackExpression = physicalAttackExpression.Text;
                wt.physicalDefenceExpression = physicalDefenceExpression.Text;
                wt.magicAttackExpression = magicAttackExpression.Text;
                wt.magicDefenceExpression = magicDefenceExpression.Text;
                wt.attackSpeedExpression = attackSpeedExpression.Text;
                wt.maxHPExpression = maxHPExpression.Text;
                wt.maxMoveSpeedExpression = maxMoveSpeedExpression.Text;
                wt.accelerationExpression = accelerationExpression.Text;
                wt.attackDistanceExpression = attackDistanceExpression.Text;
                string[] list = skillList.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in list)
                {
                    wt.skillList.Add(str);
                }


                XmlSerializer xs = new XmlSerializer(typeof(WarriorTemplate));
                FileStream fs = new FileStream(filePath.Text, FileMode.Create);
                xs.Serialize(fs, wt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
            }
           
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (filePath.Text=="")
            {
                dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                dialog.InitialDirectory = filePath.Text;
            }
            
            if(dialog.ShowDialog()!=true)
            {
                return;
            }
            filePath.Text = dialog.FileName;

            XmlSerializer xs = new XmlSerializer(typeof(WarriorTemplate));
            FileStream fs = new FileStream(filePath.Text, FileMode.Open);
            WarriorTemplate wt = xs.Deserialize(fs) as WarriorTemplate;

            name.Text = wt.name;
            category.Text = wt.catogory;
            resource.Text = wt.resource;
            width.Text = wt.width.ToString();
            height.Text = wt.height.ToString();
            colliderWidth.Text = wt.colliderWidth.ToString();
            colliderHeight.Text = wt.colliderHeight.ToString();
            colliderCenterX.Text = wt.colliderCenterX.ToString();
            colliderCenterY.Text = wt.colliderCenterY.ToString();
            attackTime.Text = wt.animationDic["attack"].duration.ToString();
            moveTime.Text = wt.animationDic["move"].duration.ToString();
            knockbackTime.Text = wt.animationDic["knockback"].duration.ToString();
            idleTime.Text = wt.animationDic["idle"].duration.ToString();
            spellbeginTime.Text = wt.animationDic["spellbegin"].duration.ToString();
            spellendTime.Text = wt.animationDic["spellend"].duration.ToString();
            dieTime.Text = wt.animationDic["die"].duration.ToString();
            hitDelay.Text = wt.hitDelay.ToString();
            knockbackExpression.Text = wt.knockbackExpression;
            antiKnockbackExpression.Text = wt.antiKnockbackExpression;
            physicalAttackExpression.Text = wt.physicalAttackExpression;
            physicalDefenceExpression.Text = wt.physicalDefenceExpression;
            magicAttackExpression.Text = wt.magicAttackExpression;
            magicDefenceExpression.Text = wt.magicDefenceExpression;
            attackSpeedExpression.Text = wt.attackSpeedExpression;
            maxHPExpression.Text = wt.maxHPExpression;
            maxMoveSpeedExpression.Text = wt.maxMoveSpeedExpression;
            accelerationExpression.Text = wt.accelerationExpression;
            attackDistanceExpression.Text = wt.attackDistanceExpression;
        }


    }
}
