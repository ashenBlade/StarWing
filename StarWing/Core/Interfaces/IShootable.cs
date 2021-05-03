using System;

namespace StarWing.Core.Interfaces
{
    public interface IShootable
    {
        TimeSpan CoolDown { get; }
        void Shoot();
        void IncreaseCoolDownTime(uint delta);
        void DecreaseCoolDownTime(uint delta);
    }
}