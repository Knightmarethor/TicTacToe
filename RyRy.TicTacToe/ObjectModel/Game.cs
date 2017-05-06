using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    /// <summary>
    /// A game of tic tac toe
    /// </summary>
    public abstract class Game
    {

        private Int32 _aiPlayerCount = 0;
        public Grid Grid { get; private set; }

        public Int32 LengthToWin { get; private set; }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }



        public void StartNewGame(Int32 width, Int32 height, Int32 lengthToWin)
        {
            DisplayMessage("TicTacToe");
            DisplayMessage("Starting new game...");
            LengthToWin = lengthToWin;
            Grid = new Grid(width, height);

            DisplayMessage("Game Started");


            var p1Name = Prompt("Player 1 - Enter your name or provide 'ai' for a computer player...");
            Player1 = CreatePlayer(p1Name);
            Player1.Symbol = 'X';

            var p2Name = Prompt("Player 2 - Enter your name or provide 'ai' for a computer player...");
            Player2 = CreatePlayer(p2Name);
            Player2.Symbol = 'O';

            DisplayMessage("The Game is ready to begin");
            WaitForUser();

            Player currentPlayer = Player1;

            while (!(Player1.HasWon || Player2.HasWon) && Grid.HasEmptyCells)
            {
                RenderBoard();

                currentPlayer.MakeMove();

                RenderBoard();

                if (currentPlayer == Player1)
                {
                    currentPlayer = Player2;
                }
                else
                {
                    currentPlayer = Player1;
                }
            }
            var winningPlayer = Player.None;

            if (Player1.HasWon)
                winningPlayer = Player1;

            if (Player2.HasWon)
                winningPlayer = Player2;

            if (winningPlayer == Player.None)
            {
                DisplayMessage("Neither player won...");
            }

            else
            {
                DisplayMessage(String.Format("Congratulations {0}, You have won!", winningPlayer));
            }
        }


        private Player CreatePlayer(String name)
        {
            if (name.ToLower() == "ai")
            {
                _aiPlayerCount++;
                return new AiPlayer(this, String.Format("Ai Player {0}",_aiPlayerCount));
            }
            return new HumanPlayer(this, name);
        }


        public void RenderBoard()
        {
            OnRenderBoard();
        }

        public void DisplayMessage(String message)
        {
            OnDisplayMessage(message);
        }

        public void WaitForUser()
        {
            OnWaitForUser();
        }

        public String Prompt(String message)
        {
            return OnPrompt(message);
        }


        protected abstract void OnRenderBoard();
        protected abstract void OnDisplayMessage(String message);
        protected abstract void OnWaitForUser();
        protected abstract String OnPrompt(String message);



        /// <summary>
        /// Returns whether a given move is valid
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Boolean CheckIfMoveIsValid(Player player, Int32 x, Int32 y, out String error)
        {
            // Check it's actually on the grid...
            if (x < 0 || x >= Grid.Width)
            {
                error = "X value was out of range";
                return false;
            }

            if (y < 0 || y >= Grid.Height)
            {
                error = "Y value was out of range";
                return false;
            }


            // Check it's not occupied
            var proposedCell = Grid[x, y];
            if (proposedCell.OccupiedBy != Player.None)
            {
                error = "That cell is already occupied";
                return false;
            }


            // Looks ok!
            error = String.Empty;
            return true;
        }


        /// <summary>
        /// Performs a move
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MakeMove(Player player, Int32 x, Int32 y)
        {
            // ToDo: Check the target cell!
            Grid[x, y].OccupiedBy = player;
        }

    }
}
