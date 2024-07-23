using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using Adaptive_Printing_Base;

namespace Adaptive_Printing {
    public partial class Form1 : Form {
        CancellationTokenSource cts = new CancellationTokenSource();

        string ImagePath = "Images";
        int SplitHeight = 600;
        int border = 200;
        int trackReserve = 100;

        double dpi = 360;

        int SelectedUnit = 0;
        double Koeff {
            get {
                switch (SelectedUnit) {
                    default:
                    case 0: return 1;
                    case 1: return dpi / 25.4;
                    case 2: return dpi;
                }

            }
        }
        string[] units = new string[] { "px", "mm", "inc" };

        public Form1() {
            InitializeComponent();
            comboBox1_DropDown(comboBox1, EventArgs.Empty);
            comboBox1.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e) {
            string path = comboBox1.Text;
            if (!File.Exists(path) && File.Exists(Path.Combine(ImagePath, path))) path = Path.Combine(ImagePath, path);
            if (!File.Exists(path) || !IsHandleCreated) return;
            int num;
            if (int.TryParse(textBox2.Text, out num) && num > 0) {
                dpi = num;
            }
            if (int.TryParse(textBox1.Text, out num) && num > 0) {
                SplitHeight = (int)Math.Round(num * Koeff);
            }
            if (int.TryParse(textBox3.Text, out num) && num > 0) {
                trackReserve = num;
                border = num * 2;
            }
            BaseOffset.SplitHeight = SplitHeight;
            BaseOffset.border = border;

            Bitmap image = new Bitmap(path);
            List<Rectangle> rectangles = TrackBuilder.ProcessImage(image, SplitHeight);
            List<Point> track = TrackBuilder.BuildTrack(rectangles, trackReserve);
            Bitmap imageout = DrawImage(image, rectangles, track, textBoxOut);
            pictureBox1.Image = imageout;
        }

        public Bitmap DrawImage(Bitmap image, List<Rectangle> rectangles, List<Point> track, Control? outtext = null) {
            Bitmap imageout = new Bitmap(image.Width + border * 2, image.Height + border * 2);
            Rectangle[] RectDraw = rectangles.ToArray();
            BaseOffset.RectangleToStart(RectDraw);
            Point[] trackDraw = track.ToArray();
            switch (comboBox2.SelectedIndex) {
                default:
                case 0:
                BaseOffset.PointToStart(trackDraw);
                break;
                case 1:
                BaseOffset.PointToCenter(image.Size, trackDraw);
                break;
                case 2:
                BaseOffset.PointToEnd(image.Size, trackDraw);
                break;
            }
            Graphics graphics = Graphics.FromImage(imageout);
            graphics.Clear(Color.White);
            graphics.DrawRectangles(new Pen(Brushes.Red, 4), RectDraw);
            //graphics.DrawLines(new Pen(Brushes.Blue, 4), trackDraw);

            float scale = 100 * pictureBox1.Width / pictureBox1.Height;
            Pen pen = new Pen(Brushes.Blue, 4);
            pen.CustomEndCap = new AdjustableArrowCap(scale / 4, scale / 4);
            if (outtext != null) outtext.Text = $"N.\tX\tY\tNmax={trackDraw.Length}\tBaseOffset=X=Y={border}\r\n";
            for (int i = 0; i < trackDraw.Length - 1; i++) {
                graphics.DrawLine(pen, trackDraw[i], trackDraw[i + 1]);
                graphics.DrawString(i.ToString(), new Font(Font.FontFamily, scale), pen.Brush, trackDraw[i]);
                pictureBox1.Image = imageout;
                if (outtext != null) outtext.Text += string.Join("\t", i + 1, trackDraw[i].X.ToString(), trackDraw[i].Y.ToString()) + "\r\n";
            }
            graphics.DrawString((trackDraw.Length - 1).ToString(), new Font(Font.FontFamily, scale), pen.Brush, trackDraw[trackDraw.Length - 1]);
            if (outtext != null) outtext.Text += string.Join("\t", (trackDraw.Length), trackDraw[(trackDraw.Length - 1)].X.ToString(), trackDraw[(trackDraw.Length - 1)].Y.ToString()) + "\r\n";
            return imageout;
        }

        

        private void comboBox1_DropDown(object sender, EventArgs e) {
            if (!Directory.Exists(ImagePath)) return;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Directory.GetFiles(ImagePath).Select(x => x.Replace(ImagePath, "").Trim('\\')).ToArray());
        }

        private async void comboBox1_TextChanged(object sender, EventArgs e) {
            string path = comboBox1.Text;

            cts.Cancel();
            cts = new CancellationTokenSource();

            Image? resizedImage = await Task.Run(() => {
                cts.Token.ThrowIfCancellationRequested();
                if (!File.Exists(path) && File.Exists(Path.Combine("Images", path))) path = Path.Combine("Images", path);
                if (!File.Exists(path)) return null;
                Bitmap sourceimage = new Bitmap(path);
                double k = (double)pictureBox2.Height / sourceimage.Height;
                return sourceimage.GetThumbnailImage((int)Math.Round(sourceimage.Width * k), pictureBox2.Height, () => false, IntPtr.Zero);
            });
            if (resizedImage != null)
                pictureBox2.Image = resizedImage;

        }

        private void button2_Click(object sender, EventArgs e) {
            if (pictureBox1.Image == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Png files (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e) {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void panel4_SizeChanged(object sender, EventArgs e) {
            comboBox1_TextChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e) {
            SelectedUnit++;
            if (SelectedUnit >= units.Length) SelectedUnit = 0;
            button4.Text = units[SelectedUnit];
        }

    }
}
