using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class GameManager
    {
        public char[,] mapArray;

        public void CreatMap(Map map)
        {
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    if (i == 0 || i == map.Height - 1) mapArray[i, j] = '-';
                    else if (j == 0 || j == map.Width - 1) mapArray[i, j] = '|';
                    else mapArray[i, j] = ' ';
                }
                Console.WriteLine();
            }

            mapArray[map.Width / 2, map.Height / 2] = '#';
        }
    }
}