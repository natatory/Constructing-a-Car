using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
    {
        IOnBoardComputer _onBoardComputer;

        public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
        {
            _onBoardComputer = onBoardComputer;
        }
        public int TripRealTime { get => _onBoardComputer.TripRealTime; }

        public int TripDrivingTime { get => _onBoardComputer.TripDrivingTime; }

        public double TripDrivenDistance { get => Math.Round(((OnBoardComputer)_onBoardComputer).TripDrivenDistanceDouble, 2); }

        public int TotalRealTime { get => _onBoardComputer.TotalRealTime; }

        public int TotalDrivingTime { get => _onBoardComputer.TotalDrivingTime; }

        public double TotalDrivenDistance { get => Math.Round(((OnBoardComputer)_onBoardComputer).TotalDrivenDistanceDouble, 2); }

        public int ActualSpeed { get => _onBoardComputer.ActualSpeed; }

        public double TripAverageSpeed { get => Math.Round(_onBoardComputer.TripAverageSpeed, 1); }

        public double TotalAverageSpeed { get => Math.Round(_onBoardComputer.TotalAverageSpeed, 1); }

        public double ActualConsumptionByTime { get => Math.Round(_onBoardComputer.ActualConsumptionByTime, 5); }

        public double ActualConsumptionByDistance { get => Math.Round(_onBoardComputer.ActualConsumptionByDistance, 1); }

        public double TripAverageConsumptionByTime
        {
            get => Math.Round(_onBoardComputer.TripAverageConsumptionByTime, 5);
        }

        public double TotalAverageConsumptionByTime
        {
            get => Math.Round(_onBoardComputer.TotalAverageConsumptionByTime, 5);
        }

        public double TripAverageConsumptionByDistance
        {
            get => Math.Round(_onBoardComputer.TripAverageConsumptionByDistance, 1);
        }

        public double TotalAverageConsumptionByDistance
        {
            get => Math.Round(_onBoardComputer.TotalAverageConsumptionByDistance, 1);
        }

        public int EstimatedRange { get => _onBoardComputer.EstimatedRange; }

        public void TotalReset()
        {
            _onBoardComputer.TotalReset();
        }

        public void TripReset()
        {
            _onBoardComputer.TripReset();
        }
    }
}
