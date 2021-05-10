using System;
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
        private const int StandardShipDamage = 10;
        public LoadingState(GameStateManager gameStateManager, Game game) : base(gameStateManager, game) { }
        public override void LoadContent()
        {
            base.LoadContent();
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
            var model = new ShipModel(sprite, 1.0f, 100, projectileFactory, TimeSpan.FromSeconds(2), StandardShipDamage);
            return model;
        }

        private List<PowerUpModel> LoadPowerUpModels()
        {
            var list = new List<PowerUpModel>();

            var powerUpModelSize = new Size(30, 30);

            var velocityIncreaserSprite = new Sprite(Image.FromFile("Assets/bonus/crys0.png"), powerUpModelSize);
            var velocityIncreaser = new VelocityIncreaserModel(TimeSpan.FromSeconds(5), 2, velocityIncreaserSprite);
            list.Add(velocityIncreaser);

            var medicineSprite = new Sprite(Image.FromFile("Assets/bonus/metal-plate-medicine.png"), powerUpModelSize);
            var medicine = new MedicineModel(medicineSprite, 10);
            list.Add(medicine);

            var weaponEnhancerSprite = new Sprite(Image.FromFile("Assets/bonus/sand-clock.png"), powerUpModelSize);
            var enhancer = new WeaponCoolDownEnhancerModel(TimeSpan.FromSeconds(10), 2, weaponEnhancerSprite);
            list.Add(enhancer);

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
            var model = new ShipModel(sprite, 0.25f, 10, factory, TimeSpan.FromSeconds(2), StandardShipDamage);
            list.Add(model);
            return list;
        }
    }
}