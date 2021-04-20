using System;

namespace StarWing.PickUpItem
{
    public abstract class Weapon : PickUpItem
    {
        public TimeSpan CoolDown { get; set; }

        public virtual void Shoot()
        { }
    }
}