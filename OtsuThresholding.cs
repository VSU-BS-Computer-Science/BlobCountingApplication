using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArtificialIntelligence.ThresholdingAlogrithms
{
    class OtsuThresholding
    {
        public static int computeOriginalOtsuThresholding(int[] grayscale_histogram)
        {
            if (grayscale_histogram.Length != 256)
                throw new Exception("Parameter Error: grayscale_histogram should be in length 256 which represents counts for each grayvalue in the image.");

            double[] probability_hist = new double[grayscale_histogram.Length];//
            int total = grayscale_histogram.Sum();
            for (int i = 0; i < probability_hist.Length; i++)
                probability_hist[i] = (double)grayscale_histogram[i] / total;

            double sumB = 0, wB = 0;
            double maximum = 0;
            double sum1 = 0;
            int level = 0;

            for (int i = 0; i < grayscale_histogram.Length; i++)
                sum1 += i * probability_hist[i];

            for (int i = 1; i < grayscale_histogram.Length-1; i++)
            {
                wB += probability_hist[i];
                double wF = 1 - wB;
                if (wB == 0 || wF == 0)
                    continue;
                sumB += (i - 1) * probability_hist[i];

                double mB = (sumB / wB);
                double mF = ((sum1 - sumB) / wF);

                double between = wB * wF * Math.Pow((mB - mF), 2);

                if (between >= maximum)
                {
                    level = i;
                    maximum = between;
                }
            }

            return level;
        }
    }
}