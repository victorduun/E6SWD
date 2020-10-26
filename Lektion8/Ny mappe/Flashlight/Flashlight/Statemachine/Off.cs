using System;
using System.Collections.Generic;
using System.Text;

namespace Flashlight.Statemachine
{
    public class Off : FlashlightState
    {
        public override void HandlePowerPressed(Flashlight flashlight)
        {
            flashlight.TurnLampOn();
            flashlight.SetState(new On());
        }
        public override void OnEnter(Flashlight flashlight)
        {
        }

        public override void OnExit(Flashlight flashlight)
        {
        }
    }
}
