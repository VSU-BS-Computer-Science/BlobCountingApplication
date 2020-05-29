namespace BlobCountingApplication
{
    partial class Images
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologicalImageOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erode3x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erode7x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilate3x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilate7x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicImageManipulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.proceedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsoThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalLayeredCountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyImageToolStripMenuItem,
            this.morphologicalImageOperationToolStripMenuItem,
            this.basicImageManipulationToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.otsoThresholdingToolStripMenuItem,
            this.countToolStripMenuItem,
            this.horizontalLayeredCountingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(627, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // copyImageToolStripMenuItem
            // 
            this.copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            this.copyImageToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.copyImageToolStripMenuItem.Text = "Copy Image";
            this.copyImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // morphologicalImageOperationToolStripMenuItem
            // 
            this.morphologicalImageOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem});
            this.morphologicalImageOperationToolStripMenuItem.Name = "morphologicalImageOperationToolStripMenuItem";
            this.morphologicalImageOperationToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.morphologicalImageOperationToolStripMenuItem.Text = "Morphological Image Operation";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erode3x3ToolStripMenuItem,
            this.erode7x7ToolStripMenuItem});
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.erosionToolStripMenuItem.Text = "Erosion";
            // 
            // erode3x3ToolStripMenuItem
            // 
            this.erode3x3ToolStripMenuItem.Name = "erode3x3ToolStripMenuItem";
            this.erode3x3ToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.erode3x3ToolStripMenuItem.Text = "Erode 3x3";
            this.erode3x3ToolStripMenuItem.Click += new System.EventHandler(this.erode3x3ToolStripMenuItem_Click);
            // 
            // erode7x7ToolStripMenuItem
            // 
            this.erode7x7ToolStripMenuItem.Name = "erode7x7ToolStripMenuItem";
            this.erode7x7ToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.erode7x7ToolStripMenuItem.Text = "Erode 7x7";
            this.erode7x7ToolStripMenuItem.Click += new System.EventHandler(this.erode7x7ToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dilate3x3ToolStripMenuItem,
            this.dilate7x7ToolStripMenuItem});
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.dilationToolStripMenuItem.Text = "Dilation";
            // 
            // dilate3x3ToolStripMenuItem
            // 
            this.dilate3x3ToolStripMenuItem.Name = "dilate3x3ToolStripMenuItem";
            this.dilate3x3ToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.dilate3x3ToolStripMenuItem.Text = "Dilate 3x3";
            this.dilate3x3ToolStripMenuItem.Click += new System.EventHandler(this.dilate3x3ToolStripMenuItem_Click);
            // 
            // dilate7x7ToolStripMenuItem
            // 
            this.dilate7x7ToolStripMenuItem.Name = "dilate7x7ToolStripMenuItem";
            this.dilate7x7ToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.dilate7x7ToolStripMenuItem.Text = "Dilate 7x7";
            this.dilate7x7ToolStripMenuItem.Click += new System.EventHandler(this.dilate7x7ToolStripMenuItem_Click);
            // 
            // basicImageManipulationToolStripMenuItem
            // 
            this.basicImageManipulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.invertImageToolStripMenuItem,
            this.medianFilteringToolStripMenuItem,
            this.scaleToolStripMenuItem1});
            this.basicImageManipulationToolStripMenuItem.Name = "basicImageManipulationToolStripMenuItem";
            this.basicImageManipulationToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.basicImageManipulationToolStripMenuItem.Text = "Basic Image Manipulation";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertImageToolStripMenuItem
            // 
            this.invertImageToolStripMenuItem.Name = "invertImageToolStripMenuItem";
            this.invertImageToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.invertImageToolStripMenuItem.Text = "Invert Image";
            this.invertImageToolStripMenuItem.Click += new System.EventHandler(this.invertImageToolStripMenuItem_Click);
            // 
            // medianFilteringToolStripMenuItem
            // 
            this.medianFilteringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.proceedToolStripMenuItem});
            this.medianFilteringToolStripMenuItem.Name = "medianFilteringToolStripMenuItem";
            this.medianFilteringToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.medianFilteringToolStripMenuItem.Text = "Median Filtering";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "None",
            "Median 3x3",
            "Median 5x5",
            "Median 7x7"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // proceedToolStripMenuItem
            // 
            this.proceedToolStripMenuItem.Name = "proceedToolStripMenuItem";
            this.proceedToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.proceedToolStripMenuItem.Text = "Proceed";
            this.proceedToolStripMenuItem.Click += new System.EventHandler(this.proceedToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem1
            // 
            this.scaleToolStripMenuItem1.Name = "scaleToolStripMenuItem1";
            this.scaleToolStripMenuItem1.Size = new System.Drawing.Size(192, 26);
            this.scaleToolStripMenuItem1.Text = "Scale";
            this.scaleToolStripMenuItem1.Click += new System.EventHandler(this.scaleToolStripMenuItem1_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem});
            this.imageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // otsoThresholdingToolStripMenuItem
            // 
            this.otsoThresholdingToolStripMenuItem.Name = "otsoThresholdingToolStripMenuItem";
            this.otsoThresholdingToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.otsoThresholdingToolStripMenuItem.Text = "Otso Thresholding";
            this.otsoThresholdingToolStripMenuItem.Click += new System.EventHandler(this.otsoThresholdingToolStripMenuItem_Click);
            // 
            // countToolStripMenuItem
            // 
            this.countToolStripMenuItem.Name = "countToolStripMenuItem";
            this.countToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.countToolStripMenuItem.Text = "Grass Fire Count";
            this.countToolStripMenuItem.Click += new System.EventHandler(this.countToolStripMenuItem_Click);
            // 
            // horizontalLayeredCountingToolStripMenuItem
            // 
            this.horizontalLayeredCountingToolStripMenuItem.Name = "horizontalLayeredCountingToolStripMenuItem";
            this.horizontalLayeredCountingToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.horizontalLayeredCountingToolStripMenuItem.Text = "Horizontal Layered Counting";
            this.horizontalLayeredCountingToolStripMenuItem.Click += new System.EventHandler(this.horizontalLayeredCountingToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ofd";
            // 
            // Images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 546);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Images";
            this.Text = "Images";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morphologicalImageOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicImageManipulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripMenuItem invertImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erode3x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erode7x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilate3x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilate7x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFilteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem proceedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem horizontalLayeredCountingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otsoThresholdingToolStripMenuItem;
    }
}