using System;

namespace StarWing.Framework
{
    public class GameTime : IGameTime
    {
        public TimeSpan SinceLastUpdate { get; }
        public TimeSpan TotalTime { get; }

        public GameTime()
        {
            SinceLastUpdate = TimeSpan.Zero;
            TotalTime = TimeSpan.Zero;
        }

        public GameTime(TimeSpan sinceLastUpdate, TimeSpan totalTime)
        {
            SinceLastUpdate = sinceLastUpdate;
            TotalTime = totalTime;
        }
    }
}