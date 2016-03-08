using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinesweeperGame
{
    public class Player
    {
        private string name;

        public Player()
        {
        }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public int Points { get; set; }

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
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }
    }
}
