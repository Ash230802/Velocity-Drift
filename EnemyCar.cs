using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelocityDrift
{
    public class EnemyCar : VelocityDrift.Vehicle
    {
        private string _imagePath;
        public EnemyCar(PictureBox pictureBox, string ImagePath, int x, int y, int index, int lane)
        {
            _imagePath = ImagePath;
            string enemyCarImageName = "enemyCar" + index.ToString();
            LoadImage(enemyCarImageName, ImagePath, pictureBox, x, y, lane);
        }
        public override void ActivatePowerUp()
        {
                string monsterTruckImageName = "monsterTruck";
                LoadImage(monsterTruckImageName, _imagePath, pictureBox, X, Y, lane);
                UpdatePosition();
        }
    }
}
