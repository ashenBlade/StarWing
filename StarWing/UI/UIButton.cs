using System;

namespace StarWing.UI
{
    public class UIButton: UIComponent
    {
        public UIComponent Content { get; set; }

        public event Action Click;
        public event Action MouseEnter;
        public event Action MouseLeave;
        public event Action MouseHover;
    }
}