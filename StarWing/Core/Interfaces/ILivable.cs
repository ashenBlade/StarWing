using System;

namespace StarWing.Core.Interfaces
{

    public interface ILivable
    {
        int Health { get; set; }
        int MaxHealth { get; set; }
        event HealthChangedDelegate HealthChanged;
        event HealthChangedDelegate MaxHealthChanged;
        event LivableDiedDelegate Die;
        delegate void HealthChangedDelegate(ILivable livable, int delta);
        delegate void LivableDiedDelegate(ILivable livable);
    }
}