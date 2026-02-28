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
    }
}