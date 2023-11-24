using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(10, 170, 20, 20);
        Rectangle player2 = new Rectangle(580, 170, 20, 20);
        Rectangle Point = new Rectangle(295, 195, 10, 10);
        Rectangle boost = new Rectangle(395, 395, 10, 10);
        int player1Score = 0;
        int player2Score = 0;

        Random silly = new Random();
        SoundPlayer sound;

        int player1counter = 0;
        int player2counter = 0;

        int playerSpeed1 = 6;
        int playerSpeed2 = 6;
        int ballXSpeed = -6;
        int ballYSpeed = 6;
        int turn = 1;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yelowBrush = new SolidBrush(Color.Yellow);
     
        public Form1()
        {
            InitializeComponent();
            Random silly = new Random();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;

                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;

                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, Point);
            e.Graphics.FillRectangle(redBrush, boost);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {


                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;



                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            player1counter++;
            player2counter++;
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed1;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed1;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed1;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed1;
            }


            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed2;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed2;
            }


            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed2;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed2;
            }




            /// check if either player has hit a point and give a point to the score bored is true
            if (player1.IntersectsWith(Point))
            {
                Random silly = new Random();
                
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                Point.X = silly.Next(0, 600);
                Point.Y = silly.Next(0, 400);
                sound = new SoundPlayer(Properties.Resources.level_passed_143039);
                sound.Play();
            }


            if (player2.IntersectsWith(Point))
            {
                Random silly = new Random();

                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                Point.X = silly.Next(0, 600);
                Point.Y = silly.Next(0, 400);
                sound = new SoundPlayer(Properties.Resources.level_passed_143039);
                sound.Play();
            }



            ///check if either player has interacted with a boost and give player fatigue if true
            if (player1.IntersectsWith(boost))
            {      
                Random silly = new Random();
                playerSpeed1 = playerSpeed1 + playerSpeed1;
                boost.X = silly.Next(0, 600);
                boost.Y = silly.Next(0, 400);
                player1counter = 0;

                sound = new SoundPlayer(Properties.Resources.nitro_activation_48077);
                sound.Play();
            }

         
          


            if (player2.IntersectsWith(boost))
            {
                Random silly = new Random();
                playerSpeed2 = playerSpeed2 + playerSpeed2;
                boost.X = silly.Next(0, 600);
                boost.Y = silly.Next(0, 400);
                player2counter = 0;
                sound = new SoundPlayer(Properties.Resources.nitro_activation_48077);
                sound.Play();
            }


            
            if (player1counter == 50)
            {
                playerSpeed1 = 2;
                winLabel.Text = "!!Fatiuge!!";
                sound = new SoundPlayer(Properties.Resources.disease);
                sound.Play();
            }

            if (player1counter == 100)
            {
                playerSpeed1 = 6;
                winLabel.Text = "";
                sound = new SoundPlayer(Properties.Resources.k);
                sound.Play();
            }







            if (player2counter == 50)
            {
                playerSpeed2 = 2;
                winLabel.Text = "!!Fatiuge!!";
                sound = new SoundPlayer(Properties.Resources.disease);
                sound.Play();
            }

            if (player2counter == 100)
            {
                playerSpeed2 = 6;
                winLabel.Text = "";
                sound = new SoundPlayer(Properties.Resources.k);
                sound.Play();
            }


            /// if player scores ten times they win

            if (player1Score == 10)
            {   
                gameTimer.Enabled = false;
                winLabel.Text = "player 1 wins!!!";
            }

            if (player2Score == 10)
            {
                gameTimer.Enabled = false;
                winLabel.Text = "player 2s wins!!!";
            }








            Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
