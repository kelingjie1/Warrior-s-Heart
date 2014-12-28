using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MapEditor
{
    class MyPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
//         public Image Image;
//         public MyPictureBox()
//         {
// 
//         }
// 
//         protected override CreateParams CreateParams
//         {
//             get
//             {
//                 CreateParams cp = base.CreateParams;
//                 cp.ExStyle|= 0x00000020; //WS_EX_TRANSPARENT
//                 return cp;
//             }
//         }
//         protected override void OnPaint(PaintEventArgs e)
//         {
//             Graphics g = this.CreateGraphics();
//             if (this.Image != null)
//             {
//                 g.DrawImage(this.Image, new Rectangle(0, 0, this.Width, this.Height));
//             }
//             Pen pen = new Pen(Color.Black);
//             g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
// 
//         }
//         protected override void OnPaintBackground(PaintEventArgs pevent)
//         {
//             //do nothing
//         }
// 
//         protected override void OnMove(EventArgs e)
//         {
//             base.OnMove(e);
//             RecreateHandle();
//             
//         }
        
    }
}
