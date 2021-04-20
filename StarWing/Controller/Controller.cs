using StarWing.Framework;

namespace StarWing
{
    public class Controller
    {
        protected GameObject Actor;

        public Controller(GameObject actor)
        {
            Actor = actor;
        }

        public virtual void Update(GameTime gameTime, Input input) { }
    }
}