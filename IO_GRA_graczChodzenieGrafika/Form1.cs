using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IO_GRA_graczChodzenieGrafika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 800;
        }

        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;
        bool drawing = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            fG = CreateGraphics();
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();
        }

        public void Draw()
        {
            fG.Clear(Color.Black);
            PointF img = new PointF(0, 0);

            BMB_Grapgics gg = new BMB_Grapgics(750, 750);

            int drawId = -1;    

            while (drawing)
            {
                

                if (drawId == gg.drawingId)
                {

                    continue;
                }
                drawId = gg.drawingId;

                gg.nextToDraw();

                //Thread.Sleep(1000);
                fG.DrawImage(gg.btmR, img);
                

            }
            

            


            /*float angle = 0.0f;
            PointF org = new PointF(500, 500);
            float rad = 250;
            Pen pen = new Pen(Color.White, 3.0f);
            RectangleF area = new RectangleF(0, 0, 1000, 1000);
            RectangleF circle = new RectangleF(0, 0, 50, 50);

            PointF loc = PointF.Empty;
            PointF img = new PointF(20, 20);

            fG.Clear(Color.Black);

            while (drawing)
            {
                g.Clear(Color.Black);

                g.DrawEllipse(pen, area);
                loc = this.circlePoint(rad, angle, org);

                circle.X = loc.X - (circle.Width / 2) + area.X;
                circle.Y = loc.Y - (circle.Width / 2) + area.Y;

                g.DrawEllipse(pen, circle);





                angle += 1.32f;
                if (angle > 360)
                {
                    angle -= 360f;
                }
                fG.DrawImage(btm, img);

            }*/

        }

        public PointF circlePoint(float radious, float angle, PointF orgin)
        {
            float x = (float)(radious * Math.Cos(angle * Math.PI / 180f)) + orgin.X;
            float y = (float)(radious * Math.Sin(angle * Math.PI / 180f)) + orgin.Y;

            return new PointF(x, y);
        }
    }
}
