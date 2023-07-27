using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelocityDrift
{
    public class InterferenceField
    {
        private bool _clear;
        private int _lane;
        private PictureBox _pictureBox;
        private float _height;
        private float _width;
        private int _x;
        private int _yVelocity; //every objects has a velocity
        private int _y;

        public InterferenceField()
        {
        }
        public bool clear
        {
            get { return _clear; }
            set { _clear = value; }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Image Image
        { 
            get; set; 
        }
        public int YVelocity
        {
            get { return _yVelocity; } set { _yVelocity = value; }
        }
        public void LoadImage(string imageName, string imagePath, PictureBox pictureBox, int x, int y, int lane)
        {
            string completeImagePath = Path.Combine(imagePath, $"{imageName}.png");
            Image = Image.FromFile(completeImagePath);
            pictureBox.Image = Image;
            pictureBox.Name = imageName;
            pictureBox.Size = new Size(Image.Width, Image.Height); //default size
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(x, y);

            _x = x;
            _y = y;
            _lane = lane;
            _pictureBox = pictureBox;
            _height = pictureBox.Height;
            _width = pictureBox.Width;
        }
        public PictureBox pictureBox
        {
            get { return _pictureBox; }
        }
        public void UpdatePosition()
        {
            _y += _yVelocity;
            pictureBox.Location = new Point(_x, _y);
        }
        public int lane
        {
            get { return _lane; }
            set { _lane = value; }
        }
    }
}
