using System;

namespace Application2
{
    public class Raiting
    {
        private string name;
        private int points;
        
        public Raiting(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
        public Raiting()
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Points cannot be negative.");
                }
                this.points = value;
            }
        }


    }
}

