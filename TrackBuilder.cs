using System.Drawing.Imaging;

namespace Adaptive_Printing_Base {
    public static class TrackBuilder {
        public static List<Rectangle> ProcessImage(Bitmap image, int splitHeight) {
            List<Rectangle> contentAreas = new List<Rectangle>();
            int width = image.Width;
            int height = image.Height;
            int numSplits = height / splitHeight + (height % splitHeight > 0 ? 1 : 0);

            for (int i = 0; i < numSplits; i++) {
                int y = i * splitHeight;
                int subImageHeight = Math.Min(splitHeight, height - y);
                //Rectangle subImageRect = new Rectangle(0, y, width, subImageHeight); // если конец в конце изображения
                Rectangle subImageRect = new Rectangle(0, height - y - subImageHeight, width, subImageHeight);
                Rectangle contentRect = FindContentArea(image, subImageRect);
                if (contentRect != Rectangle.Empty)
                    contentAreas.Add(contentRect);
            }

            return contentAreas;
        }

        private static Rectangle FindContentArea(Bitmap image, Rectangle subImageRect) {
            int left = subImageRect.Width;
            int right = 0;
            int top = subImageRect.Height;
            int bottom = 0;

            BitmapData subImageData = image.LockBits(subImageRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int stride = subImageData.Stride;
            IntPtr scan0 = subImageData.Scan0;

            unsafe {
                byte* data = (byte*)scan0;
                for (int y = 0; y < subImageRect.Height; y++) {
                    for (int x = 0; x < subImageRect.Width; x++) {
                        byte gray = data[y * stride + x * 4];
                        if (gray != 255) {
                            left = Math.Min(left, x);
                            right = Math.Max(right, x);
                            top = Math.Min(top, y);
                            bottom = Math.Max(bottom, y);
                        }
                    }
                }
            }

            image.UnlockBits(subImageData);
            if (right - left + 1 < 0) return Rectangle.Empty;
            return new Rectangle(subImageRect.X + left, subImageRect.Y, right - left + 1, subImageRect.Height);

        }

        public static List<Point> BuildTrack(List<Rectangle> rectangles, int buffer, bool Reversed = false) {
            List<Point> track = new List<Point>();
            List<Rectangle> rectangles2 = new List<Rectangle>(rectangles);
            if (Reversed) rectangles2.Reverse();
            for (int i = 0; i < rectangles2.Count; i++) {
                Point start = new Point(rectangles2[i].X - buffer, rectangles2[i].Y);
                Point end = new Point(rectangles2[i].X + rectangles2[i].Width + buffer, rectangles2[i].Y);
                if (i % 2 == 0) { // четный шаг
                    track.Add(start);
                    track.Add(end);
                } else {
                    track.Add(end);
                    track.Add(start);
                }
            }
            return track;
        }
    }

    public static class BaseOffset {
        public static int SplitHeight = 600;
        public static int Border = 200;

        public static void PointToStart(Point[] trackDraw, int? border = null) {
            int Border = border != null ? (int)border : BaseOffset.Border;
            for (int i = 0; i < trackDraw.Length; i++) {
                trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border);
            }
        }

        public static void PointToCenter(Size image, Point[] trackDraw, int? border = null) {
            int Border = border != null ? (int)border : BaseOffset.Border;
            for (int i = 0; i < trackDraw.Length; i++) {
                if (i + 1 < trackDraw.Length || trackDraw.Length <= 1) {
                    trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + SplitHeight / 2);
                } else {
                    if (image.Height % SplitHeight > 0) {
                        trackDraw[i - 1] = new Point(trackDraw[i - 1].X, trackDraw[i].Y + Border + (image.Height % SplitHeight) / 2);
                        trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + (image.Height % SplitHeight) / 2);
                    } else trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + SplitHeight / 2);
                }
            }
        }

        public static void PointToEnd(Size image, Point[] trackDraw, int? border = null) {
            int Border = border != null ? (int)border : BaseOffset.Border;
            for (int i = 0; i < trackDraw.Length; i++) {
                if (i + 1 < trackDraw.Length || trackDraw.Length <= 1) {
                    trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + SplitHeight);
                } else {
                    if (image.Height % SplitHeight > 0) {
                        trackDraw[i - 1] = new Point(trackDraw[i - 1].X, trackDraw[i].Y + Border + (image.Height % SplitHeight));
                        trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + (image.Height % SplitHeight));
                    } else trackDraw[i] = new Point(trackDraw[i].X + Border, trackDraw[i].Y + Border + SplitHeight);
                }
            }
        }
        public static void RectangleToStart(Rectangle[] RectDraw, int? border = null) {
            int Border = border != null ? (int)border : BaseOffset.Border;
            for (int i = 0; i < RectDraw.Length; i++)
                RectDraw[i].Location = new Point(RectDraw[i].Location.X + Border, RectDraw[i].Location.Y + Border);
        }
    }
}
