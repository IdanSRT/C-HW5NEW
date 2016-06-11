using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B16_Ex02_Idan_201580990_Sagi_305746588;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public enum eGameStatus
    {
        Play,
        Win,
        Draw
    }
    public class GameMenager
    {
        private Board m_GameBoard;
        private int m_RowRange;
        private int m_ColumnRange;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsEnded;

        // Constractor for two players
        public GameMenager(Board i_GameBoard, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_GameBoard = i_GameBoard;
            m_FirstPlayer = new Player(i_FirstPlayerName, false, (eSign) 0);
            m_SecondPlayer = new Player(i_SecondPlayerName, false, (eSign) 1);
            m_RowRange = m_GameBoard.Rows;
            m_ColumnRange = m_GameBoard.Columns;
            m_IsEnded = false;
        }

        // Constractor for one player
        public GameMenager(Board i_GameBoard, string i_FirstPlayerName)
            : this(i_GameBoard, i_FirstPlayerName, "Computer")
        {
        }
        
        // Board getter and setter
        public Board GameBoard
        {
            get { return m_GameBoard; }            
            set { m_GameBoard = value; }
        }

        // Start a new game
        public static GameMenager StartNewGame(int i_Rows, int i_Columns, int i_NumOfPlayers) 
        {
            Board GameBoard = new Board(i_Rows, i_Columns);
            GameMenager GameManager; 
            if (i_NumOfPlayers == 1)
            {
                GameManager = new GameMenager(GameBoard, "Player 1");
                GameManager.m_SecondPlayer.IsPC = true;
            }
            else
            {
                GameManager = new GameMenager(GameBoard, "Player 1", "Player 2");
            }

            return GameManager;
        }

        public void ContinueNewGame()
        {
            this.m_GameBoard = new Board(this.m_GameBoard.Rows, this.m_GameBoard.Columns);
            this.IsEnded = false;
            Ex02.ConsoleUtils.Screen.Clear();
            PlayGame();
        }

        // Helper to read from the user the number of Players/Rows/Columns
        public static int ChooseNumOf(string numToChoose, int startRange, int endRange)
        {
            System.Console.WriteLine("Please choose the number of " + numToChoose + ", between the range " + startRange + " to " + endRange + " (and then press 'enter'):");
            string inputNumStr = Console.ReadLine();
            int inputNumInt;
            bool goodInput = int.TryParse(inputNumStr, out inputNumInt);
            while (!goodInput || inputNumInt < startRange || inputNumInt > endRange)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a number between the range " + startRange + " to " + endRange + ":");
                inputNumStr = Console.ReadLine();
                goodInput = int.TryParse(inputNumStr, out inputNumInt);
            }

            return inputNumInt;
        }

        // Check if a chosen column is in range
        public bool IsInRange(int i_ChosenColumn)
        {
            bool isInRange = false;
            if (i_ChosenColumn <= this.m_ColumnRange && i_ChosenColumn > 0){
                isInRange = true;
            }
            else
            {
                isInRange = false;
            }

            return isInRange;
        }

        // IsEnded get and set
        public bool IsEnded
        {
            get { return m_IsEnded; }
            set { m_IsEnded = value; }
        }

        // Adding the coin of the current player to the chosen column
        public Coin AddCoinToBoard(int i_ColumnChoosen, Player i_CurrentPlayer)
        {
            Coin lastCoinInserted = m_GameBoard.InsertCoin(i_ColumnChoosen - 1, i_CurrentPlayer);
            Ex02.ConsoleUtils.Screen.Clear();
            m_GameBoard.PrintBoard();
            return lastCoinInserted;
        }

        // Checks the game status
        public eGameStatus CheckGameStatus(Coin lastCoinInserted)
        {
            eGameStatus gameStatus;
            if (m_GameBoard.IsBingo(lastCoinInserted))
            {
                gameStatus = eGameStatus.Win;
            }
            else if (m_GameBoard.IsBoardFull()){
                gameStatus = eGameStatus.Draw;
            }
            else
            {
                gameStatus = eGameStatus.Play;
            }
            return gameStatus;
        }


        // Play the Game
        public void PlayGame()
        {
            Player currentPlayer = m_FirstPlayer;
            Ex02.ConsoleUtils.Screen.Clear();
            m_GameBoard.PrintBoard();
            eGameStatus gameStatus = eGameStatus.Play;

            while (this.IsEnded == false)
            {
                string columnChooseStr;
                int columnChooseInt;
                bool goodInput;
                Console.WriteLine("Press 'Q' to quit\nPlayer " + currentPlayer.Name + ", Please choose column:");

                if (currentPlayer.IsPC == false)
                {
                    columnChooseStr = Console.ReadLine();
                    if (columnChooseStr == "Q"){
                        currentPlayer = SwitchPlayer(currentPlayer);
                        gameStatus = eGameStatus.Win;
                        break;
                    }
                    goodInput = int.TryParse(columnChooseStr, out columnChooseInt);
                }
                else
                {
                    columnChooseInt = currentPlayer.PcBlock(this.GameBoard , m_SecondPlayer.m_LastMove, m_SecondPlayer.m_OlderMove);
                    goodInput = true;
                    Console.WriteLine(columnChooseInt);
                }
                
                while (!goodInput || !IsInRange(columnChooseInt) || m_GameBoard.IsColumnFull(columnChooseInt - 1))
                {
                    if (IsInRange(columnChooseInt))
                    {
                        if (m_GameBoard.IsColumnFull(columnChooseInt - 1))
                        {
                            Console.WriteLine("Column " + columnChooseInt + " is full.\nPlease choose a different column:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is not valid. \nPlease choose a column:");
                    }

                    if (currentPlayer.IsPC == false)
                    {
                        columnChooseStr = Console.ReadLine();
                        if (columnChooseStr == "Q"){
                           currentPlayer = SwitchPlayer(currentPlayer);
                            gameStatus = eGameStatus.Win;
                            goto Outer;
                        }
                        goodInput = int.TryParse(columnChooseStr, out columnChooseInt);
                    }
                    else
                    {
                        columnChooseInt = currentPlayer.PcBlock(this.GameBoard, m_SecondPlayer.m_LastMove, m_SecondPlayer.m_OlderMove);
                        goodInput = true;
                        Console.WriteLine(columnChooseInt);
                    }
                }
                if (currentPlayer.IsPC == false)
                {
                    m_SecondPlayer.m_OlderMove = m_SecondPlayer.m_LastMove;
                    m_SecondPlayer.m_LastMove = columnChooseInt;
                }
                Coin lastCoinInserted = AddCoinToBoard(columnChooseInt, currentPlayer);
                gameStatus = CheckGameStatus(lastCoinInserted);
            Outer:
                if (gameStatus == eGameStatus.Play)
                {
                    // Switching the players
                    currentPlayer = SwitchPlayer(currentPlayer);
                    continue;
                }
                else 
                {
                    this.IsEnded = true;
                    break;
                }
            }

            switch(gameStatus)
            {
                case eGameStatus.Win:
                        Console.WriteLine("Congratulations!\nPlayer " + currentPlayer.Name + " wins!");
                        currentPlayer.Score++;
                        Console.WriteLine(m_FirstPlayer.Name + " Score: " + m_FirstPlayer.Score);
                        Console.WriteLine(m_SecondPlayer.Name + " Score: " + m_SecondPlayer.Score);
                        break;

                 default :
                        Console.WriteLine("This is a DRAW!");
                        Console.WriteLine(m_FirstPlayer.Name + " Score: " + m_FirstPlayer.Score);
                        Console.WriteLine(m_SecondPlayer.Name + " Score: " + m_SecondPlayer.Score);
                        break;
            }

            Console.WriteLine("Would you like to play another game?\nEnter C to continue playing or any other key to Quit.");
            string inputStr = Console.ReadLine();
            if (inputStr.ToLower() == "c"){
                this.ContinueNewGame();
            }
            else
            {
                Console.WriteLine("Game Ended!\nPress 'enter' to exit");
            }
        }   

        public Player SwitchPlayer(Player io_CurrentPlayer)
        {
            if (io_CurrentPlayer.Equals(m_FirstPlayer))
            {
                io_CurrentPlayer = m_SecondPlayer;
            }
            else
            {
                io_CurrentPlayer = m_FirstPlayer;
            }
            return io_CurrentPlayer;
        }
    }
}