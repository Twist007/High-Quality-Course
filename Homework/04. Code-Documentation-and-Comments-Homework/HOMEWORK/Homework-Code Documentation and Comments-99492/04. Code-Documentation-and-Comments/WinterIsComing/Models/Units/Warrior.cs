namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    public class Warrior : Unit
    {
        private const int DefaultWarriorRange = 1;

        private const int DefaultWarriorAttackPoints = 120;

        private const int DefaultWarriorHealthPoints = 180;

        private const int DefaultWarriorDefencePoints = 70;

        private const int DefaultWarriorEnergyPoints = 60;

        public Warrior(int x, int y, string name)
            : base(
                x, 
                y, 
                name, 
                DefaultWarriorRange, 
                DefaultWarriorAttackPoints, 
                DefaultWarriorHealthPoints, 
                DefaultWarriorDefencePoints, 
                DefaultWarriorEnergyPoints)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}