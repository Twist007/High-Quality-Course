namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;

    using WinterIsComing.Contracts;

    public abstract class CombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();
    }
}