using System;

namespace StarWing.GameObjects.Items.PowerUps
{
    public class Medicine : PowerUp
    {
        public Medicine(int heal) : base(TimeSpan.FromSeconds(1), player => player.Health += heal, player => { }, (player, time) => { })
        { }
    }
}