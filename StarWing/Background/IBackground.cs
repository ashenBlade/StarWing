using System.Drawing;
using StarWing.Framework;

namespace StarWing
{
    public interface IBackground
    {
        public void Render(Graphics graphics);
        public void Update(GameTime gameTime);
    }
}