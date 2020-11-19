using NUnit.Framework;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

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

        BMB_Grapgics gg;

        private void Form1_Load(object sender, EventArgs e)
        {
            gg = new BMB_Grapgics(750, 750);
            fG = CreateGraphics();
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();

        }

        public void Draw()
        {
            fG.Clear(Color.Black);
            PointF img = new PointF(0, 0);

            

            int drawId = -1;    

            while (drawing)
            {
                

                /*if (Keyboard.IsKeyDown(Key.E))
                    {
                        gg.handleE();
                    }*/

                    


                    if (drawId == gg.drawingId)
                {

                    continue;
                }
                drawId = gg.drawingId;

                gg.nextToDraw();

                //Thread.Sleep(1000);
                fG.DrawImage(gg.btmR, img);
                

            }
            

            


            

        }

        public PointF circlePoint(float radious, float angle, PointF orgin)
        {
            float x = (float)(radious * Math.Cos(angle * Math.PI / 180f)) + orgin.X;
            float y = (float)(radious * Math.Sin(angle * Math.PI / 180f)) + orgin.Y;

            return new PointF(x, y);
        }

        /// <summary>
        /// Jest to jeden z rodzaji wywołań w wątku STA, czyli takim do obsługi UI
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// nie wiem co to jest, chodź się domyślam
        /// 
        /// <param name="e"></param>
        /// nie wiem co to jest, chodź się domyślam
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            //klikając "E" dzieje się magia
            if (Keyboard.IsKeyDown(Key.E))
            {
                gg.pressE = true;
            }


        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (Keyboard.IsKeyUp(Key.E))
            {
                gg.pressE = false;
            }

        }
    }
}
