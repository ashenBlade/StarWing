using System;
using StarWing.Framework;
using StarWing.GameState;

namespace StarWing
{
    public class StarWing : Game
    {
        private GameStateManager GameStateManager { get; }

        public StarWing()
        {
            GameWindow.FullScreen = true;
            GameStateManager = new GameStateManager(this);
        }
    }
}