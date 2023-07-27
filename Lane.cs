using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityDrift
{
    public class Lane
    {
        private bool _available;
        private bool _started;
        private int _x;

        public Lane()
        {
            _available = true;
            _started = true;
        }

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        public bool available
        {
            get { return _available; }
            set { _available = value; }
        }
        public bool started
        {
            get { return _started; }
            set { _started = value; }
        }
    }
}
