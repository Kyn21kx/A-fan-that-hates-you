using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;

namespace AFTHY {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Test function that opens a new file dialog to run the facial recognition on
        /// </summary>
		private void Test() {
            //Creating the file dialog and setting up filters
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG|*.jpg";
            dialog.InitialDirectory = @"../../";
            //Show the dialog
            DialogResult r = dialog.ShowDialog();
            if (r.Equals(DialogResult.OK)) {
                //Create the image from the current file
                Image image = Bitmap.FromFile(dialog.FileName);
                //Set the picture box to the image (because recognition might take some time)
                pictureBox1.Image = image;
                //Create a new bitmap from the given image (as we're working with bitmaps for recognition)
                Bitmap bmp = new Bitmap(image);
                //Create a new detector object with a threshold of 2 (view class definition for more info)
                Detector detector = new Detector(2);
                //Get the areas on which a face has been detected
                Rectangle[] rectangles = detector.GetFaces(bmp);
                //Draw the rectangle in red in our bitmap image
                foreach (Rectangle rectangle in rectangles) {
                    using (Graphics graphics = Graphics.FromImage(bmp)) {
                        using (Pen pen = new Pen(Color.Red, 1)) {
                            graphics.DrawRectangle(pen, rectangle);
                        }
                    }
                }
                //Set the picture box's image to the drawn-on bitmap
                pictureBox1.Image = bmp;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void testBtn_Click(object sender, EventArgs e) {
            Test();
        }
    }
}
