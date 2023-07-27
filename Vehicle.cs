using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VelocityDrift
{
    public abstract class Vehicle : VelocityDrift.InterferenceField
    {
        private int _xVelocity;

        public Vehicle()
        {
            _xVelocity = 0;
        }
        public int XVelocity
        {
            get { return _xVelocity; }
            set { _xVelocity = value; }
        }
        public abstract void ActivatePowerUp();
    }
}
