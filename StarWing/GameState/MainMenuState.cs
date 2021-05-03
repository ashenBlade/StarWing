using System.Drawing;
using System.Windows.Forms;
using StarWing.Framework;

namespace StarWing.GameState
{
    public class MainMenuState : GameState
    {
        public MainMenuState(GameStateManager gameStateManager, Game game) : base(gameStateManager, game)
        { }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
        }
    }
}