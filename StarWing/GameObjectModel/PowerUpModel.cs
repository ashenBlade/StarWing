using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;

namespace StarWing.GameObjectModel
{
    public class PowerUpModel : GameObjectModel
    {
        public Action<Player> Applier { get; }
        public Action<Player> TearDown { get; }
        public Action<Player, GameTime> Update { get; }
        public TimeSpan LifeTime { get; }
        public PowerUpModel(Sprite sprite, Action<Player> applier, Action<Player> tearDown, Action<Player, GameTime> update, TimeSpan lifeTime) : base(sprite)
        {
            Applier = applier;
            TearDown = tearDown;
            Update = update;
            LifeTime = lifeTime;
        }
    }
}