using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class MapManager
    {
        //The grid Array represents the game map
        //Type sets value of the cell
        //0 - empty cell
        //1 - snake body
        //2 - food
        //3 - wall

        public int[,] grid;

        public void UpdateCell(int x, int y, int type)
        {
            grid[x, y] = type;
        }

        public void CreateMap(int width, int height)
        {
            grid = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
                        grid[i, j] = 3;
                    else
                        grid[i, j] = 0;
                }
            }
        }
    }
}