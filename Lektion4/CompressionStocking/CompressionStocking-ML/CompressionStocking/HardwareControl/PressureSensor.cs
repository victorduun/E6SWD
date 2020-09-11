using CompressionStocking.BusinessLogic;
using System;
using System.Timers;

namespace CompressionStocking.HardwareControl
{
    public class PressureSensor : IPressureSensor
    {
        private IPressureChangedListener myListener;
        UInt32 pressure = 0;
        Timer updateTimer = new Timer();
        const UInt32 UPDATE_INTERVAL_IN_MILLIS = 100;

        public PressureSensor()
        {
            updateTimer.Interval = UPDATE_INTERVAL_IN_MILLIS;
            updateTimer.AutoReset = true;
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Start();
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UInt32 lastPressure = pressure;
            pressure = SamplePressure();
            if (pressure != lastPressure)
            {
                if (myListener != null)
                {
                    myListener.PressureChanged();
                }
            }
        }

        /**
         * @return The pressure measured in Pascal.
         */
        public uint GetPressure()
        {
            return pressure;
        }

        public void SetPressureChangedListener(IPressureChangedListener listener)
        {
            myListener = listener;
        }

        /**
         * Samples some hardware, which provides a pressure measurement.
         * @return The pressure measured in Pascal.
         */
        public virtual UInt32 SamplePressure()
        {
            return 0;
        }
    }
}
