using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobCountingApplication
{
    class ProcessImage
    {
        private static Color[] colors = new Color[15] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet, Color.Pink, Color.Brown, Color.LightBlue, Color.YellowGreen, Color.Turquoise, Color.Maroon, Color.PeachPuff, Color.DarkOrange };
        private static void setPixel(BitmapData bmd, int x, int y, Color c)
        {
            unsafe
            {
                byte* p = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x * 3);
                p[0] = c.B;
                p[1] = c.G;
                p[2] = c.R;
            }
        }
        private static Color getPixel(BitmapData bmd, int x, int y)
        {
            Color c = Color.White;
            unsafe
            {
                byte* p = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x * 3);
                c = Color.FromArgb(p[2], p[1], p[0]);
            }
            return c;
        }

        public static Bitmap copy(Image img)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
                 imageNew = newImg.LockBits(new Rectangle(0, 0, newImg.Width, newImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    Color c = getPixel(old, i, j);
                    setPixel(imageNew, i, j, Color.FromArgb(c.R, c.G, c.B));

                }
            }
            oldImage.UnlockBits(old);
            newImg.UnlockBits(imageNew);
            return newImg;
        }
        public static Bitmap Scaling(Image img, int width, int height)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImage = new Bitmap(width, height);

            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    int oldX;
                    int oldY;
                    oldX = i * oldImage.Width / width;
                    oldY = j * oldImage.Height / height;
                    newImage.SetPixel(i, j, oldImage.GetPixel(oldX, oldY));

                }
            }
            return newImage;

        }
        public static Bitmap grayscalePercentage(Image img)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
                imageNew = newImg.LockBits(new Rectangle(0, 0, newImg.Width, newImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    Color g = getPixel(old, i, j);
                    int gray = (int)(.299 * g.R + .587 * g.G + .114 * g.B);
                    setPixel(imageNew, i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            oldImage.UnlockBits(old);
            newImg.UnlockBits(imageNew);
            return newImg;
        }

        public static Bitmap Inversion(Image img)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
                imageNew = newImg.LockBits(new Rectangle(0, 0, newImg.Width, newImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    Color c = getPixel(old, i, j);
                    int invert = 255;
                    setPixel(imageNew, i, j, Color.FromArgb(invert - c.R, invert - c.G, invert - c.B));

                }
            }
            oldImage.UnlockBits(old);
            newImg.UnlockBits(imageNew);
            return newImg;
        }

        public static Bitmap Thresholding(Image img, int threshold)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
               imageNew = newImg.LockBits(new Rectangle(0, 0, newImg.Width, newImg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    Color c = getPixel(old, i, j);
                    int gray = (int)(.299 * c.R + .587 * c.G + .114 * c.B);
                    if (gray < threshold)
                    {
                        gray = 0;
                        setPixel(imageNew, i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else if (gray > threshold)
                    {
                        gray = 255;
                        setPixel(imageNew, i, j, Color.FromArgb(gray, gray, gray));
                    }
                }
            }
            oldImage.UnlockBits(old);
            newImg.UnlockBits(imageNew);
            return newImg;
        }

        public static Bitmap Convolotion(Image img, double[,] Kernel)
        {
            int Blobcount = 0;
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImage = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
              imageNew = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            if (Kernel.GetLength(0) != Kernel.GetLength(1) || Kernel.GetLength(0) % 2 == 0)
                throw new Exception();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    double[] SOP = new double[3];
                    SOP[0] = 0;
                    SOP[1] = 0;
                    SOP[2] = 0;
                    for (int k = 0; k < Kernel.GetLength(0); k++)
                    {
                        for (int l = 0; l < Kernel.GetLength(1); l++)
                        {
                            int x = i - (Kernel.GetLength(0) / 2) + l;
                            int y = j - (Kernel.GetLength(1) / 2) + k;
                            if (x < 0 || x >= img.Width || y < 0 || y >= img.Height)
                                continue;
                            Color c = getPixel(old, x, y);
                            if (c.ToArgb().Equals(Color.White.ToArgb()))
                            {
                                Blobcount++;

                            }
                        }
                    }
                    setPixel(imageNew, i, j, Color.FromArgb((int)Math.Min(255, Math.Max(0, SOP[0])), (int)Math.Min(255, Math.Max(0, SOP[1])), (int)Math.Min(255, Math.Max(0, SOP[2]))));
                }
            }
            MessageBox.Show("Blob : " + Blobcount);
            oldImage.UnlockBits(old);
            newImage.UnlockBits(imageNew);
            return newImage;
        }

        public static Bitmap MorphologyErosion(Image img, double[,] Kernel)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImage = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
              imageNew = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            if (Kernel.GetLength(0) != Kernel.GetLength(1) || Kernel.GetLength(0) % 2 == 0)
                throw new Exception();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    double[] SOP = new double[3] { 0, 0, 0 };
                    for (int k = 0; k < Kernel.GetLength(0); k++)
                    {
                        for (int l = 0; l < Kernel.GetLength(1); l++)
                        {
                            int x = i - (Kernel.GetLength(0) / 2) + l;
                            int y = j - (Kernel.GetLength(1) / 2) + k;
                            if (x < 0 || x >= img.Width || y < 0 || y >= img.Height)
                                continue;
                            Color c = getPixel(old, x, y);
                            SOP[0] += c.R * Kernel[k, l];
                            SOP[1] += c.G * Kernel[k, l];
                            SOP[2] += c.B * Kernel[k, l];
                        }
                    }
                    Color d = new Color();
                    if (SOP[0] != 0 || SOP[1] != 0 || SOP[2] != 0)
                        d = Color.FromArgb(255, 255, 255);
                    else
                        d = Color.FromArgb(0, 0, 0);
                    setPixel(imageNew, i, j, d);
                }
            }
            oldImage.UnlockBits(old);
            newImage.UnlockBits(imageNew);
            return newImage;
        }

        public static Bitmap MorphologyDilation7x7(Image img, double[,] Kernel)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImage = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
              imageNew = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            if (Kernel.GetLength(0) != Kernel.GetLength(1) || Kernel.GetLength(0) % 2 == 0)
                throw new Exception();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    bool dilate = false;
                    for (int k = 0; k < Kernel.GetLength(0); k++)
                    {
                        for (int l = 0; l < Kernel.GetLength(1); l++)
                        {
                            int x = i - (Kernel.GetLength(0) / 2) + l;
                            int y = j - (Kernel.GetLength(1) / 2) + k;
                            if (x < 0 || x >= img.Width || y < 0 || y >= img.Height)
                                continue;
                            Color c = getPixel(old, x, y);
                            if (c.ToArgb().Equals(Color.Black.ToArgb()))
                            {
                                dilate = true;
                                break;
                            }
                        }
                    }
                    Color d;
                    if (dilate)
                    {
                        d = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        d = Color.FromArgb(255, 255, 255);
                    }
                    setPixel(imageNew, i, j, d);
                }
            }
            oldImage.UnlockBits(old);
            oldImage.Dispose();
            newImage.UnlockBits(imageNew);
            return newImage;
        }

        public static int BlobCountingUsingTemplateMatching(Image img, Image template)
        {
            Bitmap origImage = new Bitmap(img);
            Bitmap tempImage = new Bitmap(template);
            int blob_count = 0;

            //double maxAcc = 0;
            Point maxPoint = Point.Empty;

            bool[,] visited = new bool[img.Width, img.Height];
            BitmapData old = origImage.LockBits(new Rectangle(0, 0, origImage.Width, origImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
            imageNew = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            for (int i = template.Width / 2; i < img.Width - template.Width; i++)
            {
                for (int j = template.Height / 2; j < img.Height - template.Height; j++)
                {
                    double threshold_accuracy = 0.70;
                    //thresold[0.7,1]
                    double countMatchPixels = 0;
                    if (!visited[i, j])
                    {
                        for (int k = 0; k < template.Width; k++)
                        {
                            for (int l = 0; l < template.Height; l++)
                            {
                                int x = i - (template.Width / 2) + k;
                                int y = j - (template.Height / 2) + l;
                                if (getPixel(old, x, y).R == getPixel(imageNew, k, l).R)
                                {
                                    countMatchPixels++;
                                }
                            }
                        }

                        double matchAcc = countMatchPixels / (template.Width * template.Height);
                        if (matchAcc >= threshold_accuracy)
                        {
                            blob_count++;
                            for (int k = 0; k < template.Width; k++)
                            {
                                for (int l = 0; l < template.Height; l++)
                                {
                                    int x = i - (template.Width / 2) + l;
                                    int y = j - (template.Height / 2) + k;
                                    visited[x, y] = true;
                                }
                            }
                        }
                        visited[i, j] = true;
                    }
                }
            }


            origImage.UnlockBits(old);
            tempImage.UnlockBits(imageNew);
            return blob_count;
        }
        public static Bitmap MorphologyDilation3x3(Image img, double[,] Kernel)
        {
            Bitmap oldImage = new Bitmap(img);
            Bitmap newImage = new Bitmap(img.Width, img.Height);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb),
              imageNew = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            if (Kernel.GetLength(0) != Kernel.GetLength(1) || Kernel.GetLength(0) % 2 == 0)
                throw new Exception();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    bool dilate = false;
                    for (int k = 0; k < Kernel.GetLength(0); k++)
                    {
                        for (int l = 0; l < Kernel.GetLength(1); l++)
                        {
                            int x = i - (Kernel.GetLength(0) / 2) + l;
                            int y = j - (Kernel.GetLength(1) / 2) + k;
                            if (x < 0 || x >= img.Width || y < 0 || y >= img.Height)
                                continue;
                            Color c = getPixel(old, x, y);
                            if (c.ToArgb().Equals(Color.Black.ToArgb()))
                            {
                                dilate = true;
                                break;
                            }
                        }
                    }
                    Color d = new Color();
                    if (dilate)
                    {
                        d = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        d = Color.FromArgb(255, 255, 255);
                    }
                    setPixel(imageNew, i, j, d);
                }
            }
            oldImage.UnlockBits(old);
            newImage.UnlockBits(imageNew);
            return newImage;
        }

     
        
        public static Bitmap medianfiltering(Image img, int matrixSize)
        {
            Bitmap sourceBitmap = new Bitmap(img);
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);
            float rgb = 0;

            for (int k = 0; k < pixelBuffer.Length; k += 4)
            {
                rgb = pixelBuffer[k] * 0.11f;
                rgb += pixelBuffer[k + 1] * 0.59f;
                rgb += pixelBuffer[k + 2] * 0.3f;


                pixelBuffer[k] = (byte)rgb;
                pixelBuffer[k + 1] = pixelBuffer[k];
                pixelBuffer[k + 2] = pixelBuffer[k];
                pixelBuffer[k + 3] = 255;
            }


            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(
                                       neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public static Bitmap findBlobCount(Image img)
        {

            Bitmap matrix = new Bitmap(img);
            int rowCount = matrix.Width;
            int colCount = matrix.Height;
            Graphics g = Graphics.FromImage(matrix);
            bool[,] visited = new bool[rowCount, colCount]; // all initialized to false

            int count = 0;
            Font f = new Font("Arial", 5, FontStyle.Regular);
           
            {
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        if (matrix.GetPixel(i, j).ToArgb().Equals(Color.Black.ToArgb()) && !visited[i, j]) // unvisited black cell
                        //if (getPixel(matrix, i, j).ToArgb().Equals(Color.Black.ToArgb()) && !visited[i, j]) // unvisited black cell
                        {
                            markVisited(i, j, ref matrix, ref visited, rowCount, colCount, colors[count % colors.Length]);
                            count++;
                            g.DrawString(count.ToString(), f, Brushes.OrangeRed, new Point(i - 1, j - 1));

                        }

                    }
                }
            }

            g.DrawString("Blobs:" + count.ToString(), f, Brushes.OrangeRed, new Point(0, 0));
            MessageBox.Show(" BLOB COUNT : " + count);
            //matrix.UnlockBits(sourceData);
            //matrix = new Bitmap(img);
            return matrix;
        }

        static int markVisited(int i, int j, ref Bitmap matrix, ref bool[,] visited, int rowCount, int colCount, Color c)
        {
            if (i < 0 || j < 0 || i >= rowCount || j >= colCount) //not included coord in image
                return 0;

            if (visited[i, j]) // already visited
                return 1;

            if (matrix.GetPixel(i, j).ToArgb().Equals(Color.White.ToArgb())) // not a white cell
            {
                return 0;
            }
            visited[i, j] = true;
            matrix.SetPixel(i, j, c);

            // recursively mark all the 4 adjacent cells - right, left, up and down
            return markVisited(i + 1, j, ref matrix, ref visited, rowCount, colCount, c)
                 + markVisited(i - 1, j, ref matrix, ref visited, rowCount, colCount, c)
                 + markVisited(i, j + 1, ref matrix, ref visited, rowCount, colCount, c)
                 + markVisited(i, j - 1, ref matrix, ref visited, rowCount, colCount, c);
        }


        public static int HorizaontalLayeredScanning(Image img)
        {
            Bitmap oldImage = new Bitmap(img);
            int counter1 =0, counter2 = 0;
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int j = 0; j < img.Height; j++)
            {
                int ctrChange = 0, nextctr1 = 0;
                for (int i = 0; i < img.Width - 1; i++)
                {
                    Color c = getPixel(old,i,j);
                    Color d = getPixel(old, i + 1, j);
                    if (c.R != d.R)
                    {
                        ctrChange++;
                    }
                    if (ctrChange != 0 && ctrChange % 2 == 0)
                    {
                        nextctr1++;
                        ctrChange = 0;
                    }
                 }
                if (nextctr1 < counter1)
                {
                    counter2 += counter1 - nextctr1;
                }
                counter1 = nextctr1;
            }
            oldImage.UnlockBits(old);
            return counter2;
                    
           }
        public static int[] HistoGray(Image img)
        {
            int[] HistoGray = new int[256];
            Bitmap oldImage = new Bitmap(img);
            BitmapData old = oldImage.LockBits(new Rectangle(0, 0, oldImage.Width, oldImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    Color g = getPixel(old, i, j);
                    HistoGray[g.B]++;
                }
            }
            oldImage.UnlockBits(old);
            return HistoGray;
        }
            
        
    }
    
}
