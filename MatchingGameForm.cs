using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGameToluA
{
    public partial class frmMatchingGame : Form
    {
        public frmMatchingGame()
        {
            InitializeComponent();
            // Hide Layout Panels
            tableLayoutPanel1.Hide();
            tableLayoutPanel2.Hide();

            // Hide Restart Button, end button and Level 2 button
            btnLevel2.Hide();
            btnRestart.Hide();
            btnEnd.Hide();

            // Hide Labels and picture boxes
            picMochiPanda.Hide();
            lblCongrats.Hide();

            // Call assign pics to squares function
            AssignPicsToSquares();
        }
        // Create a timer Integer
        int Time;

        // Set the first two clicked squares to nothing
        Label firstClicked = null;
        Label secondClicked = null;

        //  Create a random obect Generator
        Random randomObject = new Random();

        // Create a list of random objects (using the webdings font creates the pics)
        List<string> Objects = new List<string>()
        {
            // Choose random characters (by choice) in pairs
            "a", "a", "x", "x", "<", "<", "Y", "Y",
            "!", "!", "h", "h", "%", "%", "$", "$"
        };

        List<string> Pics = new List<string>()
        {
            // Choose random characters (by choice) in pairs
            "a", "a", "x", "x", "<", "<", "Y", "Y","v", "v", "O", "O",
            "!", "!", "h", "h", "J", "J", "z", "z", "^","^", "@", "@",
            "[", "[", "u", "u", "i", "i", "8", "8", "2", "2", "q", "q",
        };

        // assign images to a random square
        private void AssignPicsToSquares()
        {
            // for each squares in the table layout panel 
            // Control them as lables
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label picLabel = control as Label;

                // Set boolean to assign 
                if (picLabel != null)
                {
                    // add random number to List
                    int randomNumber = randomObject.Next(Objects.Count);

                    // Assign list to squares
                    picLabel.Text = Objects[randomNumber];

                    // Set the colours Identically 
                    picLabel.ForeColor = picLabel.BackColor;

                    // Remove random number after it has been used
                    Objects.RemoveAt(randomNumber);
                }
            }
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                Label pics = control as Label;

                // 
                if (pics != null)
                {
                    // add random number to List
                    int randomNumber = randomObject.Next(Pics.Count);

                    // Assign list to squares
                    pics.Text = Pics[randomNumber];

                    // Set the colours Identically 
                    pics.ForeColor = pics.BackColor;

                    // Remove random number after it has been used
                    Pics.RemoveAt(randomNumber);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Show Layout Panel 
            tableLayoutPanel1.Show();
            tableLayoutPanel2.Hide();

            // Hide Start Button 
            btnStart.Hide();
            lblInstruction.Hide();
            picMochi.Hide();
            lblIntro.Hide();

            // set Timer
            Time = 30;
            lblTime.Text = "30 Seconds";
            timer2.Start();
        }
         


        // add a click event on each of the little squares
        private void label_Click(object sender, EventArgs e)
        {
            // If player Starts Game
            if (timer1.Enabled == true)
                //Return Function
                return;
            Label clickedLabel = sender as Label;
            //
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Red)
                    return;
                //
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Red;

                    return;
                }
                //
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Red;
                //
                CheckWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
              
                // Call timer function
                timer1.Start();
            }
        }

        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop Timer
            timer1.Stop();
            //
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckWinner()
        {
            //for each control buttons in the tablelayout panel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                //
                Label picLabel = control as Label;
                // if there are no more hidden lables on the form
                if ( picLabel != null)
                {
                    if (picLabel.ForeColor == picLabel.BackColor)
                        return;
                }

            }
            // Stop the timer
            timer2.Stop();

            // Show level 2 button
            btnLevel2.Show();

            /*show message box
             MessageBox.Show("You matched all the pictures", " You Win!");*/

            //for each control buttons in the tablelayout panel
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                //
                Label picLabel = control as Label;
                // if there are no more hidden lables on the form
                if (picLabel != null)
                {
                    if (picLabel.ForeColor == picLabel.BackColor)
                        return;
                }

            }
            // Stop Timer
            timer3.Stop();

            // Show congratulatory Message box
            MessageBox.Show("Congratulations You Have Completed the Game");
            btnLevel2.Hide();
            btnRestart.Hide();
            btnEnd.Show();


        }


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            // if time is more than 0
            if (Time > 0)
            {
                Time = Time - 1;
                // Show time on the form
                lblTime.Text = Time + " Seconds";
            }
            // or
            else
            {
                // Disable Tablelayout pannel to prevent Player from continuing 
                tableLayoutPanel1.Enabled = false;
                // Time is up
                lblTime.Text = " Time's Up!!!";
                // stop Timer
                timer2.Stop();
                // Show message box
                MessageBox.Show("You Ran Out Of Time", "Better Luck Next Time");
                // Show hidden Buttons
                btnRestart.Show();
                btnLevel2.Show();
            }
        }



        private void timer3_Tick(object sender, EventArgs e)
        {
            // if time is more than 0
            if (Time > 0)
            {
                Time = Time - 1;
                // Show time on the form
                lblTime.Text = Time + " Seconds";
            }
            // or
            else
            {
                // Disable Tablelayout pannel to prevent Player from continuing 
                tableLayoutPanel2.Enabled = false;
                // Time is up
                lblTime.Text = " Time's Up!!!";
                // stop Timer
                timer3.Stop();
                // Show message box
                MessageBox.Show("You Ran Out Of Time", "Better Luck Next Time");
                // Show hidden Buttons
                btnRestart.Show();
                //hide level 2 button
                btnLevel2.Hide();
            }
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            btnRestart.Show();
            tableLayoutPanel2.Show();
            timer3.Start();
            // set Timer
            Time = 90;
            lblTime.Text = "90 Seconds";
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            // Hide Layout Panel 
            tableLayoutPanel1.Hide();
            tableLayoutPanel2.Hide();

            // Hide Start Button 
            btnStart.Hide();

            // Hide Labels
            lblInstruction.Hide();
            lblIntro.Hide();

            // Hide Intro Pic
            picMochi.Hide();

            // show end
            lblCongrats.Show();
            picMochiPanda.Show();
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        private void frmMatchingGame_Load(object sender, EventArgs e)
        {

        }


    }
}
