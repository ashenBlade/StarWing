namespace StarWing.Core.Interfaces
{
    public interface ILivable
    {
        int Health { get; }
        int MaxHealth { get; }
        void TakeDamage(uint damage);
        void Heal(uint points);
        void IncreaseMaxHealth(uint points);
        void DecreaseMaxHealth(uint points);
    }
}