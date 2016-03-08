namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    internal class IceGiant : Unit
    {
        private const int DefaultIceGiantRange = 1;

        private const int DefaultIceGiantAttackPoints = 150;

        private const int DefaultIceGiantHealthPoints = 300;

        private const int DefaultIceGiantDefencePoints = 60;

        private const int DefaultIceGiantEnergyPoints = 50;

        public IceGiant(int x, int y, string name)
            : base(
                x, 
                y, 
                name, 
                DefaultIceGiantRange, 
                DefaultIceGiantAttackPoints, 
                DefaultIceGiantHealthPoints, 
                DefaultIceGiantDefencePoints, 
                DefaultIceGiantEnergyPoints)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}