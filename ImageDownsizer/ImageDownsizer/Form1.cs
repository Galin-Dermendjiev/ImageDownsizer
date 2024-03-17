using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection.Metadata.Ecma335;

namespace ImageDownsizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //select image
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFileName = openFileDialog.FileName;
                        pictureBox1.Image = Image.FromFile(selectedFileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }


        }

        //downscale
        private void btnDownscale_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (int.TryParse(tbDownscalingFactor.Text, out int downscaleFactor) && downscaleFactor > 0 && downscaleFactor < 101)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Restart();
                    Image downscaledImage = DownscaleImage(pictureBox1.Image, downscaleFactor);
                    stopwatch.Stop();

                    pictureBox2.Image = downscaledImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                    lblTime.Text = $"Time: {stopwatch.Elapsed.Milliseconds} ms";
                    lblDownscaledDimensions.Text = $"Downscaled Dimensions: {downscaledImage.Width} x {downscaledImage.Height}";
                }
                else
                {
                    MessageBox.Show("Please enter a valid downscale factor (positive integer between 1 and 100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //save image
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                SaveBitmap((Bitmap)pictureBox2.Image);
            }
            else
            {
                MessageBox.Show("No downscaled image available to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBitmap(Bitmap bitmap)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|All Files|*.*";
                saveFileDialog.Title = "Save Image";
                saveFileDialog.FileName = "image"; //Default name
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(saveFileDialog.FileName, GetImageFormatFromExtension(saveFileDialog.FileName));
                }
            }
        }

        private ImageFormat GetImageFormatFromExtension(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath);
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".png":
                default:
                    return ImageFormat.Png;
            }
        }

        private Image DownscaleImage(Image original, int scaleFactor)
        {

            var colorMatrix = ImageDownsizer.Scale.ImageToColorMatrix((Bitmap)original);
            var downsized = ScaleImage.NearestNeighborDownscaleParallelFor(colorMatrix, scaleFactor / 100.0);

            var newImage = ImageDownsizer.Scale.ColorMatrixToImage(downsized);

            return newImage;
        }


       
    }

}

