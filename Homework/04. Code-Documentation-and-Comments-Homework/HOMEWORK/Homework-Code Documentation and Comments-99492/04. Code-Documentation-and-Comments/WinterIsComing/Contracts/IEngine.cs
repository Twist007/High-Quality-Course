namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Game engine contains all logic for game.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Gets all units.
        /// </summary>
        IEnumerable<IUnit> Units { get; }

        /// <summary>
        /// Get all units in container.
        /// </summary>
        IUnitContainer UnitContainer { get; }

        /// <summary>
        /// Get output writer.
        /// </summary>
        IOutputWriter OutputWriter { get; }

        /// <summary>
        /// Gets special unit effects.
        /// </summary>
        IUnitEffector UnitEffector { get; }

        /// <summary>
        /// Start the engine.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the engine.
        /// </summary>
        void Stop();

        /// <summary>
        /// Insert given unit in the engine.
        /// </summary>
        /// <param name="unit"></param>
        void InsertUnit(IUnit unit);

        /// <summary>
        /// Remove given unit from the engine.
        /// </summary>
        /// <param name="unit"></param>
        void RemoveUnit(IUnit unit);
    }
}