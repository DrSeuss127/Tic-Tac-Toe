using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool playerTurn = true;
        int playerTurnCount = 0;
        int p1WinCount = 0;
        int p2WinCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e) //Single event handler for all tic-tac-toe-grid buttons
        {
            Button b = (Button)sender; //Declares variable b as the button sender, which applies to the tic-tac-toe 3x3 grid

            if (playerTurn)             //Playerturn is true by default, !playerturn negates it
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            playerTurn = !playerTurn; //Negates playerturn
            b.Enabled = false;          //Disables the button once a player has clicked


            //Checks every possible combination of the same 3 characters in the tic tac toe grid
            //It does this by checking if the text in all 3 buttons are the same, and if the first button in the row/column/diagonal is not enabled.
            bool thereIsAWinner = false;

            //Horizontal Checking
            if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
            {
                thereIsAWinner = true;
            }

            //Vertical Checking
            else if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
            {
                thereIsAWinner = true;
            }

            //Diagonal Checking
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
            {
                thereIsAWinner = true;
            }
            else if ((button7.Text == button5.Text) && (button5.Text == button3.Text) && (!button7.Enabled))
            {
                thereIsAWinner = true;
            }


            if (thereIsAWinner)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;

                //Stores the string of the winner
                string winner = "";
                

                if (playerTurn)
                {
                    p2WinCount ++;
                    winner = "O";
                    p2Win.Text = "";
                    p2Win.Text = p2WinCount.ToString();
                        ;
                }
                else
                {
                    p1WinCount ++;
                    winner = "X";
                    p1Win.Text = "";
                    p1Win.Text = p1WinCount.ToString(); 
                }

                MessageBox.Show(winner + " wins!");
            }
        }

        private void resetBtn_Click(object sender, EventArgs e) 
        {
            //Resets the table; empties the button texts and enables the buttons

            button1.Text = "";
            button1.Enabled = true;

            button2.Text = "";
            button2.Enabled = true;

            button3.Text = "";
            button3.Enabled = true;

            button4.Text = "";
            button4.Enabled = true;

            button5.Text = "";
            button5.Enabled = true;

            button6.Text = "";
            button6.Enabled = true;

            button7.Text = "";
            button7.Enabled = true;

            button8.Text = "";
            button8.Enabled = true;

            button9.Text = "";
            button9.Enabled = true;
        }
    }
}
