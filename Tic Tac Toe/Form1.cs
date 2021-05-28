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

        //Variables for the players' turns, the number of turns left, and the counter for p1 and p2 scores
        bool playerTurn = true;
        int playerTurnCount = 9;
        int p1WinCount = 0;
        int p2WinCount = 0;

        void turnIndicator() 
        {
            if (playerTurn)
            {
                turnInd.Text = "X's turn!";
            }
            else
            {
                turnInd.Text = "O's turn!";
            }
        }

        public Form1()
        {
            InitializeComponent();
            turnIndicator();
        }

        private void button_click(object sender, EventArgs e) //Single event handler for all tic-tac-toe-grid buttons
        {
            Button b = (Button)sender;                      //Declares variable b as button and converts the object "sender" to a button

            //Checks if playerTurn is true, if true, player1 (X) will click, if false, player2 (O) will click

            if (playerTurn)                                 //playerTurn is true by default, !playerturn negates it (switches value of playerTurn)
            {
                b.Text = "X";
                playerTurn = !playerTurn;                   //Switch for true and false playerTurn
            }
            else
            {
                b.Text = "O";
                playerTurn = !playerTurn;
            }

            turnIndicator();
                                  
            b.Enabled = false;                              //Disables the button once a player has clicked
            playerTurnCount--;                              //Decrements players' number of turns left whenever a button is clicked
            turnCountLbl.Text = playerTurnCount.ToString(); //Writes the number of turns to the target label


            //Boolean variable for winner checking
            bool thereIsAWinner = false;


            //Checks every possible combination of the same 3 characters in the tic tac toe grid and if first button is disabled to avoid message box showing earlier than expected
            
            //Horizontal Checking -------
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


            //Vertical Checking ||||||||
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


            //Diagonal Checking \\\\////
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

                //Checks who's turn it is and displays it 
                turnIndicator();

                //Disables all the buttons once there is a winner
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;

                //Stores the string value of the winner (X or O)
                string winner = "";


                //Clears the output for number of turns
                turnCountLbl.Text = "9";                


                //Determines which of the two players won and increments their score by 1
                if (playerTurn)
                {
                    playerTurn = true;                  //Resets whose turn it is (X by default)
                    playerTurnCount = 9;                //Resets the number of turns left

                    
                    turnIndicator();                    //Checks who's turn it is and displays it 

                    p2WinCount ++;
                    winner = "O";
                    p2Win.Text = "";
                    p2Win.Text = p2WinCount.ToString();

                    MessageBox.Show("Player 2 (" + winner + ") wins!");

                    //Resets all buttons and enables them again after a winner is identified
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
                else
                {
                    playerTurn = true;                  //Resets whose turn it is (X by default)
                    playerTurnCount = 9;                //Resets number of turns left

                    turnIndicator();                    //Checks who's turn it is and displays it 

                    p1WinCount ++;
                    winner = "X";
                    p1Win.Text = "";
                    p1Win.Text = p1WinCount.ToString();

                    MessageBox.Show("Player 1 (" + winner + ") wins!");


                    //Resets all buttons and enables them if no winner is identified
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
            else if (playerTurnCount == 0)       //Checks if the number of turns left is equal to 0. If it is, shows a message box and resets the buttons
            {
                
                 MessageBox.Show("There is no winner. Resetting the grid..");

                 playerTurn = true;                  //Resets whose turn it is (X by default)
                 playerTurnCount = 9;                //Resets the number of turns
             
                 turnIndicator();                    //Checks who's turn it is and displays it 

                 turnCountLbl.Text = "9";            //Clears the output for number of turns

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

        private void resetBtn_Click(object sender, EventArgs e)             //Event handler for a manual reset grid button
        {
            //Resets the table; empties the button texts and enables the buttons

            playerTurn = true;          //Resets whose turn it is
            playerTurnCount = 9;        //Resets the number of turns
            turnCountLbl.Text = "9";    //Clears the output for number of turns

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

        private void resetScoreBtn_Click(object sender, EventArgs e)     //Event handler for a manual reset score button
        {
            //Resets values for the wins count for both players
            p1WinCount = 0;
            p2WinCount = 0;

            //Clears the values on the output label
            p1Win.Text = "0";
            p2Win.Text = "0";
        }

        private void mouseEnter(object sender, EventArgs e)             //Event handler for determining whose turn it is when hovering over the button
        {

            Button b = (Button)sender;  

            //If a button is enabled and the mouse hovers over the button, determines which player's turn is it, then displays the symbol (X or O)
            if (b.Enabled)
            {
                if (playerTurn)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }

        private void mouseLeave(object sender, EventArgs e)         //Event handler for clearing the button text whenever the mouse leaves the button
        {
            Button b = (Button)sender;

            //If a button is enabled, and the mouse leaves the button, clears the text
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitGameBtn_Click(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
