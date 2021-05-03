using System.Drawing;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.ECS
{
    public abstract class GameObject
    {
        protected IWorld World { get; private set; }
        public void Initialize(IWorld world)
        {
            World = world;
        }
        public virtual void Update(GameTime gameTime, Input input)
        { }
        public virtual void Render(Graphics graphics)
        { }
    }
}