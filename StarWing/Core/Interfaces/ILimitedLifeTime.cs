using System;

namespace StarWing.Core.Interfaces
{
    public interface ILimitedLifeTime
    {
        TimeSpan LifeTime { get; }
    }
}