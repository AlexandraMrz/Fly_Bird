using System.Drawing.Text;

namespace Fly_Bird
{
    public partial class Form1 : Form
    {

        int pipespeed = 5;
        int gravity = 15;
        int score = 0;
        bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipespeed;
            pipeTop.Left -= pipespeed;
            ScoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if (score > 5)
            {
                pipespeed = 10       ;
            }
            else 
                if(score > 15)
            {
                pipespeed = 20;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
            if (e.KeyCode == Keys.R && gameOver)
            {
                // se apeleaza functia de resetare a jocului 
                RestartGame();
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text += "   GAME OVER!!! Press R to Retry" + " ";
            gameOver = true;
        }

        private void RestartGame()
        {
            gameOver = false;

            flappyBird.Location = new Point(32, 302);
            pipeTop.Left = 800;
            pipeBottom.Left = 1200;


            score = 0;
            pipespeed = 7;
            ScoreText.Text = " Score: 0 ";
            gameTimer.Start();
        }

    }
}