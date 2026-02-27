using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        private readonly static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Steering steering = new Steering();
            Snake snake = new Snake();
            GameManager gameManager = new GameManager();
            Food food = new Food();
            MapManager mapManager = new MapManager();

            Console.Write("Map width: ");
            int mapWidth = int.Parse(Console.ReadLine());
            Console.Write("Map height: ");
            int mapHeight = int.Parse(Console.ReadLine());
            Map map = new Map(mapWidth, mapHeight);
            mapManager.CreateMap(map);

            snake.snakeList.Add(new Snake.Point { X = mapWidth / 2, Y = mapHeight / 2 });
            steering.CurrentDirection = Steering.Direction.Right;

            Console.Clear();
            for (int i = 0; i < mapManager.grid.GetLength(0); i++)
            {
                for (int j = 0; j < mapManager.grid.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (mapManager.grid[i, j] == 0) Console.Write(" ");
                    else Console.Write("#");
                }
                Console.WriteLine();
            }


            //Game loop
            while (!gameOver)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    steering.UpdateDirection(keyInfo);
                }

                steering.UpdateSnakePosition(snake, mapManager);

                Console.SetCursorPosition(snake.snakeList[0].X, snake.snakeList[0].Y);
                Console.WriteLine("0");

                Snake.Point tail = snake.snakeList.Last();
                Console.SetCursorPosition(tail.X, tail.Y);
                Console.WriteLine(" ");

                Thread.Sleep(100);
            }
            Console.WriteLine("Game Over");
        }
    }
}
