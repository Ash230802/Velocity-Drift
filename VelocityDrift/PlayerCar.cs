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
        private string className = "playerCar";
        public PlayerCar(string ImagePath, int x, int y) 
        {
            LoadImage(className, ImagePath);
            this.Y = y;
            this.X = x;
        }

    }

}
