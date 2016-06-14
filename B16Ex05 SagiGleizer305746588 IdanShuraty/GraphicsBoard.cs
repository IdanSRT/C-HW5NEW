using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using UI;
using Logic;

namespace B15_Ex05
{
    public partial class GraphicsBoard : Form
    {
        private int m_BoardRows;
        private int m_BoardColumns;        
        private bool m_Multiplayer;
        private Button[] m_ColumnsNum;
        private Button[,] m_GameMatrix;
        private Control[] m_GameControls;      
        private ViewModel m_ViewModel;
        private Label m_GameScore;
        private List<int[]> m_playerMoves;
        private bool m_FirstIteration = true;

        public GraphicsBoard(int i_BoardRows, int i_BoardColumns, bool i_Multiplayer)
        {
            m_BoardRows = i_BoardRows;
            m_Multiplayer = i_Multiplayer;
            m_GameMatrix = new Button[m_BoardRows, m_BoardColumns];
            m_GameControls = new Control[m_BoardColumns];
            m_ViewModel = new ViewModel(i_BoardRows, i_BoardColumns, m_Multiplayer);

            for (int i = 0; i < m_BoardRows; i++)
            {
                m_ColumnsNum[i] = new Button();
                m_ColumnsNum[i].Enabled = false;
                m_ColumnsNum[i].AutoSize = true;
                m_ColumnsNum[i].Size = new Size(new Point(25, 50));
                m_GameControls[i] = m_ColumnsNum[i];
                for (int j = 0; j < m_BoardColumns; j++)
                {
                    m_GameMatrix[i, j] = new Button();
                    m_GameMatrix[i, j].Enabled = false;
                    m_GameMatrix[i, j].AutoSize = true;
                    m_GameMatrix[i, j].Size = new Size(new Point(50, 50));
                    m_GameMatrix[i, j].Location = new Point(50 * j, 50 * i);                   
                    m_GameMatrix[i, j].Tag = new int[2] { i, j };
                    //m_gameMatrix[i, j].Click += new EventHandler(doSome);                   
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
            this.ClientSize = new System.Drawing.Size(m_BoardRows * 50, m_BoardColumns * 50);
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
                m_GameMatrix[tuple[0], tuple[1]].BackColor = Color.LightGray;
                m_GameMatrix[tuple[0], tuple[1]].Enabled = false;
                m_GameMatrix[tuple[0], tuple[1]].Click -= this.doSome;
            }
        }

        // listen when the board changed and update it accordingly
        public void OnBoardChanged(object source, EventArgs args)
        {
            GameManager gameManager = source as GameManager;
            Board gameBoard = gameManager.GameBoard;
            updateGraphicBoard(gameBoard);
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
                gameManager.pcMove();
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
                m_GameMatrix[tuple[0], tuple[1]].BackColor = Color.YellowGreen;
                m_GameMatrix[tuple[0], tuple[1]].Enabled = true;
                m_GameMatrix[tuple[0], tuple[1]].Click += new EventHandler(doSome);

            }
        }

        public void OnHideBoard(object source, EventArgs args)
        {
            this.Hide();

        }
    }
}
