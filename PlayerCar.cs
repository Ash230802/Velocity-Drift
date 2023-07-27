using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VelocityDrift;

namespace VelocityDrift
{
    public class PlayerCar : VelocityDrift.Vehicle
    {
        private int _score;
        private string className = "playerCar";
        private Action<int> _scoreUpdateCallback;

        public PlayerCar(PictureBox pictureBox, string ImagePath, int x, int y, int lane, Action<int> scoreUpdateCallback)
        {
            LoadImage(className, ImagePath, pictureBox, x, y, lane);
            _scoreUpdateCallback = scoreUpdateCallback;
        }
        public override void ActivatePowerUp()
        {
            _score += 10;
            _scoreUpdateCallback(_score); // Update the score through the callback
        }
        /*public int GetScore()
        {
            return _score;
        }*/

    }

}
