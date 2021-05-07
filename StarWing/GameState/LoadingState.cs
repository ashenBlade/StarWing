using System.Collections.Generic;
using System.Drawing;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.Items;

namespace StarWing.GameState
{
    public class LoadingState : GameState
    {
        public LoadingState(GameStateManager gameStateManager, Game game) : base(gameStateManager, game) { }
        public override void LoadContent()
        {
            base.LoadContent();
            // Load ship models, powerup models, etc...
            // Then load MainMenuState (in update)
            var projectileFactory = LoadProjectileFactory();
            var powerUpModels = LoadPowerUpModels();
            var shipModels = LoadShipModels(projectileFactory);
            var playerModel = LoadPlayerShipModel(projectileFactory);
            var gameObjectCollection = new GameObjectModelCollection(playerModel, shipModels, powerUpModels);
            GameStateManager.Load(new MainMenuState(GameStateManager, Game, gameObjectCollection));
        }

        private ShipModel LoadPlayerShipModel(ProjectileFactory projectileFactory)
        {
            var sprite = new Sprite(Image.FromFile("Assets/player/ship2.png"));
            var model = new ShipModel(sprite, 1, 10, projectileFactory);
            return model;
        }

        private List<PowerUpModel> LoadPowerUpModels()
        {
            var list = new List<PowerUpModel>();
            var sprite = new Sprite(Image.FromFile("Assets/bonus/crys0.png"));
            var powerUp = new PowerUpModel(sprite);
            list.Add(powerUp);
            return list;
        }

        private ProjectileFactory LoadProjectileFactory()
        {
            var image = Image.FromFile("Assets/projectiles/shotoval.png");
            var sprite = new Sprite(image);
            var factory = new ProjectileFactory(sprite, 10);
            return factory;
        }

        private List<ShipModel> LoadShipModels(ProjectileFactory factory)
        {
            var list = new List<ShipModel>();
            var image = Image.FromFile("Assets/enemies/kamikaze.png");
            var sprite = new Sprite(image);
            var model = new ShipModel(sprite, 10, 100, factory);
            list.Add(model);
            return list;
        }
    }
}