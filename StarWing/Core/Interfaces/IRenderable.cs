using StarWing.Framework;

namespace StarWing.Core.Interfaces
{
    public interface IRenderable
    {
        public Sprite Sprite { get; set; }
        public bool IsVisible { get; set; }
    }
}