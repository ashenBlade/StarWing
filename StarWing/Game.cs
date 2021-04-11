using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using StarWing.Framework.Input;

namespace StarWing.Framework
{
    public abstract class Game
    {
        protected bool IsRunning { get; private set; }
        private GameWindow MainWindow { get; set; }
        private Keyboard _keyboard { get; set; }
        protected IKeyboard Keyboard =>
            _keyboard;

        private Mouse _mouse { get; set; }
        protected IMouse Mouse =>
            _mouse;

        protected Game()
        {
            InitializeMainWindow();
            InitializeInputDevices();
        }

        private void InitializeMainWindow()
        {
            MainWindow = new GameWindow(this);
            MainWindow.Size = new Size(820, 620);
            MainWindow.Paint += RenderFrame;
            MainWindow.Closed += (sender, args) => Exit();
        }

        private void InitializeInputDevices()
        {
            _keyboard = new Keyboard(MainWindow);
            _mouse = new Mouse(MainWindow);
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.Run(MainWindow);
        }

        internal void Start()
        {
            OnLoad();

            IsRunning = true;

            RunMainLoop();
        }


        private void RunMainLoop()
        {
            var gameTime = new GameTime();
            var fps = 0; // FPS Counter
            var previousCheckTime = gameTime.TotalTime;
            while (IsRunning)
            {
                Application.DoEvents();

                // Update game time
                gameTime.Update();

                // Update game logic
                Update(gameTime);

                // Render frame
                MainWindow.Refresh();

                #if DEBUG

                // Update FPS counter
                if (gameTime.TotalTime - previousCheckTime > TimeSpan.FromMilliseconds(1000))
                {
                    Console.Clear();
                    Console.WriteLine($"FPS: {fps}");
                    previousCheckTime = gameTime.TotalTime;
                    fps = 0;
                }
                else
                {
                    fps++;
                }

                #endif
            }
        }

        private void RenderFrame(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Turquoise);
            Render(e.Graphics);
        }


        protected void Exit()
        {
            // User exit function
            OnExit();

            // Set game state to ended
            IsRunning = false;

            Application.Exit();
        }

        protected internal virtual void OnExit()
        { }
        protected internal virtual void OnLoad()
        { }
        protected internal virtual void Update(IGameTime gameTime)
        { }
        protected internal virtual void Render(Graphics graphics)
        { }
    }
}