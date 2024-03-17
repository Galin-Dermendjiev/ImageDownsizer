namespace ImageDownsizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectImage = new Button();
            pictureBox1 = new PictureBox();
            lbDownscalingFactor = new Label();
            tbDownscalingFactor = new TextBox();
            btnDownscale = new Button();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblDownscaledDimensions = new Label();
            lblTime = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(80, 37);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(120, 33);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "Select Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(29, 103);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(415, 457);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbDownscalingFactor
            // 
            lbDownscalingFactor.AutoSize = true;
            lbDownscalingFactor.Location = new Point(271, 47);
            lbDownscalingFactor.Name = "lbDownscalingFactor";
            lbDownscalingFactor.Size = new Size(151, 15);
            lbDownscalingFactor.TabIndex = 2;
            lbDownscalingFactor.Text = "Choose downscaling factor";
            // 
            // tbDownscalingFactor
            // 
            tbDownscalingFactor.Location = new Point(428, 43);
            tbDownscalingFactor.Name = "tbDownscalingFactor";
            tbDownscalingFactor.Size = new Size(100, 23);
            tbDownscalingFactor.TabIndex = 3;
            // 
            // btnDownscale
            // 
            btnDownscale.Location = new Point(584, 43);
            btnDownscale.Name = "btnDownscale";
            btnDownscale.Size = new Size(75, 23);
            btnDownscale.TabIndex = 4;
            btnDownscale.Text = "Downscale";
            btnDownscale.UseVisualStyleBackColor = true;
            btnDownscale.Click += btnDownscale_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(482, 103);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(413, 457);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 80);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 6;
            label1.Text = "Original Image";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(626, 80);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 7;
            label2.Text = "Downscaled Image";
            // 
            // lblDownscaledDimensions
            // 
            lblDownscaledDimensions.AutoSize = true;
            lblDownscaledDimensions.Location = new Point(698, 48);
            lblDownscaledDimensions.Name = "lblDownscaledDimensions";
            lblDownscaledDimensions.Size = new Size(138, 15);
            lblDownscaledDimensions.TabIndex = 8;
            lblDownscaledDimensions.Text = "Downscaled dimensions:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(677, 573);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(34, 15);
            lblTime.TabIndex = 9;
            lblTime.Text = "time:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(723, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save Image";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 606);
            Controls.Add(btnSave);
            Controls.Add(lblTime);
            Controls.Add(lblDownscaledDimensions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(btnDownscale);
            Controls.Add(tbDownscalingFactor);
            Controls.Add(lbDownscalingFactor);
            Controls.Add(pictureBox1);
            Controls.Add(btnSelectImage);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectImage;
        private PictureBox pictureBox1;
        private Label lbDownscalingFactor;
        private TextBox tbDownscalingFactor;
        private Button btnDownscale;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label lblDownscaledDimensions;
        private Label lblTime;
        private Button btnSave;
    }
}
