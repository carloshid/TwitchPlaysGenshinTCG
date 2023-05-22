using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Threading;

namespace TwitchPlaysGenshinTCG
{
    internal class ScreenScanner
    {
        private double similarityThreshhold = 18;

        public int updateCardAmount()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (imagePresentCard(i)) return i;
                Game.setCardAmount(i);
            }
            return -1;

        }

        public void updateGame()
        {
            while (true)
            {
                if (imagePresent(ScreenElement.NowActing))
                {
                    Game.setTurnStatus(TurnStatus.Action);
                }
                else if (imagePresent(ScreenElement.NowWaiting))
                {
                    Game.setTurnStatus(TurnStatus.Waiting);
                }
                else if (imagePresent(ScreenElement.Reroll))
                {
                    Game.setTurnStatus(TurnStatus.ChooseDice);
                }
                else if (imagePresent(ScreenElement.StartingHand))
                {
                    Game.setTurnStatus(TurnStatus.ChooseCards);
                }
                else if (imagePresent(ScreenElement.SetActiveCharacter) || imagePresent(ScreenElement.ChooseACharacter))
                {
                    Game.setTurnStatus(TurnStatus.SelectCharacter);
                }

                else
                {
                    Thread.Sleep(1000);
                    continue;
                }

                break;
            }
        }

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

        private int[] imageX = new int[] { -10, 862, 815, 740, 730, 685, 645, 600, 560, 515, 475 };
        private int[] imageY = new int[] { -10, 1026, 1013, 1015, 1015, 1015, 1015, 1015, 1015, 1015, 1015 };

        public bool imagePresentCard(int n)
        {
            if (n != 0)
            {
                ScreenElement cardElement = new ScreenElement(imageX[n] - 24, imageY[n], 25, 10, Properties.Resources.CardCount);

                Image<Bgr, Byte> screenImage = getScreenImage(cardElement);
                Image<Bgr, Byte> diff = cardElement.image.AbsDiff(screenImage);

                double mse = CvInvoke.Mean(diff.Mul(diff)).V0;
                Debug.WriteLine(mse);

                return (mse < similarityThreshhold);
            }

            return false;
        }

        // Own characters (left to right) : 1-3 , Opponent's characters (left to right) : 4-6
        public bool charAlive(int i) 
        {
            // TODO : check screen
            return false;
        }

        // Own characters (left to right) : 1-3 , Opponent's characters (left to right) : 4-6
        public bool charActive(int i)
        {
            // TODO : check screen
            return false;
        }
    }

    internal class ScreenElement
    {
        public static readonly ScreenElement StartingHand = new ScreenElement(750, 160, 200, 50, Properties.Resources.StartingHand);
        public static readonly ScreenElement SetActiveCharacter = new ScreenElement(1600, 800, 150, 100, Properties.Resources.SetActiveCharacter);
        public static readonly ScreenElement Reroll = new ScreenElement(850, 160, 200, 50, Properties.Resources.Reroll);
        public static readonly ScreenElement NowActing = new ScreenElement(140, 1020, 100, 30, Properties.Resources.NowActing);
        public static readonly ScreenElement NowWaiting = new ScreenElement(140, 1020, 100, 30, Properties.Resources.NowWaiting);
        public static readonly ScreenElement ChooseACharacter = new ScreenElement(140, 1020, 100, 30, Properties.Resources.ChooseACharacter);

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
                    imageData[i, j, 1] = pixelColor.G;
                    imageData[i, j, 2] = pixelColor.R;
                }
            }
            this.image = new Image<Bgr, byte>(imageData);
        }
    }
}
