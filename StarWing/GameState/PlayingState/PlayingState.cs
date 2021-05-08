using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.Manager;
using StarWing.GameObjects.SceneObjects;
using StarWing.GameWorld;

namespace StarWing.GameState.PlayingState
{
    public class PlayingState : GameState
    {
        private GameObjectModelCollection ModelCollection { get; }
        private IBackground Background { get; set; }
        private World World { get; set; }
        private UILayer HUD { get; }
        private UILayer MainMenu { get; }

        private bool _isPaused;

        public PlayingState(GameStateManager gameStateManager, Game game, GameObjectModelCollection gameObjectModelCollection) :
            base(gameStateManager, game)
        {
            ModelCollection = gameObjectModelCollection;
            Background = new OuterSpace();
            World = new World(new Rectangle(Point.Empty, Game.GameWindow.Size), null);
            HUD = new UILayer();
            MainMenu = new UILayer();
            _isPaused = false;
        }


        public override void Initialize()
        {
            base.Initialize();
            InitializeGameWorld(ModelCollection);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        private void InitializeGameWorld(GameObjectModelCollection collection)
        {
            InitializeManagers(collection);

            var player = GetPlayer(collection.PlayerModel);
            World.RegisterGameObject(player);
            
        }

        private void InitializeManagers(GameObjectModelCollection collection)
        {
            var collisionManager = new CollisionManager();
            World.RegisterManager(collisionManager);

            var enemyManager = GetEnemyManager(collection.ShipModels);
            World.RegisterManager(enemyManager);

            var powerUpManager = GetPowerUpManager(collection.PowerUpModels);
            World.RegisterManager(powerUpManager);
        }

        private PowerUpManager GetPowerUpManager(IEnumerable<PowerUpModel> powerUpModels)
        {
            var manager = new PowerUpManager();
            return manager;
        }

        private EnemyManager GetEnemyManager(IEnumerable<ShipModel> shipModels)
        {
            var factory = new EnemyFactory(shipModels, World);
            var enemyManager = new EnemyManager(factory, 10, TimeSpan.FromSeconds(3));
            return enemyManager;
        }

        private Player GetPlayer(ShipModel playerModel)
        {
            var player = new Player(World)
                         {
                             Position = new Vector2D(400, 400),
                             Bounds = new Size(100, 100),
                             CoolDown = TimeSpan.FromMilliseconds(500),
                             Damage = 10,
                             MaxHealth = playerModel.Health,
                             Health = playerModel.Health,
                             IsVisible = true,
                             MaxCoolDown = TimeSpan.FromMilliseconds(500),
                             Sprite = playerModel.Sprite,
                             Velocity = playerModel.Velocity,
                             ProjectileFactory = playerModel.ProjectileFactory
                         };
            return player;
        }

        public override void Update(GameTime gameTime, Input input)
        {
            if (input.KeyboardStatus.IsKeyJustPressed(Keys.Escape))
            {
                _isPaused = !_isPaused;
            }

            if (!_isPaused)
            { 
                Background.Update(gameTime);
                World.Update(gameTime, input);
                HUD.Update(gameTime, input);
            }
            else
            {
                MainMenu.Update(gameTime, input);
            }
        }

        public override void Render(Graphics graphics)
        {
            Background.Render(graphics);
            World.Render(graphics);
            HUD.Render(graphics);
            if (_isPaused)
            {
                MainMenu.Render(graphics);
            }
        }
    }
}