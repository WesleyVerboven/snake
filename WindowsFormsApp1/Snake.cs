using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Snake
    {
        PictureBox snake;
        Point snakeLocation;
        Size SnakeSize;
        int Hspeed = -1;
        int Vspeed = 0;
        public Point turn = new Point();
        public int HChangespeed = 0;
        public int VChangespeed = 0;

        public Snake(int groote)
        {
            if (groote == 0)
            {
               snakeLocation = new Point(10, 10);
               SnakeSize = new Size(20, 20); 
            }
           
            


        }
        public Snake(int groote, Snake Head)
            {
                if (groote>0)
                {
                    if (Head.Hspeed != 0)
                    {
                        snakeLocation = new Point(Head.snakeLocation.X + (Head.SnakeSize.Width * groote) * (Head.Hspeed * -1), Head.snakeLocation.Y);
                        SnakeSize = new Size(20, 20);
                        Hspeed = Head.Hspeed;
                        Vspeed = Head.Vspeed;
                    }
                    else if (Head.Vspeed != 0)
                    {
                        snakeLocation = new Point(Head.snakeLocation.X, Head.snakeLocation.Y + (Head.SnakeSize.Height * groote) * (Head.Vspeed * -1));
                        SnakeSize = new Size(20, 20);
                        Hspeed = Head.Hspeed;
                        Vspeed = Head.Vspeed;
                    }
                
                }
            }

        public void Paint(Form forminstance)
            {
            snake = new PictureBox();
            snake.ImageLocation = @"..\..\Recources\Box.png";
            
            snake.Location = snakeLocation;
            snake.Size = SnakeSize;
            snake.Load();
            forminstance.Controls.Add(snake);
            }
        public void update()
        {
            
            if (snakeLocation.X < 0 || snakeLocation.X>800-SnakeSize.Width)
            {
                Hspeed = Hspeed * -1;
               
            }
            if(snakeLocation.Y<0 || snakeLocation.Y>600-snake.Height)
            {
                Vspeed = Vspeed * -1;
            }
            snakeLocation.X += Hspeed;
            snakeLocation.Y += Vspeed;
            snake.Location = snakeLocation;

        }
        public bool CheckPosition()
        {
            if (turn == new Point(0, 0))
                return true;
            else if (snakeLocation.X > turn.X - 3 || snakeLocation.X < turn.X + 3)
            {
                if (snakeLocation.Y > turn.Y - 3 || snakeLocation.Y < turn.Y + 3)
                {
                    snakeLocation = turn;
                    Vspeed = VChangespeed;
                    Hspeed = HChangespeed;
                    return true;
                }
                
            }
                
            return false;
        }
        public void changeSpeed(KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    Vspeed = -1;
                    Hspeed = 0;
                    VChangespeed = -1;
                    HChangespeed = 0;
                    turn = snakeLocation;
                    break;
                case Keys.Down:
                    Vspeed = 1;
                    Hspeed = 0;
                    VChangespeed = 1;
                    HChangespeed = 0;
                    turn = snakeLocation;
                    break;
                case Keys.Right:
                    Vspeed = 0;
                    Hspeed = 1;
                    VChangespeed = 0;
                    HChangespeed = 1;
                    turn = snakeLocation;
                    break;
                case Keys.Left:
                    Vspeed = 0;
                    Hspeed = -1;
                    VChangespeed = 0;
                    HChangespeed = -1;
                    turn = snakeLocation;
                    break;
            }
        }
    }
}
