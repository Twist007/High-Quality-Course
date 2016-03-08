namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Game unit.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets horizontal position.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets vertical position.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Gets unit name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets unit range.
        /// </summary>
        int Range { get; }

        /// <summary>
        /// Gets or sets unit attack power.
        /// </summary>
        int AttackPoints { get; set; }

        /// <summary>
        /// Gets or sets unit health points.
        /// </summary>
        int HealthPoints { get; set; }

        /// <summary>
        /// Gets or sets unit defense points.
        /// </summary>
        int DefensePoints { get; set; }

        /// <summary>
        /// Gets or sets unit energy points.
        /// </summary>
        int EnergyPoints { get; set; }

        /// <summary>
        /// Gets unit combat handler.
        /// </summary>
        ICombatHandler CombatHandler { get; }
    }
}
