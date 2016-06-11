using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B16_Ex02_Idan_201580990_Sagi_305746588
{
    public enum eSign
    {
        O,
        X
    }

    public class Player
    {
        private eSign m_PlayerSign;
        private bool m_IsPC;
        private string m_Name;
        private int m_Score;
        public int m_LastMove;
        public int m_OlderMove;

        public Player(string i_Name, bool i_IsPC, eSign i_PlayerSign)
        {
            m_PlayerSign = i_PlayerSign; 
            m_IsPC = i_IsPC;
            m_Name = i_Name;   
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public eSign Sign
        {
            get { return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public bool IsPC
        {
            get { return m_IsPC; }
            set { m_IsPC = value; }
        }
   
        public int GuessNumber(int i_Columns)
        {
            Random rndNum = new Random();
            int guessresult = rndNum.Next(1, i_Columns);
            return guessresult;
        }

        public int PcBlock(Board i_GameBoard, int i_PlayerLastMove, int i_PlayerOlderMove)
        {
            int ColumnsRange = i_GameBoard.Columns;
            int ColumnPick = GuessNumber(ColumnsRange);
            if( i_PlayerLastMove == i_PlayerOlderMove)
            {
                ColumnPick = i_PlayerLastMove;
            }
            if( Math.Abs( i_PlayerLastMove - i_PlayerOlderMove) == 1)
            {
                if (Math.Max(i_PlayerLastMove, i_PlayerOlderMove) + 1 < ColumnsRange)
                {
                    ColumnPick = Math.Max(i_PlayerLastMove, i_PlayerOlderMove) + 1;
                }
                else if (Math.Min(i_PlayerLastMove, i_PlayerOlderMove) - 1 > 1)
                {
                    ColumnPick = Math.Max(i_PlayerLastMove, i_PlayerOlderMove) - 1;
                }
            }
            while (i_GameBoard.IsColumnFull(ColumnPick - 1))
            {
                if (ColumnPick == ColumnsRange)
                {
                    ColumnPick = 1;
                }
                ColumnPick++;
            }

            return ColumnPick;
        }

        internal int PcBlock()
        {
            throw new NotImplementedException();
        }
    }
}
