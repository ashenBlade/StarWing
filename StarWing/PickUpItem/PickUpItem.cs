using StarWing.Framework;

namespace StarWing.PickUpItem
{
    public abstract class PickUpItem
    {
        public Sprite Icon { get; set; }
        public virtual void Apply(Unit unit) { }
    }
}