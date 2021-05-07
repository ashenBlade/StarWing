using System.Collections.Generic;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.UI
{
    public class UIMenu : UIComponent
    {
        private List<UIButton> _buttons = new List<UIButton>();

        public void AddButton(UIButton button)
        {
            _buttons.Add(button);
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            _buttons.ForEach(button => button.Render(graphics));
        }

        public override void Update(GameTime gametime, Input input)
        {
            base.Update(gametime, input);
            _buttons.ForEach(button => button.Update(gametime, input));
        }
    }
}