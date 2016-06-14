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
            int numOfPlayers = GameManager.ChooseNumOf("Players", 1, 2);
            int numOfRows = GameManager.ChooseNumOf("Rows", 4, 8);
            int numOfColumns = GameManager.ChooseNumOf("Columns", 4, 8);
            GameManager NewGame = GameManager.StartNewGame(numOfRows, numOfColumns, numOfPlayers);
            NewGame.PlayGame();
            Console.ReadLine();
        }
    }
}
