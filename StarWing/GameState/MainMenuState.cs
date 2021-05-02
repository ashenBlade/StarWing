using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework;

namespace StarWing.GameState
{
    public class MainMenuState : GameState
    {
        private Sprite ship;
        private Sprite background;
        private float velocity;
        private Vector2D position;
        public MainMenuState(GameStateManager gameStateManager, Game game) : base(gameStateManager, game)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            var image = Bitmap.FromFile("Ship1.png");
            var backImg = Bitmap.FromFile("background.jpg");
            ship = new Sprite(image);
            background = new Sprite(backImg, Game.GameWindow.WindowSize.Height, Game.GameWindow.WindowSize.Width, 0);
            position = new Vector2D();
            velocity = 5;
        }

        public override void Update(GameTime gameTime, Input input)
        {
            if (input.KeyboardStatus.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }

            // base.Update(gameTime, input);
            var offset = Vector2D.Zero;
            if (input.KeyboardStatus.IsKeyDown(Keys.Up))
            {
                offset += Vector2D.Down;
            }

            else if (input.KeyboardStatus.IsKeyDown(Keys.Down))
            {
                offset += Vector2D.Up;
            }

            if (input.KeyboardStatus.IsKeyDown(Keys.Left))
            {
                offset += Vector2D.Left;
            }

            else if (input.KeyboardStatus.IsKeyDown(Keys.Right))
            {
                offset += Vector2D.Right;
            }

            if (input.KeyboardStatus.IsKeyJustPressed(Keys.A))
            {
                velocity++;
            }
            else if (input.KeyboardStatus.IsKeyJustPressed(Keys.S))
            {
                velocity--;
            }
            position += offset * velocity;
            if (input.KeyboardStatus.IsKeyJustPressed(Keys.B))
            {
                GameStateManager.Load(new SpaceShooterPlayingState(GameStateManager, Game, null));
            }
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            background.Rotation += 10;
            graphics.DrawSprite(background, Vector2D.Zero);
            graphics.DrawSprite(ship, position);
        }
    }
}