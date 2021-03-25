using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace AFTHY {
	public partial class Form1 : Form {

		private CamManager camManager;
		private FilterInfoCollection deviceList;
		public Form1() {
			InitializeComponent();
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			deviceList = CamManager.GetCameras();
			videoDevices.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (FilterInfo device in deviceList) {
				videoDevices.Items.Add(device.Name);
			}
		}

		private void StartCamera() {
			camManager?.CloseCam();
			camManager = new CamManager(deviceList[videoDevices.SelectedIndex], OnFrame);
			camManager.OpenCam();
		}

		private void OnFrame() {
			Bitmap bmp = camManager.CurrentFrame;
			pictureBox1.Image = bmp;
			//Create a new detector object with a threshold of 2 (view class definition for more info)
			Detector detector = new Detector(1.7);
			//Get the areas on which a face has been detected
			Rectangle[] rectangles = detector.GetFaces(bmp);
			//Draw the rectangle in red in our bitmap image
			foreach (Rectangle rectangle in rectangles) {
				using (Graphics graphics = Graphics.FromImage(bmp)) {
					using (Pen pen = new Pen(Color.Blue, 2)) {
						graphics.DrawRectangle(pen, rectangle);
					}
				}
			}
			//Set the picture box's image to the drawn-on bitmap
			pictureBox1.Image = bmp;
		}


		private void pictureBox1_Click(object sender, EventArgs e) {

		}

		private void videoDevices_SelectedIndexChanged(object sender, EventArgs e) {
			StartCamera();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			this.Dispose();
			Environment.Exit(0);
		}
	}
}
