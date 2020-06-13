using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class Engine : IEngine
    {
        private IFuelTank fuelTank;
        public Engine(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
            IsRunning = false;
        }
        public bool IsRunning { get; private set; }

        public void Consume(double liters)
        {
            if (IsRunning && (fuelTank.FillLevel >= liters)) fuelTank.Consume(liters);
            if (fuelTank.FillLevel == 0) Stop();
        }
        public void Start()
        {
            if (!IsRunning && fuelTank.FillLevel > 0)
                IsRunning = true;
        }
        public void Stop()
        {
            if (IsRunning) IsRunning = false;
        }
    }
}
