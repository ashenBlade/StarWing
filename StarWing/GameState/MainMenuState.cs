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
            var standardButtonSize = new Size(100, 50);
            var buttonPadding = 10;

            var playButtonPosition = new Vector2D(Game.GameWindow.Width / 2 - standardButtonSize.Width / 2, 100);
            var playButtonBounds = new Rectangle(playButtonPosition,standardButtonSize);
            var playButtonText = new UILabel() { Font = font, Position = playButtonBounds.Location, Text = "Play"};
            var playButton = new UIButton() { Bounds = playButtonBounds, Content = playButtonText, Background = Color.White};
            playButton.Click += () => GameStateManager.Load(new PlayingState.PlayingState(GameStateManager, Game,
                                                                                          _gameObjectModelCollection));
            _menu.AddButton(playButton);

            var exitButtonPosition = new Vector2D(playButtonPosition.X,
                                                  playButtonPosition.Y + standardButtonSize.Height + buttonPadding);
            var exitButtonBounds = new Rectangle(exitButtonPosition, standardButtonSize);
            var exitButtonText = new UILabel() { Font = font, Position = exitButtonBounds.Location, Text = "Exit"};
            var exitButton = new UIButton() { Bounds = exitButtonBounds, Content = exitButtonText, Background = Color.White};
            exitButton.Click += () => Game.Exit();
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