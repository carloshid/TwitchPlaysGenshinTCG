using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace TwitchPlaysGenshinTCG
{
    internal class ScreenScanner
    {
        private double similarityThreshhold = 10;

        public void updateCardAmount()
        {
        }

        public void updateGame() { }

        public bool imagePresent(ScreenElement element)
        {
            // Compare element.image to screen
            Image<Bgr, Byte> screenImage = getScreenImage(element);
            Image<Gray, float> diff = element.image.Convert<Gray, float>().Sub(screenImage.Convert<Gray, float>());
            double mse = CvInvoke.Mean(diff.Mul(diff)).V0;

            return (mse < similarityThreshhold);
        }

        public Image<Bgr, byte> getScreenImage(ScreenElement e) 
        {
            // Get the screen image based on element.x, etc..
            Rectangle region = new Rectangle(e.x, e.y, e.width, e.height);
            Bitmap bitmap = new Bitmap(e.width, e.height);
            Graphics.FromImage(bitmap).CopyFromScreen(region.Location, Point.Empty, region.Size);

            return bitmap.ToImage<Bgr, Byte>();
        }

    }

    internal class ScreenElement
    {
        // TODO: Update values here later after adding in the correct images
        public static readonly ScreenElement StartingHand = new ScreenElement(0, 0, 0, 0, Properties.Resources.StartingHand);
        public static readonly ScreenElement SetActiveCharacter = new ScreenElement(0, 0, 0, 0, Properties.Resources.SetActiveCharacter);
        public static readonly ScreenElement Reroll = new ScreenElement(0, 0, 0, 0, Properties.Resources.Reroll);
        public static readonly ScreenElement NowActing = new ScreenElement(0, 0, 0, 0, Properties.Resources.NowActing);
        public static readonly ScreenElement NowWaiting = new ScreenElement(0, 0, 0, 0, Properties.Resources.NowWaiting);

        public int x { get; }
        public int y { get; }
        public int width { get; }
        public int height { get; }
        public Image<Bgr, byte> image { get; }

        public ScreenElement(int x, int y, int width, int height, Bitmap bitmap) 
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            byte[,,] imageData = new byte[bitmap.Height, bitmap.Width, 3];
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(j, i);
                    imageData[i, j, 0] = pixelColor.B;
                    imageData[i, j, 0] = pixelColor.G;
                    imageData[i, j, 0] = pixelColor.R;
                }
            }
            this.image = new Image<Bgr, byte>(imageData);
        }
    }
}
