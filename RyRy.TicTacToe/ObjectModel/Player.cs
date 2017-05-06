using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    public class Player
    {
        public static readonly Player None = new Player(null, "None");

        public Game Game { get; private set; }
        public String Name { get; private set; }
        public Char Symbol { get; set; }



        public Player(Game game, String name)
        {
            Game = game;
            Name = name;
        }

        /// <summary>
        /// Checks if the Player has won
        /// </summary>
        public Boolean HasWon
        {
            get
            {
                foreach (var cell in Game.Grid.Cells.Where(c => c.OccupiedBy == this))
                {
                    if (cell.IsInWinningLine(this))
                        return true;
                }
                // Are there n cells occupied by this user in a horizontal, vertical or diagonal line?
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        public void MakeMove()
        {
            OnMakeMove();
        }


        protected virtual void OnMakeMove()
        {
            // Override me!
        }
    }
}
