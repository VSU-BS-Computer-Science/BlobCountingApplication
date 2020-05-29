using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtificialIntelligence.ThresholdingAlogrithms;

namespace BlobCountingApplication
{
    public partial class Images : Form
    {
        
        public Images(Image img)
        {
            InitializeComponent();
            this.pictureBox1.Image = img;
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Images image = new Images(ProcessImage.copy(this.pictureBox1.Image));
            image.Text = this.Text + " - Copy";
            image.MdiParent = this.MdiParent;
            image.Show();

        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Images image = new Images(ProcessImage.grayscalePercentage(this.pictureBox1.Image));
            image.Text = this.Text + " - Grayscale";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (Convert.ToInt32(toolStripTextBox1.Text) >= 0 || Convert.ToInt32(toolStripTextBox1.Text) <= 255)
                    {
                        Images image = new Images(ProcessImage.Thresholding(this.pictureBox1.Image, Convert.ToInt32(toolStripTextBox1.Text)));
                        image.Text = this.Text + " - Threshold";
                        image.MdiParent = this.MdiParent;
                        image.Show();
                    }
                    else
                    {
                        MessageBox.Show("Input Must Be From 0 - 255 only!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Input!");
                }
            }
        }

        private void invertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Images image = new Images(ProcessImage.Inversion(this.pictureBox1.Image));
            image.Text = this.Text + " - Inversion";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void erode7x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[7, 7] { {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1}};
            Images image = new Images(ProcessImage.MorphologyErosion(this.pictureBox1.Image, kernel));
            image.Text = this.Text + " - Erosion 7x7";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void erode3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { {1, 1, 1},
                                                  {1, 1, 1},
                                                  {1, 1, 1}};
            Images image = new Images(ProcessImage.MorphologyErosion(this.pictureBox1.Image, kernel));

            image.Text = this.Text + " - Erosion 3x3";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void dilate3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { {1, 1, 1},
                                                  {1, 1, 1},
                                                  {1, 1, 1}};
            Images image = new Images(ProcessImage.MorphologyDilation3x3(this.pictureBox1.Image, kernel));
            image.Text = this.Text + " - Dilation 3x3";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void dilate7x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[7, 7] { {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1},
                                                  {1, 1, 1, 1, 1, 1, 1}};
            Images image = new Images(ProcessImage.MorphologyDilation7x7(this.pictureBox1.Image, kernel));
            image.Text = this.Text + " - Dilation 7x7";
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ProcessImage.findBlobCount(this.pictureBox1.Image);
        }

        private void proceedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Images image = new Images(ProcessImage.medianfiltering(this.pictureBox1.Image, toolStripComboBox1.SelectedIndex));
                image.MdiParent = this.MdiParent;
                image.Show();
            }
            catch(StackOverflowException)
            {
                MessageBox.Show("Blob Size Is Too Big!");
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageFormat format = ImageFormat.Png;
            string title = System.IO.Path.GetExtension(sfd.FileName);
            sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif|BITMAP Image|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (title)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                if (MessageBox.Show("Are You Sure You Want To Save This Image?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pictureBox1.Image.Save(sfd.FileName, format);
                    MessageBox.Show("Image Saved!");
                }

            }
        }


        private void scaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Images image = new Images(ProcessImage.Scaling(pictureBox1.Image, 200, 200));           
            image.MdiParent = this.MdiParent;
            image.Show();
        }

        private void horizontalLayeredCountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number of Blobs: " + ProcessImage.HorizaontalLayeredScanning(pictureBox1.Image));
        }

        private void otsoThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Thresh = OtsuThresholding.computeOriginalOtsuThresholding(ProcessImage.HistoGray(pictureBox1.Image));
            Images image = new Images(ProcessImage.Thresholding(this.pictureBox1.Image, Thresh));
            image.Text = this.Text + " - Threshold " + "Value: " + Thresh;
            image.MdiParent = this.MdiParent;
            image.Show();
        }
    }
}
