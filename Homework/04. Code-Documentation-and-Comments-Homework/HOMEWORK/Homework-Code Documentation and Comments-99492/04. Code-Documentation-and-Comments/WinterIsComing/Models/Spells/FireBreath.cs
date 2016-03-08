namespace WinterIsComing.Models.Spells
{
    internal class FireBreath : Spell
    {
        private const int DefaultEnergyCost = 30;

        public FireBreath()
            : base(DefaultEnergyCost)
        {
        }
    }
}