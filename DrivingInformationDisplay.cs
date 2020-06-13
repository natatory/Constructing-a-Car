using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car
{
    class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        IDrivingProcessor _drivingProcessor;
        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }
        public int ActualSpeed { get { return _drivingProcessor.ActualSpeed; } }
    }
}
