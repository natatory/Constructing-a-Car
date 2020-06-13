using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class FuelTankDisplay : IFuelTankDisplay
    {
        IFuelTank fuelTank;
        public FuelTankDisplay(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }
        public double FillLevel { get { return Math.Round(fuelTank.FillLevel, 2); } }

        public bool IsOnReserve { get { return fuelTank.IsOnReserve; } }

        public bool IsComplete { get { return fuelTank.IsComplete; } }
    }
}
