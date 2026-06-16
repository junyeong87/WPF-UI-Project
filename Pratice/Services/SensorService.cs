using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Services
{
    public class SensorService
    {
        public int GetTemperature() 
        {
            return Random.Shared.Next(20, 50);
        }

        public int GetPressure() 
        { 
            return Random.Shared.Next(960, 1300);
        }
    }
}
