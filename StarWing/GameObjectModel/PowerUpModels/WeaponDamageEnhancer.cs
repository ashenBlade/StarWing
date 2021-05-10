using System;
using StarWing.Framework;

namespace StarWing.GameObjectModel
{
    public class WeaponDamageEnhancer : PowerUpModel
    {
        public WeaponDamageEnhancer(Sprite sprite, int multiplier, TimeSpan lifeTime)
        : base(sprite, player => player.Damage *= multiplier,
               player => player.Damage /= multiplier,
               (player, gameTime) => { },
               lifeTime)
        { }
    }
}