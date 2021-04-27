using System.Drawing;
using StarWing.Framework;

namespace StarWing.UI
{
    public class UIComponent
    {
        public Vector2D  Position { get; set; }
        
        public Rectangle Bounds { get; set; }

        public virtual void Update(Gametime gametime, Input input)
        {
            
        }

        public virtual void Render(Graphics graphics)
        {
            
        }
    }
}