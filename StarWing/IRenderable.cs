using System.Drawing;

namespace StarWing.Framework
{
    public interface IRenderable
    {
        void Render(Graphics graphics);
        int RenderOrder { get; }
        bool IsVisible { get; }
    }
}