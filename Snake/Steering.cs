using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Steering
    {
        public enum Direction
        {
            Up, Down, Left, Right
        }

        public Direction CurrentDirection { get; set; }

        public void UpdateDirection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (CurrentDirection != Direction.Down) CurrentDirection = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (CurrentDirection != Direction.Up) CurrentDirection = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (CurrentDirection != Direction.Right) CurrentDirection = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (CurrentDirection != Direction.Left) CurrentDirection = Direction.Right;
                    break;
            }
        }

        public void UpdateSnakePosition(Snake snake, MapManager mapManager)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                UpdateDirection(keyInfo);
            }

            Snake.Point oldHead = snake.snakeList.First();
            Snake.Point newHead = oldHead;

            switch (CurrentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            snake.snakeList.Insert(0, newHead);
            mapManager.UpdateCell(newHead.X, newHead.Y, 1);
            snake.snakeList.RemoveAt(snake.snakeList.Count - 1);
            mapManager.UpdateCell(oldHead.X, oldHead.Y, 0);
        }
    }
}