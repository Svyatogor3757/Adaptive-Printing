using Adaptive_Printing_Base;
using Adaptive_Printing;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Test {
    [TestClass]
    public class ProceduralUnitTests {
        int TestCount = 500;
        int TestRunCount = 500;
        Size imagesize = new Size(1000, 1000);
        Random randseed = Debugger.IsAttached ? new Random(1234) : new Random();

        int SplitHeight = 100;
        int trackReserve = 50;
        int border = 200;

        [TestMethod]
        public void BuildTrack_ExternalImage() {
            SplitHeight = 600;
            trackReserve = 100;
            List<Point> points = new List<Point>(){
                 new Point(100, 3200),
                 new Point(5512, 3200),
                 new Point(6505, 2600),
                 new Point(725, 2600),
                 new Point(1859, 1400),
                 new Point(6505, 1400),
                 new Point(6505, 800),
                 new Point(1859, 800)
            };
            for (int i = 0; i < TestRunCount; i++) {
                Bitmap image = new Bitmap("Images/Image1.png");

                List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
                List<Point> track = TrackBuilder.BuildTrack(rectangles, trackReserve);

                Rectangle[] RectDraw = rectangles.ToArray();
                Point[] trackDraw = track.ToArray();
                BaseOffset.SplitHeight = SplitHeight;
                BaseOffset.Border = 200;
                BaseOffset.RectangleToStart(RectDraw);
                BaseOffset.PointToStart(trackDraw);

                Assert.AreEqual(trackDraw.Length, points.Count);
                for (int j = 0; j < trackDraw.Length; j++) {
                    Assert.AreEqual(trackDraw[j], points[j]);
                }
                image.Dispose();

            }

        }

        [TestMethod]
        public void BuildTrack_InternalImage() {
            List<Rectangle> TrueRectangles = new List<Rectangle>();
            List<Point> TrueTrack = new List<Point>();
            SplitHeight = 100;
            trackReserve = 50;
            for (int i = 0; i < TestRunCount; i++) {
                TrueRectangles.Clear();
                TrueTrack.Clear();
                Bitmap image = ImageGenerate(TrueRectangles);
                List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
                List<Point> track = TrackBuilder.BuildTrack(rectangles, trackReserve);

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
                Assert.AreEqual(TrueRectangles.Count, rectangles.Count, "The sizes of the arrays do not match");
                for (int j = 0; j < rectangles.Count; j++)
                    Assert.AreEqual(TrueRectangles[j], rectangles[j]);

                Assert.AreEqual(TrueTrack.Count, track.Count, "The sizes of the arrays do not match");
                for (int j = 0; j < track.Count; j++)
                    Assert.AreEqual(TrueTrack[j], track[j]);

            }

        }

        [TestMethod]
        public void Full_InternalImage() {
            Bitmap image;
            List<Rectangle> TrueRectangles = new List<Rectangle>();
            List<Point> TrueTrack = new List<Point>();

            for (int i = 0; i < TestCount; i++) {
                trackReserve = randseed.Next(0, 100);
                SplitHeight = randseed.Next(1, 200);
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
                    ClipBoardImageThread(DrawImage(rectangles));

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

        private Bitmap DrawImage(List<Rectangle> rectangles) {
            Bitmap image2 = new Bitmap(imagesize.Width, imagesize.Height);
            using Graphics graphics2 = Graphics.FromImage(image2);
            graphics2.Clear(Color.White);
            foreach (Rectangle rect in rectangles) {
                graphics2.FillRectangle(Brushes.Black, rect);
            }
            return image2;
        }

        private Bitmap ImageGenerate(List<Rectangle> TrueRectangles) {
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





    }
}