using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using StarWing.Framework.Input;

namespace StarWing.Framework
{
    public abstract class Game
    {
        protected bool IsRunning { get; private set; }

        protected IGameWindow GameWindow =>
            _gameWindow;
        private Window _gameWindow { get; set; }
        protected IKeyboard Keyboard { get; private set; }
        protected IMouse Mouse { get; private set; }

        public event EventHandler<EventArgs> Starting;
        public event EventHandler<EventArgs> Exiting;

        protected Game()
        {
            InitializeGameWindow();
            InitializeInputDevices();

#if DEBUG
            Log.RegisterOutput(Console.Out);
#endif
        }

        private void InitializeGameWindow()
        {
            _gameWindow = new Window();
            _gameWindow.Size = new Size(1280, 720);
            _gameWindow.Shown += (sender, args) => Start();
            _gameWindow.Paint += (sender, args) => RenderFrame(args);
            _gameWindow.Closed += (sender, args) => Exit();
        }

        private void InitializeInputDevices()
        {
            Keyboard = new Keyboard(_gameWindow);
            Mouse = new Mouse(_gameWindow, _gameWindow);
        }

        public void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.Run(_gameWindow);
        }

        private void Start()
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
                _gameWindow.Refresh();

#if DEBUG
                // Update FPS counter
                if (timer.TotalTime - previousCheckTime > TimeSpan.FromMilliseconds(1000))
                {
                    _gameWindow.Text = $"FPS: {fps}";
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

        private void RenderFrame(PaintEventArgs e)
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
        private void OnUnhandledException (object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error("Something went wrong", new Exception(e.ToString()));
        }
        protected virtual void OnStarting()
        {
            Starting?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnExiting()
        {
            Exiting?.Invoke(this, EventArgs.Empty);
        }
    }
}