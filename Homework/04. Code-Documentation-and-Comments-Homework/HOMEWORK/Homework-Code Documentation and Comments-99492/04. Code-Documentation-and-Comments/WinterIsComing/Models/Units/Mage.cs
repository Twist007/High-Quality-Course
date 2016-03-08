namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    internal class Mage : Unit
    {
        private const int DefaultMageRange = 2;

        private const int DefaultMageAttackPoints = 80;

        private const int DefaultMageHealthPoints = 80;

        private const int DefaultMageDefencePoints = 40;

        private const int DefaultMageEnergyPoints = 120;

        public Mage(int x, int y, string name)
            : base(
                x, 
                y, 
                name, 
                DefaultMageRange, 
                DefaultMageAttackPoints, 
                DefaultMageHealthPoints, 
                DefaultMageDefencePoints, 
                DefaultMageEnergyPoints)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}