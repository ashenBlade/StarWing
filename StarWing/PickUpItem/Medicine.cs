namespace StarWing.PickUpItem
{
    public class Medicine : PowerUp
    {
        public int HealCount { get; set; }

        public override void Apply(Unit unit)
        {
            unit.Health += HealCount;
        }
    }
}