using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.GameState
{
    public class GameStateManager
    {
        private Game Game { get; }
        private GameState CurrentState { get; set; }

        public GameStateManager(Game game)
        {
            Game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public void Load(GameState gameState)
        {
            CurrentState.UnloadContent();
            CurrentState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            CurrentState.Initialize();
            CurrentState.LoadContent();
        }

        public void Update(GameTime gameTime, Input input)
        {
            CurrentState?.Update(gameTime, input);
        }

        public void Render(Graphics graphics)
        {
            CurrentState?.Render(graphics);
        }
    }
}