namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Unit container.
    /// </summary>
    public interface IUnitContainer
    {
        /// <summary>
        /// Gets all units in giver range.
        /// </summary>
        /// <param name="x">Starting horizontal point</param>
        /// <param name="y">Starting vertical point</param>
        /// <param name="range">Given range</param>
        /// <returns>IEnumerable of IUnits</returns>
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        /// <summary>
        /// Add unit to the container.
        /// </summary>
        /// <param name="unit">Given unit</param>
        void Add(IUnit unit);

        /// <summary>
        /// Remove unit from container.
        /// </summary>
        /// <param name="unit">Given unit</param>
        void Remove(IUnit unit);

        /// <summary>
        /// Move given unit from one position to another.
        /// </summary>
        /// <param name="unit">Given unit.</param>
        /// <param name="newX">New horizontal position</param>
        /// <param name="newY">New vertical position</param>
        void Move(IUnit unit, int newX, int newY);
    }
}
