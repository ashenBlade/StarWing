using System;

namespace StarWing.Framework
{
    public interface IGameTime
    {
        TimeSpan SinceLastUpdate { get; }
        TimeSpan TotalTime { get; }

    }
}