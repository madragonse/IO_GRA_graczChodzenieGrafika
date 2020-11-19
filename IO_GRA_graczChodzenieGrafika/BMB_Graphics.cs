using System;
using System.Drawing;
using System.Threading;
using OrbitingObjectExample;


namespace IO_GRA_graczChodzenieGrafika
{

    class BMB_Grapgics
    {
        private Graphics g;
        private Graphics gR;
        private Bitmap btm;
        public Bitmap btmR;

        public int drawingId = 0;
        private int toDrawId = 0;
        public bool drawing = true;

        private int height = 750;
        private int width = 750;
        private Thread drawingThread;

        private Orbiting exampleObjectWithSomethingToDraw;
        public bool pressE = false;


        public BMB_Grapgics(int height, int width)
        {
            this.height = height;
            this.width = width;

            this.btm = new Bitmap(height, width);
            this.btmR = new Bitmap(height, width);
            this.g = Graphics.FromImage(btm);
            this.gR = Graphics.FromImage(btmR);

            drawingThread = new Thread(Draw);
            drawingThread.IsBackground = true;
            drawingThread.Start();

            exampleObjectWithSomethingToDraw = new Orbiting();
        }

        /// <summary>
        /// Metoda rysująca wszystkie obiekty na bitmapie [btm]. 
        /// Jest wywoływana tylko jeżeli jest coś nowego do rysowania [toDrawIdThread, toDrawId] 
        /// (zapobiega obciążaniu procesora niepotrzebnie)(patrz zastosowanie w Form1.cs)
        /// 
        /// Tutaj łączą się bitmapy z różnych obiektów odpowiadających za różne rzeczy w grze.
        /// Pracuje na oddzeilnym wątku.
        /// </summary>
        private void Draw()
        {

            int toDrawIdThread = 0;




            

            RectangleF areaToSytuatePictureOnBitmap;
            areaToSytuatePictureOnBitmap = new RectangleF(0, 0, this.height, this.width);


            while (this.drawing)
            {

                if (this.pressE == true)
                {
                    this.handleE();
                }

                if (toDrawIdThread == this.toDrawId)
                {
                    Thread.Sleep(1);
                    continue;
                }
                toDrawIdThread = this.toDrawId;


                this.g.DrawImage(exampleObjectWithSomethingToDraw.generate(), areaToSytuatePictureOnBitmap);

                this.gR.DrawImage(this.btm, areaToSytuatePictureOnBitmap);
                this.nextDrawing();

                
                    


            }


        }


        public void nextDrawing()
        {
            this.drawingId++;
            if (this.drawingId > 2000000000)
            {
                this.drawingId = 0;
            }
        }

        public void nextToDraw()
        {
            this.toDrawId++;
            if (this.toDrawId > 2000000000)
            {
                this.toDrawId = 0;
            }
        }

        /// <summary>
        /// przewiduję dodatkową klasę do obsługi inputu
        /// </summary>
        public void handleE()
        {
            this.exampleObjectWithSomethingToDraw.direction();
        }


        

    }


}
