using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    interface ICar
    {
        void BrakeBy(int speed); // car #2

        void Accelerate(int speed); // car #2

        void FreeWheel(); // car #2

        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }
}
