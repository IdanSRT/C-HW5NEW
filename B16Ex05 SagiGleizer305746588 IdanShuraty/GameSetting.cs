using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B16Ex01_SagiGleizer305746588_IdanShuraty
{
    public partial class GameSetting : Form
    {
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_Rows;
        private int m_Cols;
        bool m_IsAgainstComputer;

        public int Cols
        {
            get { return m_Cols; }
        }

        public int Rows
        {
            get { return m_Rows; }
        }


        public GameSetting()
        {
            InitializeComponent();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.m_Player1Name = this.textBoxPlayer1Name.Text;
            this.m_Player2Name = this.textBoxPlayer2Name.Text;
            this.m_Rows = (int) numericUpDownRows.Value;
            this.m_Cols = (int) numericUpDownRows.Value;
            GraphicsBoard gameBoard = new GraphicsBoard(m_Rows, m_Cols, )
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = this.textBoxPlayer2Name.Enabled;
            if (!enabled)
            {
                this.textBoxPlayer2Name.Enabled = true;
            }
            else
            {
                this.textBoxPlayer2Name.Enabled = false;
                this.textBoxPlayer2Name.Text = "[Computer]";
            }
        }

      
    }
}
