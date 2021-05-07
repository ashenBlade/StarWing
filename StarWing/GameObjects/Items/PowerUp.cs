using System;
using StarWing.Framework;
using StarWing.GameObjects.SceneObjects;
using StarWing.GameWorld;

namespace StarWing.GameObjects.Items
{
    public class PowerUp : Item
    {
        private TimeSpan LifeTime { get; set; }
        private Player _player;
        private Action<Player> _applier;
        private Action<Player> _teardown;
        private Action<Player, GameTime> _update;
        public PowerUp(TimeSpan lifeTime, Action<Player> applier, Action<Player> teardown, Action<Player, GameTime> update)
        {
            LifeTime = lifeTime;
            _applier = applier;
            _teardown = teardown;
            _update = update;
        }

        public override void Apply(Player player)
        {
            _player = player;
            _player.ApplyPowerUp(this);
            _applier(player);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            LifeTime -= gameTime.SinceLastUpdate;
            if (LifeTime < TimeSpan.Zero)
            {
                _teardown(_player);
                _player.RemovePowerUp(this);
            }

            _update(_player, gameTime);
        }
    }
}