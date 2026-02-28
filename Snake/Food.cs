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
        
        public Point GetFoodPosition() { return this.foodPosition; }

        public void UpdateFoodPosition(MapManager mapManager)
        {
            int rndX = new Random().Next(1, mapManager.grid.GetLength(0) - 1);
            int rndY = new Random().Next(1, mapManager.grid.GetLength(1) - 1);
            if (mapManager.grid[rndX, rndY] != 1 && mapManager.grid[rndX, rndY] != 2 && mapManager.grid[rndX, rndY] != 3)
            {
                SetFoodPosition(rndX, rndY, mapManager);
            }
        }

        public void CheckSnakeFoodColision(MapManager mapManager, Snake snake)
        {
            var head = snake.snakeList[0];
            if (mapManager.grid[head.X, head.Y] == 2)
            {
                snake.snakeList.Add(snake.snakeList[snake.snakeList.Count - 1]);
                mapManager.grid[head.X, head.Y] = 0;

                UpdateFoodPosition(mapManager);
            }
        }
    }
}