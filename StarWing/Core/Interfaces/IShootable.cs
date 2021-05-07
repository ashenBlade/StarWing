using System;

namespace StarWing.Core.Interfaces
{
    public interface IShootable
    {
        int Damage { get; set; }
        TimeSpan CoolDown { get; set; }
        TimeSpan MaxCoolDown { get; set; }
        void Shoot();
    }
}