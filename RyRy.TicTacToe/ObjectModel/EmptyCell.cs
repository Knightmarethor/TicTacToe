using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    internal class EmptyCell : Cell
    {
        public EmptyCell()
            :base(null,-1,-1)
        {
            
        } 
        public override Player OccupiedBy
        {
            get
            {
                return Player.None;
            }
            
        }
    }
}
