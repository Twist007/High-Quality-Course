namespace WinterIsComing.Models.Spells
{
    internal class Stomp : Spell
    {
        private const int DefaultEnergyCost = 10;
        
        public Stomp()
            : base(DefaultEnergyCost)
        {
        }
    }
}