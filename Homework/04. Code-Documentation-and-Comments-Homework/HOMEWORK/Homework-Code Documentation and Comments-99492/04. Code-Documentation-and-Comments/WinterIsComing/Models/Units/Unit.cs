namespace WinterIsComing.Models.Units
{
    using System;
    using System.Text;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;

    public abstract class Unit : IUnit
    {
        private const int DefaultWorldSize = 4;

        private string name;
        private int x;
        private int y;

        protected Unit(
            int x, 
            int y, 
            string name, 
            int range, 
            int attackPoints, 
            int healthPoints, 
            int defencePoints, 
            int energyPoints)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defencePoints;
            this.EnergyPoints = energyPoints;
        }
        
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0 || value > DefaultWorldSize)
                {
                    throw new InvalidPositionException(GlobalMessages.InvalidPosition);
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0 || value > DefaultWorldSize)
                {
                    throw new InvalidPositionException(GlobalMessages.InvalidPosition);
                }

                this.y = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new GameException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Range { get; set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            if (this.HealthPoints > 0)
            {
                output.AppendLine(string.Format(
                    ">{0} - {1} at ({2},{3})",
                    this.Name,
                    this.GetType().Name,
                    this.X,
                    this.Y));
                output.AppendLine(string.Format("-Health points = {0}", this.HealthPoints));
                output.AppendLine(string.Format("-Attack points = {0}", this.AttackPoints));
                output.AppendLine(string.Format("-Defense points = {0}", this.DefensePoints));
                output.AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints));
                output.Append(string.Format("-Range = {0}", this.Range));
            }
            else
            {
                output.Append(string.Format(
                    ">{0} - {1} at ({2},{3}){4}(Dead)",
                    this.Name,
                    this.GetType().Name,
                    this.X,
                    this.Y,
                    Environment.NewLine));
            }

            return output.ToString();
        }
    }
}