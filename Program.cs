using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TestRealAndDrivingTimeBeforeStarting()
            var car = new Car();
            Console.WriteLine(car.onBoardComputerDisplay.TripRealTime);
            Console.WriteLine(car.onBoardComputerDisplay.TripDrivingTime);
            Console.WriteLine();
            #endregion

            #region TestRealAndDrivingTimeAfterDriving()
            car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(30);

            Console.WriteLine(car.onBoardComputerDisplay.TripRealTime);
            Console.WriteLine(car.onBoardComputerDisplay.TripDrivingTime);
            Console.WriteLine(car.onBoardComputerDisplay.TotalRealTime);
            Console.WriteLine(car.onBoardComputerDisplay.TotalDrivingTime);
            Console.WriteLine();
            #endregion

            #region TestActualSpeedBeforeDriving
            car = new Car();
            car.EngineStart();
            car.RunningIdle();
            car.RunningIdle();
            Console.WriteLine(car.onBoardComputerDisplay.ActualSpeed);
            Console.WriteLine();
            #endregion

            #region TestAverageSpeed1
            car = new Car();
            car.EngineStart();
            car.RunningIdle();
            car.RunningIdle();
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageSpeed);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageSpeed);
            Console.WriteLine();
            #endregion

            #region TestAverageSpeedAfterTripReset
            car = new Car();
            car.EngineStart();
            car.RunningIdle();
            car.RunningIdle();
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);
            car.onBoardComputerDisplay.TripReset();
            car.Accelerate(20);
            car.Accelerate(20);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageSpeed);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageSpeed);
            Console.WriteLine();
            #endregion

            #region TestActualConsumptionEngineStart
            car = new Car();
            car.EngineStart();
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestActualConsumptionRunningIdle
            car = new Car();
            car.EngineStart();
            car.RunningIdle();
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestActualConsumptionAccelerateTo100
            car = new Car(40, 20);
            car.EngineStart();
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestActualConsumptionFreeWheel
            car = new Car(40, 20);
            car.EngineStart();
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.FreeWheel();
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.ActualConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestAverageConsumptionsAfterEngineStart
            car = new Car();
            car.EngineStart();
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByDistance);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestAverageConsumptionsAfterAccelerating
            car = new Car();
            car.EngineStart();
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByDistance);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestAverageConsumptionsAfterBraking
            car = new Car();
            car.EngineStart();
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByTime);
            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByDistance);
            Console.WriteLine(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance);
            Console.WriteLine();
            #endregion

            #region TestDrivenDistancesAfterEngineStart
            car = new Car();
            car.EngineStart();
            Console.WriteLine(car.onBoardComputerDisplay.TripDrivenDistance);
            Console.WriteLine(car.onBoardComputerDisplay.TotalDrivenDistance);
            Console.WriteLine();
            #endregion

            #region TestDrivenDistancesAfterAccelerating
            car = new Car();
            car.EngineStart();
            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));
            Console.WriteLine(car.onBoardComputerDisplay.TripDrivenDistance);
            Console.WriteLine(car.onBoardComputerDisplay.TotalDrivenDistance);
            Console.WriteLine();
            #endregion

            #region TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds
            car = new Car();
            car.EngineStart();
            Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));
            Console.WriteLine(car.fuelTankDisplay.FillLevel);
            Console.WriteLine(car.onBoardComputerDisplay.EstimatedRange);
            Console.WriteLine();
            #endregion
       
            Console.ReadLine();
        }
    }
}
