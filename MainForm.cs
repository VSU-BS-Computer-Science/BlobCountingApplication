using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtificialIntelligence.ThresholdingAlogrithms;

namespace BlobCountingApplication
{
    public partial class MainForm : Form
    {
        Image orig, temp;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image File(*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Images image = new Images(Image.FromFile(ofd.FileName));
                image.Text = ofd.SafeFileName;
                image.MdiParent = this;
                image.Show();
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image File(*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                orig = Image.FromFile(ofd.FileName);
            }
        }

        private void selectTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image File(*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                temp = Image.FromFile(ofd.FileName);
            }
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int Thresh = OtsuThresholding.computeOriginalOtsuThresholding(ProcessImage.HistoGray(ProcessImage.grayscalePercentage(orig)));
                int Hold = OtsuThresholding.computeOriginalOtsuThresholding(ProcessImage.HistoGray(ProcessImage.grayscalePercentage(temp)));
                MessageBox.Show("Number of Blobs: " + ProcessImage.BlobCountingUsingTemplateMatching(orig, temp));
            }
            catch
            {
                MessageBox.Show("Input is lacking");
            }

        }
    }
}
