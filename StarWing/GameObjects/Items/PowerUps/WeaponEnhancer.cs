using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjects.Items.PowerUps
{
    public class WeaponEnhancer : PowerUp
    {
        public WeaponEnhancer(double coolDownMultiplier, TimeSpan lifetime )
            : base(lifetime,
                   player => player.CoolDown *= coolDownMultiplier,
                   player => player.CoolDown /= coolDownMultiplier,
                   (player, time) => { })
        { }
    }
}