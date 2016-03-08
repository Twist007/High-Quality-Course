namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Combat handler for battles.
    /// </summary>
    public interface ICombatHandler
    {
        /// <summary>
        /// Gets or sets the unit for that has to be handled.
        /// </summary>
        IUnit Unit { get; set; }

        /// <summary>
        /// Gets all targets based on its type.
        /// </summary>
        /// <param name="candidateTargets">IEnumerable of IUnits contains all possible targets</param>
        /// <returns>IEnumerable of IUnits with all targets</returns>
        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);
        
        /// <summary>
        /// Makes the appropriate attack depending on the unit.
        /// </summary>
        /// <returns>Generated Spell</returns>
        ISpell GenerateAttack();
    }
}
