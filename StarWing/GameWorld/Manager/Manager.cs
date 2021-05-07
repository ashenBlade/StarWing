using System.CodeDom;
using StarWing.Core;
using StarWing.Framework;

namespace StarWing.GameObjects.Manager
{
    public abstract class Manager
    {
        protected IWorld World { get; private set; }

        public virtual void Initialize(IWorld world)
        {
            World = world;
        }

        public virtual void Update(GameTime gameTime)
        { }
    }
}