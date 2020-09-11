using CompressionStocking.HardwareControl;
using System;

namespace CompressionStocking.UserInterface

{
    public class SimulatedPressureSensor : PressureSensor
    {
        private UInt32 pressure = 0;

        public SimulatedPressureSensor(UInt32 initialPressure)
            : base()
        {
            pressure = initialPressure;
        }

        public override uint SamplePressure()
        {
            return pressure;
        }

        public void IncreasePressure(UInt32 pascal)
        {
            pressure += pascal;
        }

        public void DecreasePressure(UInt32 pascal)
        {
            pressure -= pascal;
        }
    }
}
