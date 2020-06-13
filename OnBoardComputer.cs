using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class OnBoardComputer : IOnBoardComputer // car #3
    {
        private const int _distancePerSecondDivider = 3600;
        IDrivingProcessor _drivingProcessor;
        IFuelTank _fuelTank;
        public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
            _drivingProcessor = drivingProcessor;
            ((DrivingProcessor)_drivingProcessor).SpeedChanged += TripAverageSpeedSetUp;
            ((DrivingProcessor)_drivingProcessor).SpeedChanged += TripDrivenDistanceUp;
            TripDrivingTime = 0;
            TripRealTime = 0;
            TripDrivenDistanceDouble = 0;
            TotalDrivenDistanceDouble = 0;
            consumptionsOnLast100Second = new Queue<double>(100);
            Enumerable.Range(0, 99).ToList().ForEach(c => consumptionsOnLast100Second.Enqueue(4.8));
        }

        public int TripRealTime { get; private set; }
        public void TripRealTimeUp()
        {
            TripRealTime++;
            TotalRealTimeUp();
        }

        public int TripDrivingTime { get; private set; }
        public void TripDrivingTimeUp()
        {
            TripDrivingTime++;
            TripRealTimeUp();
            TotalDrivingTimeUp();
        }

        public double TripDrivenDistanceDouble { get; private set; }

        public int TripDrivenDistance { get; }
        public void TripDrivenDistanceUp(object sender, EventArgs e)
        {
            TripDrivenDistanceDouble += (double)ActualSpeed / (double)_distancePerSecondDivider;
            TotalDrivenDistanceDouble += (double)ActualSpeed / (double)_distancePerSecondDivider;
        }

        public double TotalDrivenDistanceDouble { get; private set; }
        public int TotalDrivenDistance { get; }

        public int TotalRealTime { get; private set; }
        public void TotalRealTimeUp()
        {
            TotalRealTime++;
        }

        public int TotalDrivingTime { get; private set; }
        public void TotalDrivingTimeUp()
        {
            TotalDrivingTime++;
        }


        public double TripAverageSpeed
        {
            get => tripSpeedCount != 0
                    ? _tripAverageSpeed / tripSpeedCount
                    : 0;
        }
        private int tripSpeedCount = 0;
        private double _tripAverageSpeed = 0;
        private void TripAverageSpeedSetUp(object sender, EventArgs e)
        {
            if (((DrivingProcessor)_drivingProcessor).IsDrivingTime
                 && ActualSpeed != 0)
            {
                _tripAverageSpeed += ActualSpeed;
                tripSpeedCount++;
                TotalAverageSpeedSetUp();
            }
        }

        private int totalSpeedCount = 0;
        private double _totalAverageSpeed = 0;
        public double TotalAverageSpeed
        {
            get => totalSpeedCount != 0
                ? _totalAverageSpeed / totalSpeedCount
                : 0;
        }
        private void TotalAverageSpeedSetUp()
        {
            _totalAverageSpeed += ActualSpeed;
            totalSpeedCount++;
        }

        public int ActualSpeed { get => _drivingProcessor.ActualSpeed; }

        public double ActualConsumptionByTime { get => ((DrivingProcessor)_drivingProcessor).ActualConsumption; }

        public double ActualConsumptionByDistance
        {
            get => ((DrivingProcessor)_drivingProcessor).IsDrivingTime == false ? Double.NaN
                : ActualSpeed == 0 ? 0
                : ActualConsumptionByTime * _distancePerSecondDivider * 100 / ActualSpeed;
        }

        private int tripConsumeByTimeCount = 0;
        private double _tripAverageConsumptionByTime = 0;
        public double TripAverageConsumptionByTime
        {
            get => tripConsumeByTimeCount != 0
                ? _tripAverageConsumptionByTime / tripConsumeByTimeCount
                : 0;
        }

        public void TripAverageConsumptionByTimeSetUp()
        {
            _tripAverageConsumptionByTime += ActualConsumptionByTime;
            tripConsumeByTimeCount++;
            TotalAverageConsumptionByTimeSetUp();
        }

        public double TotalAverageConsumptionByTime
        {
            get => totalConsumptionByTimeCount != 0
                ? _totalAverageConsumptionByTime / totalConsumptionByTimeCount
                : 0;
        }
        private int totalConsumptionByTimeCount = 0;
        private double _totalAverageConsumptionByTime = 0;
        public void TotalAverageConsumptionByTimeSetUp()
        {
            _totalAverageConsumptionByTime += ActualConsumptionByTime;
            totalConsumptionByTimeCount++;
        }

        public double TripAverageConsumptionByDistance
        {
            get => tripConsumptionByDistanceCount != 0
                ? _tripAverageConsumptionByDistance / tripConsumptionByDistanceCount
                : 0;
        }
        private int tripConsumptionByDistanceCount = 0;
        private double _tripAverageConsumptionByDistance = 0;
        public void TripAverageConsumptionByDistanceSetUp()
        {
            if (ActualConsumptionByDistance != Double.NaN && ActualSpeed != 0)
            {
                _tripAverageConsumptionByDistance += ActualConsumptionByDistance;
                tripConsumptionByDistanceCount++;

                TotalAverageConsumptionByDistanceSetUp();
            }
        }

        public double TotalAverageConsumptionByDistance
        {
            get => totalConsumptionByDistanceCount != 0
                ? _totalAverageConsumptionByDistance / totalConsumptionByDistanceCount
                : 0;
        }
        private int totalConsumptionByDistanceCount = 0;
        private double _totalAverageConsumptionByDistance = 0;
        public void TotalAverageConsumptionByDistanceSetUp()
        {
            _totalAverageConsumptionByDistance += ActualConsumptionByDistance;
            totalConsumptionByDistanceCount++;
            if (consumptionsOnLast100Second.Count < 100)
                consumptionsOnLast100Second.Enqueue(ActualConsumptionByDistance);
            else
            {
                consumptionsOnLast100Second.Dequeue();
                consumptionsOnLast100Second.Enqueue(ActualConsumptionByDistance);
            }
        }
        private Queue<double> consumptionsOnLast100Second;
        public int EstimatedRange
        {

            get => consumptionsOnLast100Second.Any() ?
                (int)Math.Round((_fuelTank.FillLevel * 100
                / consumptionsOnLast100Second.Average()), 0)
                : (int)Math.Round((_fuelTank.FillLevel * 100 / 4.8), 0);
        }

        public void ElapseSecond()
        {
            throw new NotImplementedException();
        }

        public void TotalReset()
        {
            TotalDrivingTime = 0;

            TotalRealTime = 0;

            TotalDrivenDistanceDouble = 0;

            _totalAverageSpeed = 0;
            totalSpeedCount = 0;

            _totalAverageConsumptionByTime = 0;
            totalConsumptionByTimeCount = 0;

            _totalAverageConsumptionByDistance = 0;
            totalConsumptionByDistanceCount = 0;

            consumptionsOnLast100Second.Clear();
        }

        public void TripReset()
        {
            TripDrivingTime = 0;

            TripRealTime = 0;

            TripDrivenDistanceDouble = 0;

            _tripAverageSpeed = 0;
            tripSpeedCount = 0;

            _tripAverageConsumptionByTime = 0;
            tripConsumeByTimeCount = 0;

            _tripAverageConsumptionByDistance = 0;
            tripConsumptionByDistanceCount = 0;

            consumptionsOnLast100Second.Clear();

        }
    }
}
