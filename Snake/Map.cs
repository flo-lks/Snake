using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Map
    {
        public int Width {  get; set; }
        public int Height { get; set; }

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}