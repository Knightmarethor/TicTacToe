using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    public class Grid
    {

        public Int32 Width { get; private set; }
        public Int32 Height { get; private set; }

        /// <summary>
        /// Gets the Cells on the Grid
        /// </summary>
        public Cell[] Cells { get; private set; }


        public Cell this[Int32 x, Int32 y]
        {
            get
            {
                return Cells.FirstOrDefault(c => c.X == x && c.Y == y) ?? Cell.Empty;
            }
        }



        public Grid(Int32 width, Int32 height)
        {        
            Width = width;
            Height = height;
            Cells = new Cell[width * height];
            Int32 i = 0;
            


            for (Int32 y = 0; y < height; y++)
            {
                for (Int32 x = 0; x < width; x++)
                {
                    Cells[i] = new Cell(this, x, y);
                    i++;
                }
            }



        }

        /// <summary>
        /// Gets whether there are any empty cells on this grid
        /// </summary>
        public Boolean HasEmptyCells {
            get
            {
                return Cells.Count(c => c.OccupiedBy == Player.None) > 0;
                
            }
            
        }
    }
}
