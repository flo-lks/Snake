using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Snake
    {
        //The List stores the coordinates of the snake's body parts, where the first element is the head and the last element is the tail

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public List<Point> snakeList = new List<Point>();
    }
}