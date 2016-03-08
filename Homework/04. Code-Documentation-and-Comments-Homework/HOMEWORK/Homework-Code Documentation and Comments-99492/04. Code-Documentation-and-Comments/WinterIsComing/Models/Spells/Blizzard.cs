namespace WinterIsComing.Models.Spells
{
    internal class Blizzard : Spell
    {
        private const int DefaultEnergyCost = 40;

        public Blizzard()
            : base(DefaultEnergyCost)
        {
        }
    }
}