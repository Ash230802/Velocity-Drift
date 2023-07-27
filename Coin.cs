using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelocityDrift
{
    public class Coin: VelocityDrift.InterferenceField, VelocityDrift.ICollectible
    {
        private bool _isCollected;
        private int _value;
        public Coin(PictureBox pictureBox, string ImagePath, int x, int y, int lane)
        {
            string coinImageName = "coin";
            LoadImage(coinImageName, ImagePath, pictureBox, x, y, lane);

            _value = 1;
            _isCollected = false;
        }
        public bool isCollected
        {
            get { return _isCollected; }
            set { _isCollected = value; }
        }
        public int value
        {
            get { return _value; }
        }
        public void Collect()
        {
            _isCollected = true;
            pictureBox.Visible = false;
        }
    }
}
