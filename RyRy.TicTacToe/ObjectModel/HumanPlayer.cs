using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe.ObjectModel
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(Game game, String name)
            : base(game, name)
        {

        }

        protected override void OnMakeMove()
        {
            Game.DisplayMessage(String.Format("{0}, it's your turn!", Name));

            Int32 proposedX = 0;
            Int32 proposedY = 0;

            var inputWasInvalid = true;
            while (inputWasInvalid)
            {

                var coordRaw = Game.Prompt("Enter your co-ordinate as x y:");

                var rawParts = coordRaw.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                // Make sure the input is valid
                if (rawParts.Length != 2)
                {
                    Game.DisplayMessage("Invalid format");
                    continue;
                }


                
                if (!Int32.TryParse(rawParts[0], out proposedX))
                {
                    Game.DisplayMessage("Invalid X value");
                    continue;
                }

                if (!Int32.TryParse(rawParts[1], out proposedY))
                {
                    Game.DisplayMessage("Invalid Y value");
                    continue;
                }

                String validationError = String.Empty;
                if (!Game.CheckIfMoveIsValid(this, proposedX, proposedY, out validationError))
                {
                    // Invalid move
                    Game.DisplayMessage(validationError);
                    continue;
                }

                inputWasInvalid = false;
            }

            // Make the move
            Game.MakeMove(this, proposedX, proposedY);




        }
    }
}
