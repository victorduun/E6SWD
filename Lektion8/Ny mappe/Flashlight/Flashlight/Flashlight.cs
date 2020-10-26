using Flashlight.Statemachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashlight
{
    public class Flashlight
    {
        private FlashlightState _state;
        private readonly ILamp _lamp;

        public Flashlight(ILamp lamp)
        {
            _lamp = lamp;
            _state = new Statemachine.Off();
            _state.OnEnter(this);
        }

        public void SetState(FlashlightState state)
        {
            _state.OnExit(this);
            _state = state;
            _state.OnEnter(this);
        }

        public void PowerPressed()
        {
            _state.HandlePowerPressed(this);
        }

        public void TurnLampOn()
        {
            _lamp.TurnOn();
        }

        public void TurnLampOff()
        {
            _lamp.TurnOff();
        }
    }

}
