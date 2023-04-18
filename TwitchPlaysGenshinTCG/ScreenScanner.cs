using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Accord.Imaging;

namespace TwitchPlaysGenshinTCG
{
    internal class ScreenScanner
    {
        private double similarityThreshhold = 0.9;



        public void updateCardAmount()
        {
        }

        public void updateGame() { }

        public bool imagePresent(ScreenElement element)
        {
            // Compare element.image to screen
            return false;
        }

        public void getScreenImage(ScreenElement element) 
        { 
            // Get the screen image based on element.x, etc..
        }

        public double getSimilarity() 
        {
            Bitmap bitmap = Properties.Resources.image1;
            byte[,,] imageData = new byte[bitmap.Height, bitmap.Width, 3];
            for (int i = 0; i < bitmap.Height; i++) 
            {
                for (int j = 0; j < bitmap.Width; j++) {
                    Color pixelColor = bitmap.GetPixel(j, i);
                    imageData[i, j, 0] = pixelColor.B;
                    imageData[i, j, 0] = pixelColor.G;
                    imageData[i, j, 0] = pixelColor.R;
                }
            }
            Image<Bgr, byte> image1 = new Image<Bgr, byte>(imageData);
            Bitmap bitmap2 = Properties.Resources.image2;
            byte[,,] imageData2 = new byte[bitmap2.Height, bitmap2.Width, 3];
            for (int i = 0; i < bitmap2.Height; i++)
            {
                for (int j = 0; j < bitmap2.Width; j++)
                {
                    Color pixelColor = bitmap2.GetPixel(j, i);
                    imageData2[i, j, 0] = pixelColor.B;
                    imageData2[i, j, 0] = pixelColor.G;
                    imageData2[i, j, 0] = pixelColor.R;
                }
            }
            Image<Bgr, byte> image2 = new Image<Bgr, byte>(imageData2);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Image<Gray, float> diff = image2.Convert<Gray, float>().Sub(image1.Convert<Gray, float>());
            double mse = CvInvoke.Mean(diff.Mul(diff)).V0;


            stopwatch.Stop();
            long elapsedTime = stopwatch.ElapsedMilliseconds;
            Debug.WriteLine(elapsedTime);

            

            return mse;
            //return 0;
        }
    }

    internal class ScreenElement
    {
        public static readonly ScreenElement StartingHand = new ScreenElement(30, 20, 100, 100, "StartingHand.png");
        public static readonly ScreenElement SetActiveCharacter = new ScreenElement(30, 20, 100, 100, "SetActiveCharacter.png");
        public static readonly ScreenElement Reroll = new ScreenElement(25, 200, 200, 500, "Reroll.png");
        public static readonly ScreenElement NowActing = new ScreenElement(25, 200, 200, 500, "NowActing.png");
        public static readonly ScreenElement NowWaiting = new ScreenElement(25, 200, 200, 500, "NowWaiting.png");

        public int x { get; }
        public int y { get; }
        public int width { get; }
        public int height { get; }
        public string image { get; }

        public ScreenElement(int x, int y, int width, int height, string image) 
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.image = image;
        }
    }
}
