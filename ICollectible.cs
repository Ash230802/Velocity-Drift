using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityDrift
{
    public interface ICollectible 
    {
        bool isCollected { get; set; }
        int value { get; }
        void Collect();
    }
}
