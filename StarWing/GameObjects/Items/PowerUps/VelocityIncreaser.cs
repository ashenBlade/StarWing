using System;
using Accessibility;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Items.PowerUps
{
    public class VelocityIncreaser : PowerUp
    {
        public VelocityIncreaser(TimeSpan lifeTime, int multiplier)
            : base(lifeTime,
                   player => player.Velocity *= multiplier,
                   player => player.Velocity /= multiplier,
                   (player, time) => { })
        {
        }
    }
}