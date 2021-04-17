using System;

namespace StarWing.Framework
{
    public interface IGameComponent : IDisposable
    {
        void Initialize();
    }
}