using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class FuelTank : IFuelTank
    {
        private const int maxFillLevel = 60;
        public FuelTank()
        {
            FillLevel = 20;
            IsOnReserve = false;
            IsComplete = false;
        }
        public FuelTank(double fuelLevel)
        {
            this.Refuel(fuelLevel);
        }
        public double FillLevel { get; private set; }

        public bool IsOnReserve { get; private set; }

        public bool IsComplete { get; private set; }

        public void Consume(double liters)
        {
            if (FillLevel - liters >= 0)
            {
                FillLevel -= liters;
                IsComplete = false;
                IsOnReserve = IsOnReserveChek();
            }
        }

        public void Refuel(double liters)
        {
            if (FillLevel + liters >= maxFillLevel)
            {
                FillLevel = maxFillLevel;
                IsComplete = true;
            }
            else if (FillLevel + liters > 0) FillLevel += liters;
            IsOnReserve = IsOnReserveChek();
        }
        private bool IsOnReserveChek()
        {
            return FillLevel < 5 ? true : false;
        }
    }
}
