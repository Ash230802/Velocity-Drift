using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VelocityDrift
{
    public class Road
    {
        private List<PictureBox> _roadLines;
        private int _yVelocity;

        public Road(List<PictureBox> roadLines)
        {
            _roadLines = roadLines;
        }

        public int VelocityIncrement(int currentSpeed)
        {
            _yVelocity += 1;
            if (_yVelocity < 0)
            {
                _yVelocity = 0;
            }
            int newSpeed = (int)_yVelocity + currentSpeed;
            return newSpeed;
        }
        public int VelocityDecrement(int currentSpeed)
        {
            _yVelocity -= 1;
            int newSpeed = (int)_yVelocity + currentSpeed;

            if (newSpeed < 0)
            {
                newSpeed = 0;
            }
            return newSpeed;
        }
        public float YVelocity
        {
            get
            {
                return _yVelocity;
            }
        }
    }
}
