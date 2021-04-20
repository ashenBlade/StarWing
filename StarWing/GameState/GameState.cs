using System;
using System.Drawing;
using StarWing.Framework;

namespace StarWing.GameState
{
    public abstract class GameState
    {
        protected GameStateManager GameStateManager { get; }
        protected Game Game { get; }
        public GameState(GameStateManager gameStateManager, Game game)
        {
            GameStateManager = gameStateManager ?? throw new ArgumentNullException(nameof(gameStateManager));
            Game = game;
        }

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime, Input input) { }
        public virtual void Render(Graphics graphics) { }
    }
}