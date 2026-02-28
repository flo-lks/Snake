using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using static Snake.Steering;

namespace Snake
{
    public class GameManager
    {
        public bool wallcollisionANDselfcollision;
        public bool foodcollision;
        public void UpdateGame(Snake snake, MapManager mapManager, Steering steering)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                steering.UpdateDirection(keyInfo);
            }

            Snake.Point oldHead = snake.snakeList.First();
            Snake.Point newHead = oldHead;

            switch (steering.CurrentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            //Check for wall collision or self collision
            if (mapManager.grid[newHead.X, newHead.Y] == 3 || mapManager.grid[newHead.X, newHead.Y] == 1) wallcollisionANDselfcollision = true;
            if (mapManager.grid[newHead.X, newHead.Y] == 2)
            {
                foodcollision = true;
                snake.snakeList.Add(snake.snakeList[snake.snakeList.Count - 1]);
            }

            snake.snakeList.Insert(0, newHead);
            mapManager.UpdateCell(newHead.X, newHead.Y, 1);
            snake.snakeList.RemoveAt(snake.snakeList.Count - 1);
            mapManager.UpdateCell(oldHead.X, oldHead.Y, 0);
        }
    }
}