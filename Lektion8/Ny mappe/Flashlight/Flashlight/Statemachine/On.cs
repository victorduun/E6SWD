using System;
using System.Collections.Generic;
using System.Text;

namespace Flashlight.Statemachine
{
    public class On : FlashlightState
    {
        public override void HandlePowerPressed(Flashlight flashlight)
        {
            flashlight.TurnLampOff();
            flashlight.SetState(new Off());
        }
        public override void OnEnter(Flashlight flashlight)
        {
            
        }

        public override void OnExit(Flashlight flashlight)
        {
            
        }
    }
}
