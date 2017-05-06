using RyRy.TicTacToe.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe
{
    public class ConsoleGame : Game
    {
        protected override void OnRenderBoard()
        {
            Console.Clear();
            /*
             -------
             | | | |
             -------
             | | | |
             -------
             | | | |
             -------
             */

            var totalWidth = (1) + (Grid.Width * 2);

            // Top line
            Console.WriteLine(String.Empty.PadRight(totalWidth, '-'));
            for (int y = 0; y < Grid.Height; y++)
            {
                for (int x = 0; x < Grid.Width; x++)
                {
                    Console.Write("|");

                    var cell = Grid[x, y];
                    if (cell.OccupiedBy != null)
                    {
                        Console.Write(cell.OccupiedBy.Symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine("|");
                Console.WriteLine(String.Empty.PadRight(totalWidth, '-'));
            }

        }

        protected override void OnDisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        protected override void OnWaitForUser()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        protected override string OnPrompt(string message)
        {
            Console.Write(message + ">");
            return Console.ReadLine();
        }
    }
}
