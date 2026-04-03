using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Load += Form1_Load;
            this.MaximumSize = new System.Drawing.Size(1280, 720); // this and bottom one max the window at 1280x720 so dont have to make the code dynamic for different window sizes 
            this.MinimumSize = new System.Drawing.Size(1280, 720);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static float speedX = -50; // define global variable for speedX, so how far moves horiziontally,
        static float speedY = -18; // define global variaable for speedY, so how far moves vertiaclly 
        static float scoreP2 = 1; // define global variable for a score for right player. starts at 1 because starting at 0 is problematic for some reason?
        static float scoreP1 = 1; // define global variable for a score for left player. starts 1 for ssame reason as above.

        private void timer1_Tick(object sender, EventArgs e)
        {
            collisionCheck(sender, e);
            ball.Left += (int)speedX; // moves the ball by amount set in the speedX
            ball.Top += (int)speedY; // moves the ball by amount set in the speedY
            label1_Click_2(sender, e); // calls the function i made to check velocity
            Scoring(sender, e); // calls the function for scoring
            Wincheck(sender, e);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int moveStep = 10; // Pixels to move per each key press


            {
                if (e.KeyCode == Keys.W)
                {
                    if (paddle1.Top - moveStep >= 0) // check if the ball goes out of the bounds of the window which should be 1280x720
                    {
                        paddle1.Top -= moveStep;    // Moves the paddle 1 (left) down
                    }
                }
                else if (e.KeyCode == Keys.S)
                    if (paddle1.Top + moveStep <= this.ClientSize.Height - paddle1.Height) // check if that the paddle can move down by seeing if it would run out the bounds
                    {
                        paddle1.Top += moveStep;    // Moves the paddle 1 (left) up
                    }
                if (e.KeyCode == Keys.Up)
                {
                    if (paddle2.Top - moveStep >= 0) // check if the ball goes out of the bounds of the window which should be 1280x720
                    {
                        paddle2.Top -= moveStep;   // Moves the paddle 2 (right) up
                    }
                }
                else if (e.KeyCode == Keys.Down)
                    if (paddle2.Top + moveStep <= this.ClientSize.Height - paddle1.Height) // check if that the paddle can move down by seeing if it would run out the bounds
                    {
                        paddle2.Top += moveStep;   // Moves the paddle 2  (right) down
                    }


            }
        }
        private void image23_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void image24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void paddle2_Click(object sender, EventArgs e)
        {

        }

        public void collisionCheck(object sender, EventArgs e)
        {

            if (ball.Bounds.IntersectsWith(paddle1.Bounds) || ball.Bounds.IntersectsWith(paddle2.Bounds)) // checks if the ball goes within the boundaries of either paddle1 (paddle1) or paddle 2
            {
                speedX *= -1; // inverts speed of speedX in the variable defined above. i.e. 10 *-1 = -10 so sends it other direction.
                speedY *= -1.05f; // inverts speed and multiplies it a little so it gets faster otherwise the back and forth is too predictabel 
            }
            if (ball.Top <= 0 || ball.Bottom >= this.ClientSize.Height)
            {
                speedY *= -1;
            }
        }

        private void label1_Click_2(object sender, EventArgs e) // just somthing i needed so ican check the velocity was working 
        {
            label1.Visible = false; // set to true to check the speed of the ball.
            string text = speedX.ToString();
            label1.Text = text;
        }


        private void Scoring(object sender, EventArgs e) // to do the score thing system thing.
        {

            string text1 = scoreP2.ToString(); // converts the value from scoreP2 into a string so it can be put into a label later
            string text2 = scoreP1.ToString(); // converts v alue from scoreP1 to sstring so can be put into label below.
            int x = ball.Location.X; // storing the location as a variable so i dont have to type out ball.location.x every 5 minutes.
            int y = ball.Location.Y; // same as above but for y
            if (x < -10) // checks if the ball has gone past x position of -10 becasue if it has, it is out of bounds.
            {

                scoreP2 += 1; // if the condition above is true then this adds 1 to the scoreP2 variable listed somewhere up there. 
                label2.Text = text1; // changes text of the label to the score as converted above.
                ball.Location = new Point(640, 360); // resets location to default position.
            }
            else if (x > 1400) // checks if the ball has gone past x position of 1280 becasue if it has, it is out of bounds as the window is maximum of 1280px wide.
            {
                scoreP1 += 1; // same as before, adds 1 to the score if condition is true.
                label3.Text = text2; // changes text of the label to the score as converted above.
                ball.Location = new Point(640, 360); // resets location to default position.
            }
        }


        private void p1Score_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            timer1.Enabled = true;
            label5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                timer1.Enabled = false;
                label5.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
            }
            else if (panel1.Visible == true)
            {
                panel1.Visible = false;
                timer1.Enabled = true;
                label5.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            scoreP2 = 0;
            scoreP1 = 0;
            string text1 = scoreP2.ToString(); // converts the value from scoreP2 into a string so it can be put into a label later
            string text2 = scoreP1.ToString(); // converts v alue from scoreP1 to sstring so can be put into label below.
            label2.Text = text1;
            label3.Text = text2;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Wincheck(object sender, EventArgs e)
        {
            if (scoreP1 == 11)
            {
                label6.Text = "Red player wins";
                timer1.Enabled = false;
                button10.Visible = true;
            }
            else if (scoreP2 == 11)
            {
                label6.Text = "Blue player wins";
                timer1.Enabled = false;
                button10.Visible = true;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            scoreP1 = 0;
            scoreP2 = 0;
            timer1.Enabled = true;
            label6.Visible = false;
            scoreP2 = 0;
            scoreP1 = 0;
            string text1 = scoreP2.ToString(); // converts the value from scoreP2 into a string so it can be put into a label later
            string text2 = scoreP1.ToString(); // converts v alue from scoreP1 to sstring so can be put into label below.
            label2.Text = text1;
            label3.Text = text2;
            button10.Visible = false;
        }
    }
}
 





