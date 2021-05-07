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
        private UIMenu _menu;
        public MainMenuState(GameStateManager gameStateManager, Game game, GameObjectModelCollection gameObjectModelCollection) : base(gameStateManager, game)
        {
            _gameObjectModelCollection = gameObjectModelCollection;
            InitializeMenuLayer();
        }

        private void InitializeMenuLayer()
        {
            _menu = new UIMenu();
            var font = new Font(FontFamily.GenericMonospace, 12);
            var playButtonPosition = new Rectangle(100, 100, 100, 50);
            var playButtonText = new UILabel() { Font = font, Position = playButtonPosition.Location, Text = "Play"};
            var exitButtonPosition = new Rectangle(100, 200, 100, 50);
            var exitButtonText = new UILabel() { Font = font, Position = exitButtonPosition.Location, Text = "Exit"};
            var playButton = new UIButton() { Bounds = playButtonPosition, Content = playButtonText, Background = Color.White};
            playButton.Click += () => GameStateManager.Load(new PlayingState.PlayingState(GameStateManager, Game,
                                                                                          _gameObjectModelCollection));

            var exitButton = new UIButton() { Bounds = exitButtonPosition, Content = exitButtonText, Background = Color.White};
            exitButton.Click += () => Game.Exit();
            _menu.AddButton(playButton);
            _menu.AddButton(exitButton);
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