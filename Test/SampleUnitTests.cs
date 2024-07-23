using Adaptive_Printing_Base;
using System.Drawing;
using System.IO;

namespace Test {
    [TestClass]
    public class SampleUnitTests {

        [TestMethod]
        public void TestBuildTrack() {
            Bitmap image = new Bitmap("Images/Image1.png");
            int SplitHeight = 600;
            int trackReserve = 100;

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

            List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
            List<Point> track = TrackBuilder.BuildTrack(rectangles, trackReserve);

            Rectangle[] RectDraw = rectangles.ToArray();
            Point[] trackDraw = track.ToArray();
            BaseOffset.RectangleToStart(RectDraw);
            BaseOffset.PointToStart(trackDraw);

            for (int i = 0; i < trackDraw.Length; i++) {
                Assert.AreEqual(trackDraw[i], points[i]);
            }
        }

        [TestMethod]
        public void TestFindRectangle() {
            Bitmap image = new Bitmap("Images/Image1.png");
            int SplitHeight = 600;

            List<Rectangle> TrueRectangles = new List<Rectangle>(){
                 new Rectangle(0,3000,5212,600),
                 new Rectangle(625, 2400, 5580, 600),
                 new Rectangle(1759,1200, 4446, 600),
                 new Rectangle(1759, 600, 4446, 600)
            };

            List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
            for (int i = 0; i < rectangles.Count; i++) {
                Assert.AreEqual(rectangles[i], TrueRectangles[i]);
            }

        }
    }
}