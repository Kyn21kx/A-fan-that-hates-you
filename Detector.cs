using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AFTHY {
	class Detector {

		public CascadeClassifier Classifier { get; private set; }

		private const string TRAINING_FILE = "haarcascade_frontalface_alt_tree.xml";

		private int scalarFactor;

		public Detector(int scalarFactor) {
			this.Classifier = new CascadeClassifier(TRAINING_FILE);
			this.scalarFactor = scalarFactor;
        }

		public Rectangle[] GetFaces(Bitmap source) {
			BitmapData data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), 
				ImageLockMode.ReadOnly, source.PixelFormat);
			IntPtr firstPixelAddress = data.Scan0;
			int stride = data.Stride;
			byte[] byteData = new byte[stride * source.Height];
			Marshal.Copy(firstPixelAddress, byteData, 0, byteData.Length);
			Image<Bgra, byte> grayImg = new Image<Bgra, byte>(source.Width, source.Height, stride, firstPixelAddress);
			return Classifier.DetectMultiScale(grayImg, scalarFactor, 0);
        }

	}
}
