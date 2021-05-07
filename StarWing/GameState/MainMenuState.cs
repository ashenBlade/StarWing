using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.GameObjectModel;
using StarWing.UI;

namespace StarWing.GameState
{
    public class MainMenuState : GameState
    {
        private GameObjectModelCollection _gameObjectModelCollection;
        private UILayer _menu;
        public MainMenuState(GameStateManager gameStateManager, Game game, GameObjectModelCollection gameObjectModelCollection) : base(gameStateManager, game)
        {
            _gameObjectModelCollection = gameObjectModelCollection;
            InitializeMenuLayer();
        }

        private void InitializeMenuLayer()
        {
            _menu = new UILayer();
            var font = new Font(FontFamily.GenericMonospace, 12);
            var playButtonText = new UILabel() { Font = font, Bounds = new Rectangle(100, 100, 100, 50) , Text = "Play" };
            var exitButtonText = new UILabel() { Font = font, Bounds = new Rectangle(100, 200, 100, 50), Text = "Exit" };
            var playButton = new UIButton() { Bounds = new Rectangle(new Point(100, 100), new Size(100, 50)), Content = playButtonText};
            playButton.Click += () => GameStateManager.Load(new PlayingState.PlayingState(GameStateManager, Game,
                                                                                          _gameObjectModelCollection));

            var exitButton = new UIButton() { Bounds = new Rectangle(new Point(100, 200), new Size(100, 50)), Content = exitButtonText};
            exitButton.Click += () => Game.Exit();
            _menu.AddComponent(playButton);
            _menu.AddComponent(exitButton);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
            _menu.Update(gameTime, input);
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            _menu.Render(graphics);
        }
    }
}