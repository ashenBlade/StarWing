using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.GameState;

namespace StarWing
{
    public class StarWing : Game
    {
        private GameStateManager GameStateManager { get; }

        public StarWing()
        {
            GameStateManager = new GameStateManager(this);
            GameWindow.WindowSize = new Size(600, 800);
            GameWindow.AutoSize = false;
            GameWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        protected override void OnStarting()
        {
            base.OnStarting();
            var startState = new LoadingState(GameStateManager, this);
            GameStateManager.Load(startState);
        }

        private Input GetCurrentInputState() =>
            new Input(Mouse.Status, Keyboard.Status);

        protected override void Update(GameTime gameTime)
        {
            var input = GetCurrentInputState();
            GameStateManager.Update(gameTime, input);
        }

        protected override void Render(Graphics graphics)
        {
            GameStateManager.Render(graphics);
        }
    }
}