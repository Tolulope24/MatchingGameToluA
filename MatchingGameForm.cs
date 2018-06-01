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
            // Hide Layout Panel
            tableLayoutPanel1.Hide();
            AssignPicsToSquares();
        }
        Label firstClicked = null;
        Label secondClicked = null;
        //  Create a random obect Generator
        Random randomObject = new Random();
        // Create a list of random objects
        List<string> Objects = new List<string>()
        {
            "a", "a", "b", "b", "<", "<", "Y", "Y",
            "!", "!", "h", "h", "%", "%", "$", "$"
        };
        // assign images to a random square
        private void AssignPicsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label picLabel = control as Label;
                if (picLabel != null)
                {
                    int randomNumber = randomObject.Next(Objects.Count);
                    picLabel.Text = Objects[randomNumber];
                    picLabel.ForeColor = picLabel.BackColor;
                    Objects.RemoveAt(randomNumber);
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Show Layout Panel 
            tableLayoutPanel1.Show();
            // Hide Start Button 
            btnStart.Hide();
            lblInstruction.Hide();
            picMochi.Hide();
            lblIntro.Hide();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Red)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Red;

                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Red;

                CheckWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;

        }

        private void CheckWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label picLabel = control as Label;
                if ( picLabel != null)
                {
                    if (picLabel.ForeColor == picLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("You matched all the pictures", " You are the Winner");
                Close();
        }
    
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void frmMatchingGame_Load(object sender, EventArgs e)
        {

        }
    }
}
