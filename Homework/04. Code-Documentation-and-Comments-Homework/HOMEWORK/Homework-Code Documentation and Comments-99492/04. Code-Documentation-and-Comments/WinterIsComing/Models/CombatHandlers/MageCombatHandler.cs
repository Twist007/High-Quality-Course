namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    internal class MageCombatHandler : CombatHandler
    {
        private const int DefaultMageTargetCandidates = 3;

        private ISpell previousSpell;

        public MageCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var units = candidateTargets.OrderByDescending(u => u.HealthPoints).ThenBy(u => u.Name).ToList();
            var targets = new List<IUnit>();

            if (units.Any())
            {
                var targetCount = DefaultMageTargetCandidates;
                if (units.Count < DefaultMageTargetCandidates)
                {
                    targetCount = units.Count;
                }

                for (int i = 0; i < targetCount; i++)
                {
                    targets.Add(units[i]);
                }

                return targets;
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            Spell attack;

            if (this.previousSpell == null)
            {
                attack = new FireBreath();
                this.previousSpell = attack;

                if (this.Unit.EnergyPoints >= attack.EnergyCost)
                {
                    attack.Damage = this.Unit.AttackPoints;

                    this.Unit.EnergyPoints -= attack.EnergyCost;

                    return attack;
                }
            }
            else
            {
                if (this.previousSpell is FireBreath)
                {
                    attack = new Blizzard();

                    if (this.Unit.EnergyPoints >= attack.EnergyCost)
                    {
                        attack.Damage = this.Unit.AttackPoints * 2;

                        this.Unit.EnergyPoints -= attack.EnergyCost;
                        this.previousSpell = attack;

                        return attack;
                    }
                }
                else
                {
                    attack = new FireBreath();

                    if (this.Unit.EnergyPoints >= attack.EnergyCost)
                    {
                        attack.Damage = this.Unit.AttackPoints;

                        this.Unit.EnergyPoints -= attack.EnergyCost;
                        this.previousSpell = attack;

                        return attack;
                    }
                }
            }

            throw new NotEnoughEnergyException(
                string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, attack.GetType().Name));
        }
    }
}