using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class DrivingProcessor : IDrivingProcessor // car #2
    {
        public static double _1_60_KmhConsumption = 0.0020;
        public static double _61_100_KmhConsumption = 0.0014;
        public static double _101_140_KmhConsumption = 0.0020;
        public static double _141_200_KmhConsumption = 0.0025;
        public static double _201_250_KmhConsumption = 0.0030;
        public static double _idleConsumption = 0.0003;

        public event EventHandler SpeedChanged;
        public bool IsDrivingTime { get; private set; }
        public void IsDrivingTimeSetUp(bool isDrivingTime)
        {
            IsDrivingTime = isDrivingTime;
        }

        private static int _minAccelerationValue = 5;
        private static int _maxAccelerationValue = 20;
        private static int _defaultAcceleration = 10;
        private static int _defaultBrakeValue = 10;
        private static int _maxSpeedValue = 250;
        private int _maxAcceleration;
        private int MaxAcceleration
        {
            get { return _maxAcceleration; }
            set
            {
                _maxAcceleration = value <= _minAccelerationValue ? _minAccelerationValue
                : value <= _maxAccelerationValue ? value : _maxAccelerationValue;
            }
        }
        public double ActualConsumption { get; private set; }
        public void ActualConsumptionSetUp(double consume)
        {
            ActualConsumption = consume;
        }

        public DrivingProcessor(int maxAcceleration)
        {
            MaxAcceleration = maxAcceleration;
            IsDrivingTime = false;
        }
        public DrivingProcessor()
        {
            MaxAcceleration = _defaultAcceleration;
            IsDrivingTime = false;

        }
        private int _actualSpeed;
        public int ActualSpeed
        {
            get { return _actualSpeed; }
            private set
            {
                _actualSpeed = value <= 0 ? 0 : value > 0 && value < _maxSpeedValue ?
                    value : _maxSpeedValue;
                SpeedChanged(this, new EventArgs());
            }
        }


        public void IncreaseSpeedTo(int speed)
        {
            ActualSpeed = GetValidSpeedForAccelerate(speed);
        }

        public void ReduceSpeed(int speed)
        {
            if (speed <= _defaultBrakeValue) ActualSpeed -= speed;
            else ActualSpeed -= _defaultBrakeValue;
        }
        
        public double GetCunsumeBySpeed(int speed)
        {
            int _speed = GetValidSpeedForAccelerate(speed);
            if (_speed >= 1 && _speed <= 60)
                return _1_60_KmhConsumption;
            if (_speed >= 61 && _speed <= 100)
                return _61_100_KmhConsumption;
            if (_speed >= 101 && _speed <= 140)
                return _101_140_KmhConsumption;
            if (_speed >= 141 && _speed <= 200)
                return _141_200_KmhConsumption;
            if (_speed >= 201 && _speed <= 250)
                return _201_250_KmhConsumption;
            return _idleConsumption;
        }

        private int GetValidSpeedForAccelerate(int speed)
        {
            if (speed <= ActualSpeed) return ActualSpeed;
            if (speed < ActualSpeed + MaxAcceleration && speed < _maxSpeedValue) return speed;
            if (ActualSpeed + MaxAcceleration < _maxSpeedValue) return ActualSpeed + MaxAcceleration;
            else return _maxSpeedValue;
        }

        public void EngineStart()
        {
            
        }

        public void EngineStop()
        {
           
        }
    }


}
