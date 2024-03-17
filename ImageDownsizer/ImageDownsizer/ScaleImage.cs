using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    class ScaleImage
    {
        //change to jagged arr
        public static Color[][] NearestNeighborDownscale(Color[][] originalMatrix, double scaleFactor)
        {
            int originalHeight = originalMatrix.Length;
            int originalWidth = originalMatrix[0].Length;

            int newHeight = (int)(originalHeight * scaleFactor);
            int newWidth = (int)(originalWidth * scaleFactor);

            Color[][] scaledMatrix = new Color[newHeight][];

            for (int y = 0; y < newHeight; y++)
            {
                scaledMatrix[y] = new Color[newWidth];

                for (int x = 0; x < newWidth; x++)
                {
                    int originalX = (int)(x / scaleFactor);
                    int originalY = (int)(y / scaleFactor);

                    scaledMatrix[y][x] = originalMatrix[originalY][originalX];
                }
            }

            return scaledMatrix;
        }

        public static Color[][] NearestNeighborDownscaleParallelFor(Color[][] originalMatrix, double scaleFactor)
        {
            int originalHeight = originalMatrix.Length;
            int originalWidth = originalMatrix[0].Length;

            int newHeight = (int)(originalHeight * scaleFactor);
            int newWidth = (int)(originalWidth * scaleFactor);

            Color[][] scaledMatrix = new Color[newHeight][];

            Parallel.For(0, newHeight, y =>
            {
                scaledMatrix[y] = new Color[newWidth];

                for (int x = 0; x < newWidth; x++)
                {
                    int originalX = (int)(x / scaleFactor);
                    int originalY = (int)(y / scaleFactor);

                    scaledMatrix[y][x] = originalMatrix[originalY][originalX];
                }
            });

            return scaledMatrix;
        }

        public static Color[][] NearestNeighborDownscaleParallelThreads(Color[][] originalMatrix, double scaleFactor)
        {
            int originalHeight = originalMatrix.Length;
            int originalWidth = originalMatrix[0].Length;

            int newHeight = (int)(originalHeight * scaleFactor);
            int newWidth = (int)(originalWidth * scaleFactor);

            Color[][] scaledMatrix = new Color[newHeight][];

            Thread[] threads = new Thread[newHeight];

            for (int y = 0; y < newHeight; y++)
            {
                int rowIndex = y; 

                threads[y] = new Thread(() =>
                {
                    scaledMatrix[rowIndex] = new Color[newWidth];

                    for (int x = 0; x < newWidth; x++)
                    {
                        int originalX = (int)(x / scaleFactor);
                        int originalY = (int)(rowIndex / scaleFactor);

                        scaledMatrix[rowIndex][x] = originalMatrix[originalY][originalX];
                    }
                });

                threads[y].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return scaledMatrix;
        }

    }
}
