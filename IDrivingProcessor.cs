using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    interface IDrivingProcessor
    {
        double ActualConsumption { get; } // car #3

        void EngineStart(); // car #3

        void EngineStop(); // car #3

        int ActualSpeed { get; }

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);
    }
}
