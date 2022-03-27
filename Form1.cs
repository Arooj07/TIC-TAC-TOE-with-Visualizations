using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOR_Loop_Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool currentTurn = true; // true = X , false = O 
        int count_turn = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There is all Help You Need :)", "About Screen");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Exit the Application :) \n Click Ok to Exit", "Exit Screen");
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(currentTurn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
            currentTurn =! currentTurn;
            button.Enabled = false;
            count_turn++;
            winner_check();
        }
        private void winner_check()
        {
            bool game_winner = false;
            // This is for Horizontal Checks
            if ((x1.Text == x2.Text) && (x2.Text== x3.Text) && (!x1.Enabled))
            {
                game_winner = true;
            }
            else if ((y1.Text == y2.Text) && (y2.Text == y3.Text) && (!y1.Enabled))
            {
                game_winner = true;
            }
            else if ((z1.Text == z2.Text) && (z2.Text == z3.Text) && (!z1.Enabled))
            {
                game_winner = true;
            }
            // This is for Vertical Checks
            else if ((x1.Text == y1.Text) && (y1.Text == z1.Text) && (!x1.Enabled))
            {
                game_winner = true;
            }
            else if ((x2.Text == y2.Text) && (y2.Text == z2.Text) && (!x2.Enabled))
            {
                game_winner = true;
            }
            else if ((x3.Text == y3.Text) && (y3.Text == z3.Text) && (!x3.Enabled))
            {
                game_winner = true;
            }
            // This is for Diagonal Checks
            else if ((x1.Text == y2.Text) && (y2.Text == z3.Text) && (!x1.Enabled))
            {
                game_winner = true;
            }
            else if ((x3.Text == y2.Text) && (y2.Text == z1.Text) && (!z1.Enabled))
            {
                game_winner = true;
            }
            /*else if ((z1.Text == y2.Text) && (y2.Text == x3.Text) && (!z1.Enabled))
            {
                game_winner = true;
            }
            else if ((z3.Text == y2.Text) && (y2.Text == x1.Text) && (!z3.Enabled))
            {
                game_winner = true;
            }*/

            if (game_winner)
            {
                disableButton();
                string winner = " ";
                if (currentTurn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + "  Wins :)", "Woohoo!");
            }
            else
            {
                if(count_turn == 9)
                MessageBox.Show("Do Second Try :)", "Game Draw");
            }

        }
        
        private void disableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button button = (Button)c;
                    button.Enabled = false;
                }
            }
            catch { }
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count_turn = 0;
            currentTurn = true;
           try
            {
                foreach (Control c in Controls)
                {
                    Button button = (Button)c;
                    button.Enabled = true;
                    button.Text = " ";
                    
                }
            }
           catch { } 
        }
    }
}
