using System;
using System.Diagnostics; // FPS Counter time

namespace StarWing.Framework
{
    public class GameTimer
    {
        private Stopwatch _elapsedTime;
        private TimeSpan _totalTime;
        public TimeSpan SinceLastUpdate =>
            _elapsedTime.Elapsed;

        public TimeSpan TotalTime =>
            _elapsedTime.Elapsed + _totalTime;

        public GameTimer()
        {
            _elapsedTime = new Stopwatch();
            _totalTime = TimeSpan.Zero;
        }

        public GameTime GetTime() =>
            new GameTime(SinceLastUpdate, TotalTime);

        public void Start()
        {
            _elapsedTime.Start();
        }

        public void Update()
        {
            _totalTime += _elapsedTime.Elapsed;
            _elapsedTime.Restart();
        }

        public void Reset()
        {
            _elapsedTime.Reset();
            _totalTime = TimeSpan.Zero;
        }

        public void Restart()
        {
            _elapsedTime.Restart();
            _totalTime = TimeSpan.Zero;
        }
    }
}