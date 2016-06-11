using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Coin
    {
        public eSign m_Sign;
        public int m_CoinRow;
        public int m_CoinColumn;

        public Coin(eSign i_Sign, int i_Row, int i_Column)
        {
            m_CoinColumn = i_Column;
            m_CoinRow = i_Row;
            m_Sign = i_Sign;
        }

        public eSign Sign
        {
            get { return m_Sign; }
            set { m_Sign = value; }
        }

        public override string ToString()
        {
            return m_Sign.ToString();
        } 
    }
}