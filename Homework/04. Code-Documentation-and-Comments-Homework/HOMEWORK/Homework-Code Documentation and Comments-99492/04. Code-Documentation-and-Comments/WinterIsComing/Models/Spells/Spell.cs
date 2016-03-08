namespace WinterIsComing.Models.Spells
{
    using WinterIsComing.Contracts;

    public abstract class Spell : ISpell
    {
        protected Spell(int energyCost)
        {
            this.EnergyCost = energyCost;
        }

        public int Damage { get; set; }

        public int EnergyCost { get; private set; }
    }
}