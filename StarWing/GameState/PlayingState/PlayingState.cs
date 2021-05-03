﻿using System.Drawing;
using System.Windows.Forms;
using StarWing.ECS;
using StarWing.Framework;

namespace StarWing.GameState
{
    public class PlayingState : GameState
    {
        private IBackground Background { get; }
        private World World { get; set; }
        private UILayer HUD { get; }
        private UILayer MainMenu { get; }

        private bool _isPaused;

        public PlayingState(GameStateManager gameStateManager, Game game) :
            base(gameStateManager, game)
        {
            // Background = new StaticBackground(game.GameWindow.Size, image);
            _isPaused = false;

            HUD = new UILayer();
            MainMenu = new UILayer();
            World = new World(null);
        }

        public override void Update(GameTime gameTime, Input input)
        {
            if (input.KeyboardStatus.IsKeyJustPressed(Keys.Escape))
            {
                _isPaused = !_isPaused;
            }

            if (!_isPaused)
            {
                // Background.Update(gameTime);
                World.Update(gameTime, input);
                HUD.Update(gameTime, input);
            }
            else
            {
                MainMenu.Update(gameTime, input);
            }
        }

        public override void Render(Graphics graphics)
        {
            // Background.Render(graphics);
            World.Render(graphics);
            HUD.Render(graphics);
            if (_isPaused)
            {
                MainMenu.Render(graphics);
            }
        }
    }
}