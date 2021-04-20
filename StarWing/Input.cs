using StarWing.Framework.Input;

namespace StarWing
{
    public class Input
    {
        public KeyboardStatus KeyboardStatus { get; }
        public MouseStatus MouseStatus { get; }

        public Input(MouseStatus mouseStatus, KeyboardStatus keyboardStatus)
        {
            MouseStatus = mouseStatus;
            KeyboardStatus = keyboardStatus;
        }
    }
}