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
    public partial class GraphicsBoard : Form
    {
        private int m_BoardLines;
        private int m_BoardColumns;
        private bool m_AgaintsComputer;
        private Button[] m_GameButtons;
        private Button[,] m_GameMatrix;
        private Control[] m_GameControls;
        private Label m_CurrentScore;
        private int m_playerOneScore;
        private int m_playerTwoScore;



        public GraphicsBoard(int i_boardLines, int i_boardColumns, bool i_againtsComputer)
        {
            m_BoardLines = i_boardLines;
            m_BoardColumns = i_boardColumns;
            m_AgaintsComputer = i_againtsComputer;
            m_GameButtons = new Button[m_BoardLines];
            m_GameMatrix = new Button[m_BoardLines, m_BoardColumns];
            m_GameControls = new Control[m_BoardColumns];
            m_playerOneScore = m_playerTwoScore = 0;
            m_CurrentScore = new Label();
            //nothing
            for (int i = 0; i < m_BoardColumns; i++)
            {
                m_GameButtons[i] = new Button();
                m_GameButtons[i].Size = new Size(new Point(25, 50));
                m_GameButtons[i].Text = (i + 1).ToString();
                m_GameButtons[i].Enabled = true;
                m_GameButtons[i].AutoSize = true;
            }

            for (int i = 0; i < m_BoardLines; i++)
            {
                for (int j = 0; j < m_BoardColumns; j++)
                {
                    m_GameMatrix[i, j] = new Button();
                    m_GameMatrix[i, j].Enabled = false;
                    m_GameMatrix[i, j].AutoSize = true;
                    m_GameMatrix[i, j].Size = new Size(new Point(50, 50));
                    m_GameMatrix[i, j].Location = new Point(50 * j, 50 * i);
                    m_GameMatrix[i, j].Text = "(" + j + ", " + i + ")";
                    m_GameMatrix[i, j].Tag = new int[2] { i, j };
                }
            }

            this.Controls.AddRange(m_GameControls);
            InitializeComponent();


            //register to event from viewModel
            m_ViewModel.BoardChanged += this.OnBoardChanged;

            //run game
            m_ViewModel.runGame();

            //Set background color
            this.BackColor = Color.LightGray;

            this.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(m_BoardLines * 50, m_BoardColumns * 50);
            this.Name = "GraphicsBoard";

            // @TODO: Check how to fix resize window with all forms
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ResumeLayout(false);

        }

        private void doSome(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                int[] tuple = button.Tag as int[];

                //call the move function with the clicked butotn index
                removeListeners();
                m_ViewModel.move(tuple);
            }

        }

        private void removeListeners()
        {
            foreach (int[] tuple in m_playerMoves)
            {
                m_gameMatrix[tuple[0], tuple[1]].BackColor = Color.LightGray;
                m_gameMatrix[tuple[0], tuple[1]].Enabled = false;
                m_gameMatrix[tuple[0], tuple[1]].Click -= this.doSome;
            }
        }

        // listen when the board changed and update it accordingly
        public void OnBoardChanged(object source, EventArgs args)
        {
            GameController gameControler = source as GameController;
            int[,] boardMatrix = gameControler.getMatrix();
            updateGraphicBoard(boardMatrix);
            if (!m_FirstIteration)
            {
                m_ViewModel.m_FirstPlayerTurn = !m_ViewModel.m_FirstPlayerTurn;
                printTitleToForm();
            }
            else
            {
                m_FirstIteration = false;
            }


            //m_playerMoves = m_ViewModel.getPlayerMoves();
            //updatePlayerAvailableMoves(m_playerMoves);

            // @TODO: check the logic when pc plays all the graphics are mass out

            if (m_Multiplayer || (!m_Multiplayer && m_ViewModel.m_FirstPlayerTurn))
            {
                m_playerMoves = m_ViewModel.getPlayerMoves();
                updatePlayerAvailableMoves(m_playerMoves);
            }

            else if (!m_Multiplayer && !m_ViewModel.m_FirstPlayerTurn)
            {
                gameControler.pcMove();
            }
        }

        private void printTitleToForm()
        {
            string playerTitle = m_ViewModel.m_FirstPlayerTurn ? "Black turn" : "White turn";
            this.Text = playerTitle;
        }

        private void updatePlayerAvailableMoves(List<int[]> playerMoves)
        {
            foreach (int[] tuple in playerMoves)
            {
                m_gameMatrix[tuple[0], tuple[1]].BackColor = Color.YellowGreen;
                m_gameMatrix[tuple[0], tuple[1]].Enabled = true;
                m_gameMatrix[tuple[0], tuple[1]].Click += new EventHandler(doSome);

            }
        }

        private void updateGraphicBoard(int[,] i_BoardMatrix)
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i_BoardMatrix[i, j] == 1)
                    {
                        m_gameMatrix[i, j].BackColor = Color.Black;
                        m_gameMatrix[i, j].ForeColor = Color.White;
                        m_gameMatrix[i, j].Text = "O";
                        m_gameMatrix[i, j].Enabled = false;
                    }
                    else if (i_BoardMatrix[i, j] == -1)
                    {
                        m_gameMatrix[i, j].BackColor = Color.White;
                        m_gameMatrix[i, j].ForeColor = Color.Black;
                        m_gameMatrix[i, j].Text = "O";
                        m_gameMatrix[i, j].Enabled = false;
                    }
                }
            }
        }



        public void OnHideBoard(object source, EventArgs args)
        {
            this.Hide();

        }
    }
}
