using System;
using System.Drawing;
using System.Threading;
using OrbitingObjectExample;


namespace IO_GRA_graczChodzenieGrafika
{

    class BMB_Grapgics
    {
        public Graphics g;
        public Graphics gR;
        public Bitmap btm;
        public Bitmap btmR;

        public int drawingId = 0;
        public int toDrawId = 0;
        public bool drawing = true;

        public int height = 750;
        public int width = 750;
        public Thread drawingThread;


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
        }

        /// <summary>
        /// Metoda rysująca wszystkie obiekty na bitmapie [btm]. 
        /// Jest wywoływana tylko jeżeli jest coś nowego do rysowania [toDraw]
        /// </summary>
        private void Draw()
        {

            int toDrawIdThread = 0;




            Orbiting exampleObjectWithSomethingToDraw = new Orbiting();

            RectangleF areaToSytuatePictureOnBitmap;
            areaToSytuatePictureOnBitmap = new RectangleF(0, 0, this.height, this.width);


            while (this.drawing)
            {


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

    }


}
