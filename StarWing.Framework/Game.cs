using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using StarWing.Framework.Input;

namespace StarWing.Framework
{
    public abstract class Game : IDisposable
    {
        public IContentManager ContentManager { get; private set; }
        public bool IsRunning { get; private set; }
        public GameWindow GameWindow { get; private set; }
        protected IKeyboard Keyboard { get; private set; }
        protected IMouse Mouse { get; private set; }

        protected Game()
        {
            InitializeGameWindow();
            InitializeInputDevices();
            InitializeContentManager();

#if DEBUG
            Log.RegisterOutput(Console.Out);
#endif
        }

        private void InitializeContentManager()
        {
            ContentManager = new ContentManager();
        }

        private void InitializeGameWindow()
        {
            GameWindow = new GameWindow();
            GameWindow.Size = new Size(1280, 720);
            GameWindow.Shown += (sender, args) => Start();
            GameWindow.Paint += (sender, args) => RenderFrame(args);
            GameWindow.Closed += (sender, args) => Exit();
        }

        private void InitializeInputDevices()
        {
            Keyboard = new Keyboard(GameWindow);
            Mouse = new Mouse(GameWindow);
        }

        public void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.Run(GameWindow);
        }

        private void Start()
        {
            Log.Info("Game is starting");

            OnLoad();

            IsRunning = true;

            OnStarting();
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
                // Continue receiving messages
                Application.DoEvents();

                // Update game logic
                Update(timer.GetTime());

                // Update game time
                timer.Update();

                // Render frame
                GameWindow.Refresh();

#if DEBUG
                // Update FPS counter
                if (timer.TotalTime - previousCheckTime > TimeSpan.FromMilliseconds(1000))
                {
                    GameWindow.Text = $"FPS: {fps}";
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
            e.Graphics.Clear(Color.Transparent);
            Render(e.Graphics);
        }


        public void Exit()
        {
            OnExit();
            IsRunning = false;
            Log.Info("Game is exiting");
            Application.Exit();
        }


        protected virtual void ContentLoad()
        { }
        protected virtual void ContentUnload()
        { }
        protected virtual void OnExit()
        { }
        protected virtual void OnLoad()
        { }
        protected virtual void Update(GameTime gameTime)
        { }
        protected virtual void Render(Graphics graphics)
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

        #region Events

        public event EventHandler<EventArgs> Starting;
        public event EventHandler<EventArgs> Exiting;

        #endregion

        public void Dispose()
        {

        }
    }
}