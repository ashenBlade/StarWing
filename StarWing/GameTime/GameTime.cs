using System;
using System.Diagnostics; // FPS Counter time

namespace StarWing.Framework
{
    // TODO:
    public class GameTime : IGameTime
    {
        private Stopwatch _elapsedTime;
        private Stopwatch _totalTime;
        public TimeSpan SinceLastUpdate =>
            _elapsedTime.Elapsed;

        public TimeSpan TotalTime =>
            _totalTime.Elapsed;

        public GameTime()
        {
            _elapsedTime = new Stopwatch();
            _elapsedTime.Start();

            _totalTime = new Stopwatch();
            _totalTime.Start();
        }

        public void Update()
        {
            _elapsedTime.Restart();
        }

        public void Reset()
        {
            _elapsedTime.Reset();
            _totalTime.Reset();
        }

        public void Restart()
        {
            _elapsedTime.Restart();
            _totalTime.Restart();
        }
    }
}