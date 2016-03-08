namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    internal class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var units = candidateTargets.ToList();
            
            var targets = new List<IUnit>();

            if (units.Any())
            {
                if (this.Unit.HealthPoints <= 150)
                {
                    targets.Add(units.FirstOrDefault());
                }
                else
                {
                    targets.AddRange(units);
                }
                

                return targets;
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            var attack = new Stomp();

            if (this.Unit.EnergyPoints >= attack.EnergyCost)
            {
                attack.Damage = this.Unit.AttackPoints;

                this.Unit.EnergyPoints -= attack.EnergyCost;
                this.Unit.AttackPoints += 5;

                return attack;
            }

            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, attack));
        }
    }
}