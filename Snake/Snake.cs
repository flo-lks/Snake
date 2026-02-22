using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Snake
    {
        int X {  get; set; }
        int Y { get; set; }

        public Snake(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int[] getPos()
        {
            int[] pos = new int[2];
            pos[0] = this.X;
            pos[1] = this.Y;
            return pos;
        }
    }
}