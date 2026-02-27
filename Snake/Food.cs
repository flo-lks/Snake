using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Food
    {
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
        public Point foodPosition;
        public void SetFoodPosition(int x, int y, MapManager mapManager)
        {
            this.foodPosition.X = x;
            this.foodPosition.Y = y;

            mapManager.UpdateCell(x, y, 2);
        }
        
        public Point GetFoodPosition()
        {
            return this.foodPosition;
        }
    }
}