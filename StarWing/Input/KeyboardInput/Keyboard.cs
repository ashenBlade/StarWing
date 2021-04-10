using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public class Keyboard : IKeyboard
    {
        // Keys are being currently pressed
        private readonly HashSet<Keys> _beingPressed;

        /// <param name="form">Form to listen input from</param>
        public Keyboard(Form form)
        {
            _beingPressed = new HashSet<Keys>();

            form.KeyDown += UpdateOnKeyDown;
            form.KeyUp += UpdateOnKeyUp;
        }

        public KeyboardStatus Status =>
            new KeyboardStatus(_beingPressed);

        private void UpdateOnKeyUp(object sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _beingPressed.Remove(key);
        }
        private void UpdateOnKeyDown(object sender, KeyEventArgs args)
        {
            var key = args.KeyCode;
            _beingPressed.Add(key);
        }
    }
}