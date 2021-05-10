using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjectModel
{
    public class VelocityIncreaserModel : PowerUpModel
    {
        public int Multiplier { get; }

        public VelocityIncreaserModel(TimeSpan lifeTime, int multiplier, Sprite sprite)
        :base (sprite,
               player => player.Velocity *= multiplier,
               player => player.Velocity /= multiplier,
               (player, time) => { },
               lifeTime)
        {
            Multiplier = multiplier;
        }
    }
}