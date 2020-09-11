using System;

namespace CompressionStocking.BusinessLogic
{
    public interface IPressureSensor
    {
        UInt32 GetPressure();
        void SetPressureChangedListener(IPressureChangedListener listener);
    }
}
