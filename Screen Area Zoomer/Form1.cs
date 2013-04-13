using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Area_Zoomer
{
    public partial class Form1 : Form
    {
        public int sx=100, sy=100, sw=256, sh=256, dx=-300, dy=200, dw=512, dh=512;
       
        public Graphics g;
        public Graphics bg;
        public Bitmap b;

        public Bitmap _backBuffer;

        public Form1(int sx = 100, int sy = 100, int sw = 256, int sh = 256, int dx = -300, int dy = 200, int dw = 512, int dh = 512)
        {
            this.sx = sx;
            this.sy = sy;
            this.sw = sw;
            this.sh = sh;

            this.dx = dx;
            this.dy = dy;
            this.dw = dw;
            this.dh = dh;
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = dx;
            this.Top = dy;
            this.Width = dw;
            this.Height = dh;

            _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            
            //g = Graphics.FromImage(_backBuffer);
            b = new Bitmap(sw, sh);
            bg = Graphics.FromImage(b);    
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bg.CopyFromScreen(sx, sy, 0, 0, b.Size);
            Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_backBuffer == null)
            {
                _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }
            Graphics g = Graphics.FromImage(_backBuffer);

            //Paint your graphics on g here
            g.DrawImage(b, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            g.Dispose();

            //Copy the back buffer to the screen

            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
            //this.CreateGraphics().DrawImageUnscaled(_backBuffer,0,0);

            //base.OnPaint (e); //optional but not recommended
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Don't allow the background to paint
        }

 
    }
}
