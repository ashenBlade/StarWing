using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.GameWorld;

namespace StarWing.GameState.PlayingState
{
    public class PlayingState : GameState
    {
        private GameObjectModelCollection ModelCollection { get; }
        private IBackground Background { get; }
        private World World { get; set; }
        private UILayer HUD { get; }
        private UILayer MainMenu { get; }

        private bool _isPaused;

        public PlayingState(GameStateManager gameStateManager, Game game, GameObjectModelCollection gameObjectModelCollection) :
            base(gameStateManager, game)
        {
            ModelCollection = gameObjectModelCollection;
            // Background = new OuterSpace();
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
            // TODO
        }

        public override void Update(GameTime gameTime, Input input)
        {
            if (input.KeyboardStatus.IsKeyJustPressed(Keys.Escape))
            {
                _isPaused = !_isPaused;
            }

            if (!_isPaused)
            {
                // Background.Update(gameTime);
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
            // Background.Render(graphics);
            World.Render(graphics);
            HUD.Render(graphics);
            if (_isPaused)
            {
                MainMenu.Render(graphics);
            }
        }
    }
}