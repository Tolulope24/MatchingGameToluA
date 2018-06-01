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
        //  Create a random obect Generator
        Random randomObject = new Random();
        int timer;
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
            btnStart.Hide();
            lblInstruction.Hide();
            picMochi.Hide();
            lblIntro.Hide();

            // add Pictures to list

            

        }

        private void Timer (object sender, EventArgs e)
        {
            if (timer > 0 )
            {

            }
        }

        private void frmMatchingGame_Load(object sender, EventArgs e)
        {

        }
    }
}
