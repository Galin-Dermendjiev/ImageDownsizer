using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    class Scale
    {

        public static Color[][] ImageToColorMatrix(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Color[][] colorMatrix = new Color[height][];

            BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //length of bytes in a row
            int stride = imageData.Stride;

            //pointer to first pixel
            IntPtr scan0 = imageData.Scan0;

            unsafe
            {
                byte* ptr = (byte*)scan0;

                for (int y = 0; y < height; y++)
                {
                    colorMatrix[y] = new Color[width];

                    for (int x = 0; x < width; x++)
                    {
                        //skip n pixels
                        int offset = y * stride + x * 4; 

                        byte blue = ptr[offset];
                        byte green = ptr[offset + 1];
                        byte red = ptr[offset + 2];
                        byte alpha = ptr[offset + 3];

                        Color pixelColor = Color.FromArgb(alpha, red, green, blue);

                        colorMatrix[y][x] = pixelColor;
                    }
                }
            }

            image.UnlockBits(imageData);

            return colorMatrix;
        }


        public static Bitmap ColorMatrixToImage(Color[][] colorMatrix)
        {
            int height = colorMatrix.Length;
            int width = colorMatrix[0].Length;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * height;
            byte[] rgbValues = new byte[bytes];

            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = colorMatrix[y][x];
                    rgbValues[index++] = color.B;
                    rgbValues[index++] = color.G;
                    rgbValues[index++] = color.R;
                    rgbValues[index++] = color.A;
                }
                index += bmpData.Stride - width * 4;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

    }
}
