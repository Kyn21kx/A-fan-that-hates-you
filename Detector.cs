using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AFTHY {
	class Detector {
		/// <summary>
		/// This is the main object that allows us to communicate and find pattern with our training data
		/// </summary>
		public CascadeClassifier Classifier { get; private set; }
		
		/// <summary>
		/// A reference to the file path that contains all our cascade training data
		/// </summary>
		private const string TRAINING_FILE = "haarcascade_frontalface_default.xml";

        /// <summary>
        /// Threshold for face detection
        /// </summary>
        private double scalarFactor;
		/// <summary>
		/// The minimum size of the area to be detected in pixels
		/// </summary>
		private Size minDectecionSize;

		public Detector(double scalarFactor) {
			this.Classifier = new CascadeClassifier(TRAINING_FILE);
			this.scalarFactor = scalarFactor;
			this.minDectecionSize = new Size(70, 70);
        }

		public Detector(double scalarFactor, (int w, int h) detectionSize) {
			this.Classifier = new CascadeClassifier(TRAINING_FILE);
			this.scalarFactor = scalarFactor;
			Size dSize = new Size(detectionSize.w, detectionSize.h);
			this.minDectecionSize = dSize;
		}

		/// <summary>
		/// Converts an image to grayscale, and performs the multi scale detection with our classifier
		/// </summary>
		/// <param name="source">Bitmap to be scanned</param>
		/// <returns>An array of rectangles that represent the area on which a face was detected</returns>
		public Rectangle[] GetFaces(Bitmap source) {
			if (source is null) return null; //Shit went south
			//Process the image as grayscale and generate a new EMGU.CV.Image object
			Image<Gray, byte> grayImg = new Image<Gray, byte>(source);
			//Return the result of the matching
			//The 3 here is the minimum neighbour count, this eliminates 
			//duplicate detections (for more info, check function summary)
			return Classifier.DetectMultiScale(grayImg, scalarFactor, 3, minDectecionSize);
        }

	}
}
