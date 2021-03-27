using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Runtime.InteropServices;
using System.Windows;

namespace AFTHY
{
    public partial class Form1 : Form
    {

        private CamManager camManager;
        private Detector detector;
        private FilterInfoCollection deviceList;

        private RobotHandler robotHandler;
        private string[] availableComPorts;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            availableComPorts = RobotHandler.getAllAvailablePorts();
            RobotSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            RobotSelector.Items.AddRange(availableComPorts);


            deviceList = CamManager.GetCameras();
            videoDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            detector = new Detector(1.7);
            foreach (FilterInfo device in deviceList)
            {
                videoDevices.Items.Add(device.Name);
            }
        }

        private void StartCamera()
        {
            camManager?.CloseCam();
            camManager = new CamManager(deviceList[videoDevices.SelectedIndex], OnFrame);
            camManager.OpenCam();
        }

        private void OnFrame()
        {
            Bitmap bmp = camManager.CurrentFrame;
            //pictureBox1.Image = bmp;
            //Create a new detector object with a threshold of 2 (view class definition for more info)
            //Get the areas on which a face has been detected
            Rectangle[] rectangles = detector.GetFaces(bmp);
            //Draw the rectangle in red in our bitmap image
            double speed = 0d;
            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    using (Pen pen = new Pen(Color.Blue, 2))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                        speed = 0.5d - Math.Abs((double)rectangle.X / bmp.Width - .5d);//TODO: Properly calculate the speed needed. My brain doesn't work anymore and I need to go to sleep
                    }
                }
                break;
            }
            robotHandler?.setData((short)(speed * 600));
            //Set the picture box's image to the drawn-on bitmap
            pictureBox1.Image = bmp;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void videoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void RobotSelector_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine($"Selected Com Port: {availableComPorts[RobotSelector.SelectedIndex]}");
            robotHandler?.Dispose();
            robotHandler = new RobotHandler(availableComPorts[RobotSelector.SelectedIndex]);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0219)
            {
                availableComPorts = RobotHandler.getAllAvailablePorts();
                RobotSelector.Items.Clear();
                RobotSelector.Items.AddRange(availableComPorts);
            }

            base.WndProc(ref m);
        }
    }
}
