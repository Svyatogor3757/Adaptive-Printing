using Adaptive_Printing_Base;
using Adaptive_Printing;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace Test {
    [TestClass]
    public class ProceduralUnitTests {
        int TestCount = 10;
        Size imagesize = new Size(1000, 1000);
        Random randseed = Debugger.IsAttached ? new Random(1234) : new Random();

        int SplitHeight = 100;
        int trackReserve = 50;
        int border = 200;

        [TestMethod]
        public void TestFull() {
            Bitmap image;
            List<Rectangle> TrueRectangles = new List<Rectangle>();
            List<Point> TrueTrack = new List<Point>();
            
            for (int i = 0; i < TestCount; i++) {
                trackReserve = randseed.Next(0, 100);
                SplitHeight = randseed.Next(0, 200);
                if (Debugger.IsAttached) {
                    Trace.WriteLine("Test " + i);
                    Trace.WriteLine("TrackReverse " + trackReserve);
                    Trace.WriteLine("SplitHeight " + SplitHeight);
                }
                TrueRectangles.Clear();
                TrueTrack.Clear();
                //Генерация изображения
                image = ImageGenerate(TrueRectangles);
                List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
                if (Debugger.IsAttached) 
                    DrawImage(rectangles);

                for (int j = 0; j < TrueRectangles.Count; j++) {
                    Point start = new Point(TrueRectangles[j].X - trackReserve, TrueRectangles[j].Y);
                    Point end = new Point(TrueRectangles[j].X + TrueRectangles[j].Width + trackReserve, TrueRectangles[j].Y);
                    if (j % 2 == 0) {
                        TrueTrack.Add(start);
                        TrueTrack.Add(end);
                    } else {
                        TrueTrack.Add(end);
                        TrueTrack.Add(start);
                    }
                       
                }

                List<Point> track = TrackBuilder.BuildTrack(TrueRectangles, trackReserve);



                Assert.AreEqual(TrueRectangles.Count, rectangles.Count, "The sizes of the arrays do not match");
                for (int j = 0; j < rectangles.Count; j++) 
                    Assert.AreEqual(TrueRectangles[j], rectangles[j]);

                Assert.AreEqual(TrueTrack.Count, track.Count, "The sizes of the arrays do not match");
                for (int j = 0; j < track.Count; j++)
                    Assert.AreEqual(TrueTrack[j], track[j]);






            }



            //Bitmap imageout = Form1.Draw(image, rectangles, track);
        }

        private void DrawImage(List<Rectangle> rectangles) {
            Bitmap image2 = new Bitmap(imagesize.Width, imagesize.Height);
            using Graphics graphics2 = Graphics.FromImage(image2);
            graphics2.Clear(Color.White);
            foreach (Rectangle rect in rectangles) {
                graphics2.FillRectangle(Brushes.Black, rect);
            }
            ClipBoardImageThread(image2);
        }

        private Bitmap ImageGenerate( List<Rectangle> TrueRectangles) {
            Bitmap image = new Bitmap(imagesize.Width, imagesize.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);


            int numSplits = image.Height / SplitHeight + (image.Height % SplitHeight > 0 ? 1 : 0);
            for (int j = 0; j < numSplits; j++) {
                int y = j * SplitHeight;
                int subImageHeight = Math.Min(SplitHeight, image.Height - y);
                int A = randseed.Next(0, imagesize.Width), B;
                do {
                    B = randseed.Next(0, imagesize.Width);
                } while (B == A);
                //A > B
                if (A < B) {
                    int tmp = B;
                    B = A;
                    A = tmp;
                }

                Rectangle subImageRect = new Rectangle(B, image.Height - y - subImageHeight, A - B, subImageHeight);
                TrueRectangles.Add(subImageRect);

                graphics.FillRectangle(Brushes.Black, subImageRect);
            }
            // Отладка теста, если что-то идет не так
            if (Debugger.IsAttached) 
                ClipBoardImageThread(image);
            
            return image;
        }

        private static void ClipBoardImageThread(Bitmap image2) {
            Thread thread = new Thread(() => {
                Clipboard.SetImage(image2);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        [TestMethod]
        public void TestBaseOffset() {

        }



    }
}