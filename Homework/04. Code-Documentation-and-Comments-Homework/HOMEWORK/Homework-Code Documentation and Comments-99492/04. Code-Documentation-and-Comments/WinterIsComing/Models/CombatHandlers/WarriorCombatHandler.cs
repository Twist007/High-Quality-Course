namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    internal class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var units = candidateTargets.OrderBy(u => u.HealthPoints).ThenBy(u => u.Name);
            var unit = units.FirstOrDefault();
            var target = new List<IUnit>();

            if (unit != null)
            {
                target.Add(unit);

                return target;
            }

            return target;
        }

        public override ISpell GenerateAttack()
        {
            var attack = new Cleave();

            if (this.Unit.EnergyPoints >= attack.EnergyCost)
            {
                if (this.Unit.HealthPoints <= 80)
                {
                    attack.Damage = this.Unit.AttackPoints + (this.Unit.HealthPoints * 2);
                }
                else
                {
                    attack.Damage = this.Unit.AttackPoints;
                }

                if (this.Unit.HealthPoints > 50)
                {
                    this.Unit.EnergyPoints -= attack.EnergyCost;
                }

                return attack;
            }

            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, attack));
        }
    }
}