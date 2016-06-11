using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello!\nLet's play 4 in a row!");
            int numOfPlayers = GameMenager.ChooseNumOf("Players", 1, 2);
            int numOfRows = GameMenager.ChooseNumOf("Rows", 4, 8);
            int numOfColumns = GameMenager.ChooseNumOf("Columns", 4, 8);
            GameMenager NewGame = GameMenager.StartNewGame(numOfRows, numOfColumns, numOfPlayers);
            NewGame.PlayGame();
            Console.ReadLine();
        }
    }
}
