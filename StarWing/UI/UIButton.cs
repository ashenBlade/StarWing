using System;
using StarWing.UI;

namespace StarWing
{
    public class UIButton: UIComponent
    {
        public UIComponent Content { get; set; }

        public event System.Action Click;

        public event System.Action MouseEnter;

        public event System.Action MouseLeave;

        public event System.Action MouseHover;
    }
}