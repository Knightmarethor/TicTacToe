using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    public class Cell
    {
        public readonly static Cell Empty = new EmptyCell();
        public Grid Grid { get; private set; }
        public Int32 X { get; private set; }
        public Int32 Y { get; private set; }

        /// <summary>
        /// Gets or Sets the Player that has claimed this Cell
        /// </summary>
        public virtual Player OccupiedBy { get; set; }



        public Cell CellAdjacentLeft
        {
            get
            {
                return Grid[X - 1, Y];
            }
        }

        public Cell CellAdjacentRight
        {
            get
            {
                return Grid[X + 1, Y];
            }
        }

        public Cell CellAbove
        {
            get
            {
                return Grid[X, Y - 1];
            }

        }

        public Cell CellBelow
        {
            get
            {
                return Grid[X, Y + 1];
            }
        }

        public Cell CellUpAndLeft
        {
            get
            {
                return Grid[X - 1, Y - 1];
            }
        }

        public Cell CellUpAndRight
        {
            get
            {
                return Grid[X + 1, Y - 1];
            }
        }

        public Cell CellDownAndLeft
        {
            get
            {
                return Grid[X - 1, Y + 1];
            }
        }

        public Cell CellDownAndRight
        {
            get
            {
                return Grid[X + 1, Y + 1];
            }
        }



        public Cell(Grid grid, Int32 x, Int32 y)
        {
            Grid = grid;
            X = x;
            Y = y;
            OccupiedBy = Player.None;
        }


        public Boolean IsInWinningLine(Player proposedPlayer)
        {
            if (proposedPlayer == Player.None)
                return false;


            // XX?
            if (CellAdjacentLeft.OccupiedBy == proposedPlayer && CellAdjacentLeft.CellAdjacentLeft.OccupiedBy == proposedPlayer)
                return true;

            // X?X
            if (CellAdjacentLeft.OccupiedBy == proposedPlayer && CellAdjacentRight.OccupiedBy == proposedPlayer)
                return true;



            // ?XX
            if (CellAdjacentRight.OccupiedBy == proposedPlayer && CellAdjacentRight.CellAdjacentRight.OccupiedBy == proposedPlayer)
                return true;

            //?
            //X
            //X
            if (CellBelow.OccupiedBy == proposedPlayer && CellBelow.CellBelow.OccupiedBy == proposedPlayer)
                return true;
            //X
            //?
            //X
            if (CellBelow.OccupiedBy == proposedPlayer && CellAbove.OccupiedBy == proposedPlayer)
                return true;

            //X
            //X
            //?
            if (CellAbove.OccupiedBy == proposedPlayer && CellAbove.CellAbove.OccupiedBy == proposedPlayer)
                return true;


            //? - -
            //- X -
            //- - X
            if (CellDownAndRight.OccupiedBy == proposedPlayer && CellDownAndRight.CellDownAndRight.OccupiedBy == proposedPlayer)
                return true;

            //X - -
            //- ? -
            //- - X
            if (CellUpAndLeft.OccupiedBy == proposedPlayer && CellDownAndRight.OccupiedBy == proposedPlayer)
                return true;

            //X - -
            //- X -
            //- - ?
            if (CellUpAndLeft.OccupiedBy == proposedPlayer && CellUpAndLeft.CellUpAndLeft.OccupiedBy == proposedPlayer)
                return true;

            //- - X
            //- X -
            //? - -
            if (CellUpAndRight.OccupiedBy == proposedPlayer && CellUpAndRight.CellUpAndRight.OccupiedBy == proposedPlayer)
                return true;

            //- - X
            //- ? -
            //X - -
            if (CellDownAndLeft.OccupiedBy == proposedPlayer && CellUpAndRight.OccupiedBy == proposedPlayer)
                return true;

            //- - ?
            //- X -
            //X - -
            if (CellDownAndLeft.OccupiedBy == proposedPlayer && CellDownAndLeft.CellDownAndLeft.OccupiedBy == proposedPlayer)
                return true;


            return false;



        }
        public override string ToString()
        {
            return String.Format("{0},{1} {2}",X,Y,OccupiedBy);
        }
    }
}
