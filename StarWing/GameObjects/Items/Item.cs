using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Items
{
    public abstract class Item
    {
        public virtual void Update(GameTime gameTime) { }
        public abstract void Apply(Player player);
    }
}