using System;
using StarWing.Framework;

namespace StarWing.GameObjects.Items
{
    public abstract class PowerUp : Item
    {
        public TimeSpan LifeTime { get; protected set; }

        protected PowerUp(TimeSpan lifeTime)
        {
            LifeTime = lifeTime;
        }


    }
}