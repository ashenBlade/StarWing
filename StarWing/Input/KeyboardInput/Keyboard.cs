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

        public KeyboardStatus Status =>
            new KeyboardStatus(_beingPressed);

        /// <param name="form">Form to listen input from</param>
        public Keyboard(Form form)
        {
            _beingPressed = new HashSet<Keys>();

            form.KeyDown += (sender, args) => UpdateOnKeyDown(form, args);
            form.KeyUp += (sender, args) =>  UpdateOnKeyUp(form, args);
        }

        private void UpdateOnKeyUp(Form form, KeyEventArgs args)
        {
            var key = args.KeyCode;
            form.BeginInvoke(( MethodInvoker ) ( () => _beingPressed.Remove(key) ));
        }
        private void UpdateOnKeyDown(Form form, KeyEventArgs args)
        {
            var key = args.KeyCode;
            form.BeginInvoke(( MethodInvoker ) ( () => _beingPressed.Add(key) ));
        }
    }
}