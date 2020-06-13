using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class Car : ICar
    {
        public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

        private IOnBoardComputer onBoardComputer; // car #3

        public IDrivingInformationDisplay drivingInformationDisplay; // car #2  

        private IDrivingProcessor drivingProcessor; // car #2

        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public Car(double fuelLevel, int maxAcceleration) // car #2
        {
            fuelTank = new FuelTank(fuelLevel);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor(maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car()
        {
            fuelTank = new FuelTank(20);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor();
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);

        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor();
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor, fuelTank);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);

        }
        public bool EngineIsRunning { get { return engine.IsRunning; } }

        public void EngineStart()
        {
            engine.Start();
            ((DrivingProcessor)drivingProcessor).IsDrivingTimeSetUp(false);
            ((DrivingProcessor)drivingProcessor).ActualConsumptionSetUp(0);
            ((OnBoardComputer)onBoardComputer).TripRealTimeUp();
            ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByTimeSetUp();

        }

        public void EngineStop()
        {
            if (!EngineIsRunning) return;
            engine.Stop();
            ((DrivingProcessor)drivingProcessor).IsDrivingTimeSetUp(false);
            ((DrivingProcessor)drivingProcessor).ActualConsumptionSetUp(0);
            ((OnBoardComputer)onBoardComputer).TotalRealTimeUp();
            onBoardComputer.TripReset();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if (!EngineIsRunning) return;
            if (fuelTank.FillLevel >= DrivingProcessor._idleConsumption)
            {
                ((DrivingProcessor)drivingProcessor).IsDrivingTimeSetUp(false);
                engine.Consume(DrivingProcessor._idleConsumption);
                ((DrivingProcessor)drivingProcessor).ActualConsumptionSetUp(DrivingProcessor._idleConsumption);
                ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByDistanceSetUp();
                ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByTimeSetUp();
                ((OnBoardComputer)onBoardComputer).TripRealTimeUp();

            }
            else EngineStop();
        }

        public void BrakeBy(int speed)
        {
            if (speed == 0)
            {
                FreeWheel();
                return;
            }
            ((DrivingProcessor)drivingProcessor).IsDrivingTimeSetUp(true);
            drivingProcessor.ReduceSpeed(speed);
            if (drivingProcessor.ActualSpeed == 0)
            {
                RunningIdle();
                return;
            }
            ((DrivingProcessor)drivingProcessor).ActualConsumptionSetUp(0);
            ((OnBoardComputer)onBoardComputer).TripDrivingTimeUp();
            ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByDistanceSetUp();
            ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByTimeSetUp();

        }

        public void Accelerate(int speed)
        {
            if (speed < drivingProcessor.ActualSpeed)
            {
                FreeWheel();
                return;
            }
            double _validCunsumeBySpeed = ((DrivingProcessor)drivingProcessor).GetCunsumeBySpeed(speed);
            if (EngineIsRunning && fuelTank.FillLevel >= _validCunsumeBySpeed)
            {
                ((DrivingProcessor)drivingProcessor).IsDrivingTimeSetUp(true);
                engine.Consume(_validCunsumeBySpeed);
                drivingProcessor.IncreaseSpeedTo(speed);
                ((DrivingProcessor)drivingProcessor).ActualConsumptionSetUp(_validCunsumeBySpeed);
                ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByTimeSetUp();
                ((OnBoardComputer)onBoardComputer).TripAverageConsumptionByDistanceSetUp();
                ((OnBoardComputer)onBoardComputer).TripDrivingTimeUp();
            }
            else EngineStop();
        }

        public void FreeWheel()
        {
            if (drivingProcessor.ActualSpeed >= 1) BrakeBy(1);
            else if (EngineIsRunning) RunningIdle();
        }
    }

}
