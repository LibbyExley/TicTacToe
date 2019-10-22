using System;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace TicTacToe
{
    public partial class Game : Form
    {
        private string PlayerX;
        private string PlayerO;
        private int TurnNumber;

        public Game()
        {
            //creates a new game board with all tiles starting as disabled.
            InitializeComponent();
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;

        }

        protected void playButton_Click(object sender, EventArgs e)
        {   //if the button text is play it checks to see if the use has inputted names
            if (playButton.Text == "Play")
            {
                if (player1Name.Text == "")
                {
                    MessageBox.Show("Please enter the names of the players");
                }
                else if (player2Name.Text == "")
                {
                    MessageBox.Show("Please enter the names of the players");
                }
                //the user is prompted for names if one or both of the name spaces are blank
                else
                {
                    //if names are inputted a welcome message is shown.
                    PlayerX = player1Name.Text;
                    PlayerO = player2Name.Text;

                    MessageBox.Show("Welcome to Tic-Tac-Toe");
                    playButton.Text = "Quit";

                    TurnNumber = 1;
                }
                RefreshGrid();  //the game board is now ready to play
            }
            else
            {
               //at the end of the game the user is asked if they wish to change names
                var dialogResult = MessageBox.Show("Do you want to change the players names?", "New Game?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes) //if "Yes" then a fresh game is made
                {
                    RefreshGrid();
                    player1Name.Text = "";
                    player2Name.Text = "";
                }

                playButton.Text = "Play";
            }  
        }

        private void RefreshGrid() //makes a ready to play game board
        {
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;

            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";

            A1.BackColor = System.Drawing.Color.RoyalBlue;
            A2.BackColor = System.Drawing.Color.RoyalBlue;
            A3.BackColor = System.Drawing.Color.RoyalBlue;
            B1.BackColor = System.Drawing.Color.RoyalBlue;
            B2.BackColor = System.Drawing.Color.RoyalBlue;
            B3.BackColor = System.Drawing.Color.RoyalBlue;
            C1.BackColor = System.Drawing.Color.RoyalBlue;
            C2.BackColor = System.Drawing.Color.RoyalBlue;
            C3.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void SelectTile(object sender, EventArgs e)
        {
            var tile = sender as Button;
            if (TurnNumber % 2 == 0) //if its an even turn number it is O's turn
            {
                tile.Text = "O";
            }
            else
            {
                tile.Text = "X";
            }

            tile.Enabled = false; //the tile then becomes disabled so it cannot be changed
            tile.BackColor = System.Drawing.Color.Pink;
            TurnNumber++;
            var matchFound = CheckForMatch();

            if (!matchFound && TurnNumber == 10)
            {
                MessageBox.Show("The game is a draw!"); 
                //if all tiles has been played without a match, it declares a draw
            }
            else if(matchFound)
            {
                DisableBoard();
            }

        }
        private bool CheckForMatch()
        {
            //horizontal checks for an X match
            if (A1.Text == "X" && B1.Text == "X" && C1.Text == "X" ||
                A2.Text == "X" && B2.Text == "X" && C2.Text == "X" ||
                A3.Text == "X" && B3.Text == "X" && C3.Text == "X")
            {
                MessageBox.Show($"{player1Name.Text} is the winner!");
                return true;
            }
            //vertical checks for an X match 
            if (A1.Text == "X" && A2.Text == "X" && A3.Text == "X" ||
                B1.Text == "X" && B2.Text == "X" && B3.Text == "X" ||
                C1.Text == "X" && C2.Text == "X" && C3.Text == "X")
            {
                MessageBox.Show($"{player1Name.Text} is the winner!");
                return true;
            }
            //diagonal check for an X match
            if (A1.Text == "X" && B2.Text == "X" && C3.Text == "X" ||
                A3.Text == "X" && B2.Text == "X" && C1.Text == "X")
            {
                MessageBox.Show($"{player1Name.Text} is the winner!");
                return true;
            }

            //horizontal checks for an O match
            if (A1.Text == "O" && B1.Text == "O" && C1.Text == "O" ||
                A2.Text == "O" && B2.Text == "O" && C2.Text == "O" ||
                A3.Text == "O" && B3.Text == "O" && C3.Text == "O")
            {
                MessageBox.Show($"{player2Name.Text} is the winner!");
                return true;
            }
            //vertical checks for an O match 
            if (A1.Text == "O" && A2.Text == "O" && A3.Text == "O" ||
                B1.Text == "O" && B2.Text == "O" && B3.Text == "O" ||
                C1.Text == "O" && C2.Text == "O" && C3.Text == "O")
            {
                MessageBox.Show($"{player2Name.Text} is the winner!");
                return true;
            }
            //diagonal check for an O match
            if (A1.Text == "O" && B2.Text == "O" && C3.Text == "O" ||
                A3.Text == "O" && B2.Text == "O" && C1.Text == "O")
            {
                MessageBox.Show($"{player2Name.Text} is the winner!");
                return true;
            }
            return false;
        }
        private void DisableBoard()
        {
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;
        }
    }
}
