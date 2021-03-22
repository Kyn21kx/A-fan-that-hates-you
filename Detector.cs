using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Emgu.CV;

namespace AFTHY {
	class Detector {

		public CascadeClassifier Classifier { get; private set; }

		private const string TRAINING_FILE = "haarcascade_frontalface_alt_tree.xml";

		public Detector() {
			this.Classifier = new CascadeClassifier(TRAINING_FILE);
        }

		public Rectangle[] GetFaces(Bitmap source) {
			return null;
        }

	}
}
