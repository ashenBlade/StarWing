using System;
using System.Drawing;
using System.Resources;
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
        }

        protected override void OnStarting()
        {
            base.OnStarting();
            var startState = new MainMenuState(GameStateManager, this);
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