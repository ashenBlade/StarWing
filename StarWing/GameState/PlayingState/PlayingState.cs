using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using StarWing.Core.Interfaces;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.GameObjects.Implementations;
using StarWing.GameObjects.Manager;
using StarWing.GameObjects.SceneObjects;
using StarWing.GameWorld;
using StarWing.UI;

namespace StarWing.GameState.PlayingState
{
    public class PlayingState : GameState
    {
        private GameObjectModelCollection ModelCollection { get; }
        private IBackground Background { get; set; }
        private World World { get; set; }
        private UILayer HUD { get; }
        private UILayer PauseMenu { get; }

        private bool _isPaused;
        private bool _isGameOver;

        public PlayingState(GameStateManager gameStateManager, Game game, GameObjectModelCollection gameObjectModelCollection) :
            base(gameStateManager, game)
        {
            ModelCollection = gameObjectModelCollection;
            Background = new OuterSpace(Game.GameWindow.Size.Height, Game.GameWindow.Size.Width);
            World = new World(new Rectangle(Point.Empty, Game.GameWindow.Size), null);

            HUD = new UILayer();
            SetUpHUD(HUD);

            PauseMenu = new UILayer();
            SetUpPauseMenu(PauseMenu);

            _isPaused = false;
            _isGameOver = false;
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
            var factory = new PickUpFactory(powerUpModels);
            var manager = new PowerUpManager(factory, TimeSpan.FromSeconds(10));
            return manager;
        }

        private EnemyManager GetEnemyManager(IEnumerable<ShipModel> shipModels)
        {
            var factory = new EnemyFactory(shipModels, World);
            var enemyManager = new EnemyManager(factory, 10, TimeSpan.FromSeconds(1));
            return enemyManager;
        }

        private Player GetPlayer(ShipModel playerModel)
        {
            var player = new Player(World)
                         {
                             Position = new Vector2D(400, 400),
                             Bounds = playerModel.Sprite.Size,
                             CoolDown = TimeSpan.FromMilliseconds(500),
                             MaxCoolDown = TimeSpan.FromMilliseconds(500),
                             Damage = 10,
                             MaxHealth = playerModel.Health,
                             Health = playerModel.Health,
                             IsVisible = true,
                             Sprite = playerModel.Sprite,
                             Velocity = playerModel.Velocity,
                             ProjectileFactory = playerModel.ProjectileFactory
                         };
            player.Die += livable =>
            {
                _isGameOver = true;
                var gameOverTextPosition = new Point(100, Game.GameWindow.Size.Width / 3);
                var gameOverTextBounds = new Rectangle(gameOverTextPosition, Size.Empty);
                var gameOverText = new UILabel()
                                   {
                                       Background = Color.Transparent,
                                       Bounds = gameOverTextBounds,
                                       Text = "Game over",
                                       Font = new Font(FontFamily.GenericMonospace, 50),
                                       FontColor = Color.White
                                   };
                PauseMenu.AddComponent(gameOverText);
            };
            player.HealthChanged += UpdateHudOnPlayerHealthChanged;
            return player;
        }

        private void UpdateHudOnPlayerHealthChanged(ILivable livable, int delta)
        {
            _hpBar.CurrentValue = livable.Health;
            _hpBar.MaxValue = livable.MaxHealth;
        }

        private UIBar _hpBar;
        private void SetUpHUD(UILayer hud)
        {
            var scoresLabelPosition = new Vector2D(10, 10);
            var scoresLabel = new UILabel()
                              {
                                  Text = $"Scores: 0",
                                  FontColor = Color.White,
                                  Background = Color.Transparent,
                                  Bounds = new Rectangle(scoresLabelPosition, Size.Empty),
                                  Font = new Font(FontFamily.GenericMonospace, 12),
                              };
            hud.AddComponent(scoresLabel);

            var hpBarPosition = new Vector2D(scoresLabelPosition.X, scoresLabelPosition.Y + scoresLabel.Bounds.Height + 30);
            _hpBar = new UIBar(100, 100, Color.Red)
                     {
                         Position = hpBarPosition,
                         Background = Color.Transparent,
                         Bounds = new Rectangle(hpBarPosition, new Size(150, 15))

                     };
            hud.AddComponent(_hpBar);
        }

        private void SetUpPauseMenu(UILayer menu)
        {
            var gameWindowSize = Game.GameWindow.Size;
            var standardButtonSize = new Size(100, 50);
            var buttonPadding = 10; // padding between buttons

            var resumeButtonPosition = new Point(gameWindowSize.Width / 2 - standardButtonSize.Width / 2,
                                                 gameWindowSize.Height / 2
                                               - standardButtonSize.Height / 2
                                               - standardButtonSize.Height);
            var resumeButtonBounds = new Rectangle( resumeButtonPosition, standardButtonSize);
            var resumeText = new UILabel()
                             {
                                 Background =  Color.White,
                                 Font = new Font(FontFamily.GenericMonospace, 12),
                                 FontColor = Color.Black,
                                 Text = "Resume",
                                 Position = resumeButtonBounds.Location,
                             };
            var resumeButton = new UIButton(resumeText)
                               {
                                   Background = Color.White,
                                   Bounds = resumeButtonBounds
                               };
            resumeButton.Click += () => _isPaused = false;
            menu.AddComponent(resumeButton);

            var exitButtonPosition = new Point(gameWindowSize.Width / 2 - standardButtonSize.Width / 2,
                                               gameWindowSize.Height / 2
                                             - standardButtonSize.Height / 2
                                             + buttonPadding);
            var exitButtonBounds = new Rectangle( exitButtonPosition, standardButtonSize);
            var exitText = new UILabel()
                           {
                               Background = Color.White,
                               Position = exitButtonBounds.Location,
                               Text = "Exit",
                               Font = new Font(FontFamily.GenericMonospace, 12),
                               Bounds = exitButtonBounds
                           };
            var exitButton = new UIButton()
                             {
                                 Content = exitText, Background = Color.White, Bounds = exitButtonBounds,
                             };
            exitButton.Click += Game.Exit;
            menu.AddComponent(exitButton);
        }

        public override void Update(GameTime gameTime, Input input)
        {
            if (input.KeyboardStatus.IsKeyJustPressed(Keys.Escape))
            {
                _isPaused = !_isPaused;
            }

            if (!_isPaused && !_isGameOver)
            {
                Background.Update(gameTime);
                World.Update(gameTime, input);
                HUD.Update(gameTime, input);
            }
            else
            {
                PauseMenu.Update(gameTime, input);
            }
        }

        public override void Render(Graphics graphics)
        {
            Background.Render(graphics);
            World.Render(graphics);
            HUD.Render(graphics);
            if (_isPaused || _isGameOver)
            {
                PauseMenu.Render(graphics);
            }
        }
    }
}