using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VelocityDrift
{
    public abstract class InterferenceField
    {
        private float _radius;
        private float _y;
        private float _x;

        public InterferenceField()
        {
        }
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Image Image 
        {
            get;
            set;
        }
        /*public void LoadImage(string imagePath)
        {
            Image = Image.FromFile(imagePath);
        }*/
        public void LoadImage(string className, string imagePath)
        {
            string imageFilename = $"{className}.png";
            string completeImagePath = Path.Combine(imagePath, imageFilename);
            Image = Image.FromFile(completeImagePath);
        }

    }
}
