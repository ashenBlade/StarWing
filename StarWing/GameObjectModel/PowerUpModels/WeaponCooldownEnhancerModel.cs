using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjectModel
{
    public class WeaponCoolDownEnhancerModel : PowerUpModel
    {
        public int Multiplier { get; }
        public WeaponCoolDownEnhancerModel(TimeSpan lifeTime, int multiplier, Sprite sprite)
        : base(sprite,
               player => player.CoolDown /= multiplier,
               player => player.CoolDown *= multiplier,
               (player, time) => { },
               lifeTime)
        {
            Multiplier = multiplier;
        }
    }
}