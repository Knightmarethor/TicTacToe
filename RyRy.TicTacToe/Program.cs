using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyRy.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            var boardWidth = 3;
            var boardHeight = 3;
            var lengthToWin = 3;

            Int32.TryParse(ConfigurationManager.AppSettings["boardWidth"], out boardWidth);
            Int32.TryParse(ConfigurationManager.AppSettings["boardHeight"], out boardHeight);
            Int32.TryParse(ConfigurationManager.AppSettings["lengthToWin"], out lengthToWin);

            var game = new ConsoleGame();
            game.StartNewGame(boardWidth, boardHeight, lengthToWin);
            Console.WriteLine();
            Console.WriteLine("Press Anykey To Exit...");
            Console.ReadKey();
        }
    }
}
