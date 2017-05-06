using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    public class AiPlayer : Player
    {

        public AiPlayer(Game game, String name)
            : base(game, name)
        {

        }

        protected override void OnMakeMove()
        {
            base.OnMakeMove();
            Thread.Sleep(500);
            var otherPlayer = Game.Player1;

            if (otherPlayer == this)
                otherPlayer = Game.Player2;

            List<CellWeighting> possibleMoves = new List<CellWeighting>();

            // Weight each cell
            foreach (var cell in Game.Grid.Cells)
            {
                if (cell.OccupiedBy != Player.None)
                    continue;


                // Work out a weighting
                var weighting = new CellWeighting()
                {
                    Cell = cell,
                    Weighting = 0
                };


                // If it's in the middle of the board (kinda), +1
                var wiggleRoomX = Convert.ToInt32(Game.Grid.Width * 0.1);
                var isInMiddleX = false;

                var wiggleRoomY = Convert.ToInt32(Game.Grid.Height * 0.1);
                var isInMiddleY = false;

                if (((Game.Grid.Width - 1) / 2) - wiggleRoomX > cell.X
                    && ((Game.Grid.Width - 1) / 2) + wiggleRoomX < cell.X)
                {
                    isInMiddleX = true;
                }

                if (((Game.Grid.Height - 1) / 2) - wiggleRoomY > cell.Y
                    && ((Game.Grid.Height - 1) / 2) + wiggleRoomY < cell.Y)
                {
                    isInMiddleY = true;
                }

                if (isInMiddleX && isInMiddleY)
                {
                    weighting.Weighting += 1;
                }



                // Is the cell a winning move?
                
                // ---
                // XX?
                // ---


                    
                // Is putting my symbol here going to complete a line of length winningLength?
                
                // XX?
                var willCompleteLineAndWin = cell.IsInWinningLine(this);

                if (willCompleteLineAndWin)
                    weighting.Weighting += 300;           

                 //Will it block an opponent?
                 //Use the same equation!
                if (cell.IsInWinningLine(otherPlayer))
                {
                    weighting.Weighting += 100;
                }

                possibleMoves.Add(weighting);
            }


            // Get the hishest weighting of all possible moves

            var highestWeighting = possibleMoves.Max(p => p.Weighting);


            // Get all the moves which share this highest rating
            var selectedMoves = possibleMoves.Where(p => p.Weighting == highestWeighting);

            Random r = new Random();

            // Select a random move from the equally rated moves
            var actualMoveToMake = selectedMoves
                .Skip(r.Next(0, selectedMoves.Count() - 1))
                .First();
            

            // make the move!
            Game.MakeMove(this, actualMoveToMake.Cell.X, actualMoveToMake.Cell.Y);
            
        }
    }
}
