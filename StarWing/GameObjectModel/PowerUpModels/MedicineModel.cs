using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjectModel
{
    public class MedicineModel : PowerUpModel
    {
        public int Heal { get; }

        public MedicineModel(Sprite sprite, int heal)
            : base(sprite, player => player.Health += heal, player => { }, (player, gameTime) => { }, TimeSpan.Zero)
        {
            Heal = heal;
        }
    }
}