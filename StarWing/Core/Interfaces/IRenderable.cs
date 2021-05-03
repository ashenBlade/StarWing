using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface IRenderable
    {
        public Sprite Sprite { get; }
        public bool IsVisible { get; }
    }
}