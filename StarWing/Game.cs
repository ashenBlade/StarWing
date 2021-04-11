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
        private Keyboard _keyboard;
        protected IKeyboard Keyboard =>
            _keyboard;

        private Mouse _mouse;
        protected IMouse Mouse =>
            _mouse;

        protected Game()
        {
            InitializeMainWindow();
            InitializeInputDevices();

#if DEBUG
            Log.RegisterOutput(Console.Out);
#endif
        }

        private void InitializeMainWindow()
        {
            MainWindow = new GameWindow(this);
            MainWindow.Size = new Size(1280, 720);
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
            Application.Run(MainWindow);
        }

        internal void Start()
        {
            Log.Info("Game is starting");

            OnLoad();
            IsRunning = true;
            RunMainLoop();
        }


        private void RunMainLoop()
        {
            var timer = new GameTimer();
            var fps = 0; // FPS Counter
            var previousCheckTime = TimeSpan.Zero;
            timer.Start();
            while (IsRunning)
            {
                Application.DoEvents();

                // Update game logic
                Update(timer.GetTime());

                // Update game time
                timer.Update();

                // Render frame
                MainWindow.Refresh();

#if DEBUG
                // Update FPS counter
                if (timer.TotalTime - previousCheckTime > TimeSpan.FromMilliseconds(1000))
                {
                    MainWindow.Text = $"FPS: {fps}";
                    previousCheckTime = timer.TotalTime;
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

            Log.Info("Game is exiting");

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