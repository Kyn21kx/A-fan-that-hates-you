using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Forms;
using System.Drawing;

namespace AFTHY {
	class CamManager {

		public Bitmap CurrentFrame { get; private set; }

		public delegate void AdditionalActions();

		private VideoCaptureDevice device;
		private AdditionalActions onFrameActions;

		public CamManager(FilterInfo deviceInfo, AdditionalActions onFrameActions) {
			this.device = new VideoCaptureDevice(deviceInfo.MonikerString);
			this.onFrameActions = onFrameActions;
			device.NewFrame += CaptureFrame;
		}

		~CamManager() {
			device?.Stop();
		}

		public void OpenCam() {
			device.Start();
		}

		public void CloseCam() {
			device.Stop();
		}

		private void CaptureFrame(object sender, NewFrameEventArgs eventArgs) {
			CurrentFrame = (Bitmap)eventArgs.Frame.Clone();
			CurrentFrame.RotateFlip(RotateFlipType.Rotate180FlipY);
			onFrameActions?.Invoke();
		}

		public static FilterInfoCollection GetCameras() {
			try {
				FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
				if (devices.Count == 0) throw new Exception("No devices found!");
				return devices;
			}
			catch (Exception err) {
				MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	
	}
}
