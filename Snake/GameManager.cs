using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Snake
{
    public class GameManager
    {
        //update the food position to a random cell that is not occupied by the snake or a wall
        public void UpdateFoodPosition(MapManager mapManager, Food food)
        {
            int rndX = new Random().Next(0, mapManager.grid.GetLength(0)-1);
            int rndY = new Random().Next(0, mapManager.grid.GetLength(1)-1);
            if (mapManager.grid[rndX, rndY] != 1 && mapManager.grid[rndX, rndY] != 2 && mapManager.grid[rndX, rndY] != 3)
            {
                food.SetFoodPosition(rndX, rndY, mapManager);
            }
        }

        //Check if the snake's head is on a cell with food, if so, grow the snake and update the food position
        public void CheckSnakeFoodColision(MapManager mapManager, Snake snake, Steering steering, Food food)
        {
            var head = snake.snakeList[0];
            if (mapManager.grid[head.X, head.Y] == 2)
            {
                snake.snakeList.Add(snake.snakeList[snake.snakeList.Count - 1]);
                mapManager.grid[head.X, head.Y] = 0;

                UpdateFoodPosition(mapManager, food);
            }
        }
    }
}