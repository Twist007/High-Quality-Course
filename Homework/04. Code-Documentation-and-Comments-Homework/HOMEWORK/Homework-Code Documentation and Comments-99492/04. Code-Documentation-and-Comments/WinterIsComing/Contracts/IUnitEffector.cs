namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Handle with special effect in game
    /// </summary>
    public interface IUnitEffector
    {
        /// <summary>
        /// Apply effect to given units.
        /// </summary>
        /// <param name="units">IEnumerable of units</param>
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
