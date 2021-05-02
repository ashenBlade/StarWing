using StarWing.Framework;

namespace StarWing.ECS
{
    public class RenderComponent : Component
    {
        public Sprite Sprite { get; set; }
        public bool IsVisible { get; set; }
    }
}