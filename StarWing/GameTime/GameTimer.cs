using System;
using System.Diagnostics;

namespace StarWing.Framework
{
    public class GameTimer
    {
        private readonly Stopwatch _elapsedTime;
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

        public IGameTime GetTime() =>
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