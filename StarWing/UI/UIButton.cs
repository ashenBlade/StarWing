using System;
using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.Framework.Input;
using StarWing.UI;

namespace StarWing
{
    public class UIButton: UIComponent
    {
        private MouseStatus _previousMouseStatus;
        public UIComponent Content { get; set; }

        public UIButton()
        {
        }

        public UIButton(UIComponent content)
        {
            Content = content;
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            Content?.Update(gameTime, input);
            var currentMouseStatus = input.MouseStatus;
            var containsCurrentPosition = Bounds.Contains(currentMouseStatus.Position);
            var containsPreviousPosition = Bounds.Contains(_previousMouseStatus.Position);

            if (containsCurrentPosition && !containsPreviousPosition)
            {
                MouseEnter?.Invoke();
            }
            else if(!containsCurrentPosition && containsPreviousPosition)
            {
                MouseLeave?.Invoke();
            }
            else if (containsCurrentPosition)
            {
                MouseHover?.Invoke();
            }

            if (containsCurrentPosition && currentMouseStatus.IsButtonJustPressed(MouseButtons.Left))
            {
                Click?.Invoke();
            }
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            Content?.Render(graphics);
        }

        public event Action Click;

        public event Action MouseEnter;

        public event Action MouseLeave;

        public event Action MouseHover;
    }
}