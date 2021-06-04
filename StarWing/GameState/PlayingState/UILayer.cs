using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using StarWing.Framework;
using StarWing.UI;

namespace StarWing.GameState
{
    public class UILayer
    {
        private List<UIComponent> _components;

        public UILayer(IEnumerable<UIComponent> components = null)
        {
            _components = new List<UIComponent>();
            if (components != null)
            {
                _components.AddRange(components);
            }
        }

        public void AddComponent(UIComponent component)
        {
            _components.Add(component);
        }

        public virtual void Update(GameTime gameTime, Input input)
        {
            _components.ForEach(component => component.Update(gameTime, input));
        }

        public virtual void Render(Graphics graphics)
        {
            _components.ForEach(component => component.Render(graphics));
        }
    }
}