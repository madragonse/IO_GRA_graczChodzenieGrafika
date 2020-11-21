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

        Thread graphicsThread;
        Graphics fG;
        bool workign = true;

        BMB_Grapgics gg;
        BMB_Input input;



        private void Form1_Load(object sender, EventArgs e)
        {
            input = new BMB_Input();
            gg = new BMB_Grapgics(750, 750, input);

            fG = CreateGraphics();
            graphicsThread = new Thread(BMB);
            graphicsThread.IsBackground = true;
            graphicsThread.Start();

        }

        public void BMB()
        {

            PointF img = new PointF(0, 0);
            int drawId = -1;    


            while (workign)
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
            
            if (Keyboard.IsKeyDown(Key.W))
            {
                input.buttons["W"] = true;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                input.buttons["S"] = true;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                input.buttons["A"] = true;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                input.buttons["D"] = true;
            }


        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (Keyboard.IsKeyUp(Key.W))
            {
                input.buttons["W"] = false;
            }

            if (Keyboard.IsKeyUp(Key.S))
            {
                input.buttons["S"] = false;
            }

            if (Keyboard.IsKeyUp(Key.A))
            {
                input.buttons["A"] = false;
            }

            if (Keyboard.IsKeyUp(Key.D))
            {
                input.buttons["D"] = false;
            }

        }
    }
}
