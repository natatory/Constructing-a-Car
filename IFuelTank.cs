﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }
}
