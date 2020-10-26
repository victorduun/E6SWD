using System;

namespace Flashlight.Statemachine
{
    public abstract class FlashlightState
    {
        public abstract void OnEnter(Flashlight flashlight);
        public abstract void OnExit(Flashlight flashlight);

        public virtual void HandlePowerPressed(Flashlight flashlight) { }

    }
}
