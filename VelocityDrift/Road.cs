using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VelocityDrift
{
    public class Road
    {
        private float _distanceFromStart;
        private float ACCELERATION = 10.0f;
        private List<PictureBox> _roadLines;
        private float _totalDistance = 50.0f;
       // private PlayerCar _playerCar;
        private int _yVelocity;

        public Road(List<PictureBox> roadLines)
        {
            _roadLines = roadLines;
            //_playerCar = new PlayerCar();
        }

        public float YDisplacement
        {
            get
            {
                return DistanceLeft();
            }
        }
        public int VelocityIncrement(int currentSpeed)
        {
            if (_yVelocity < 0)
            {
                _yVelocity = 0;
            } //prevent the player's car from moving backwards.
            _yVelocity += 1;
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
        public float DistanceLeft()
        {
            float elapsedTime = 10 / 1000f; //need to change nnti
            float _distanceFromStart = (float)((_yVelocity * elapsedTime) + (0.5 * ACCELERATION * elapsedTime * elapsedTime)); // s = at + (1/2)at^2
            float distanceLeft = _totalDistance - _distanceFromStart;

            if (Math.Abs(distanceLeft) < 0.0001f) 
            {
                distanceLeft = 0.0f;
            }
            return distanceLeft;
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
