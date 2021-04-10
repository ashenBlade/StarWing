using System;
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
        private Thread MainLoopThread { get; set; }
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
            InitializeMainLoopThread();
        }

        private void InitializeMainLoopThread()
        {
            MainLoopThread = new Thread(o => MainLoop());
            MainLoopThread.IsBackground = true;
        }

        private void InitializeInputDevices()
        {
            _keyboard = new Keyboard(MainWindow);
            _mouse = new Mouse(MainWindow);
        }

        private void InitializeMainWindow()
        {
            MainWindow = new GameWindow();
            MainWindow.Size = new Size(820, 620);
            MainWindow.Paint += RenderFrame;
            MainWindow.HandleCreated += (sender, args) => MainLoopThread.Start();
            MainWindow.Disposed += (sender, args) => IsRunning = false;
        }

        public void Start()
        {
            OnLoad();

            IsRunning = true;

            // Run game window
            // Main loop will start to run after it created
            Application.Run(MainWindow);
        }


        private void MainLoop()
        {
            OnLoad();

            var gameTime = new GameTime();
            var fps = 0; // FPS Counter
            var previousCheckTime = gameTime.TotalTime;
            while (IsRunning)
            {
                // Update game time
                gameTime.Update();

                // Update game logic
                Update(gameTime);

                // Render frame
                var renderResult = MainWindow.BeginInvoke((MethodInvoker)(() => MainWindow.Refresh()));
                while (!renderResult.IsCompleted)
                { /* Wait */ }

                #if DEBUG

                // Update FPS counter
                if (gameTime.TotalTime - previousCheckTime > TimeSpan.FromMilliseconds(1000))
                {
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

            // End main game loop
            // MainLoopThread.Join();
        }

        protected virtual void OnExit()
        { }
        protected virtual void OnLoad()
        { }
        protected virtual void Update(IGameTime gameTime)
        { }
        protected virtual void Render(Graphics graphics)
        { }
    }
}