using System;
using System.Drawing;

namespace OrbitingObjectExample
{



    public class Orbiting
    {
        public int height = 750;
        public int width = 750;
        System.Drawing.Graphics g;
        Bitmap btm;

        private float angle;
        private PointF org;
        private float rad;
        private Pen pen;
        private RectangleF area;
        private RectangleF circle;
        PointF loc;

        private float add;
        public bool toggleE;

        public Orbiting()
        {
            this.angle = 0.0f;
            this.org = new PointF(this.height / 2, this.width / 2);
            this.rad = this.height / 2;
            this.pen = new Pen(Color.White, 3.0f);
            this.area = new RectangleF(0, 0, this.height, this.width);
            this.circle = new RectangleF(0, 0, 50, 50);
            this.loc = PointF.Empty;

            this.btm = new Bitmap(height, width);
            this.g = Graphics.FromImage(btm);
            this.add = 1.0f;
            this.toggleE = false;
        }

        public Bitmap generate()
        {
            this.g.Clear(Color.Black);

            this.g.DrawEllipse(pen, area);
            loc = this.circlePoint(rad, angle, org);

            circle.X = loc.X - (circle.Width / 2) + area.X;
            circle.Y = loc.Y - (circle.Width / 2) + area.Y;

            this.g.DrawEllipse(pen, circle);

            if (this.toggleE == true)
            {
                this.direction();
            }

            angle += add;
            if (angle > 360)
            {
                angle -= 360f;
            }

            if (angle < 0)
            {
                angle += 360f;
            }

            return btm;
        }

        private PointF circlePoint(float radious, float angle, PointF orgin)
        {
            float x = (float)(radious * Math.Cos(angle * Math.PI / 180f)) + orgin.X;
            float y = (float)(radious * Math.Sin(angle * Math.PI / 180f)) + orgin.Y;

            return new PointF(x, y);
        }

        public void direction()
        {
            this.add *= -1;
        }
    }




}
