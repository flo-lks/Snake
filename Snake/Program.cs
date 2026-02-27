using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        private readonly static bool gameOver = false;
        static void Main(string[] args)
        {
            Steering steering = new Steering();
            Snake snake = new Snake();
            GameManager gameManager = new GameManager();
            /*Map map = new Map(20, 20);

            int[] old = { 1, 1 };

            gameManager.CreatMap(map, snake);
            for(int i = 0; i < map.Height; i++)
            {
                for(int j = 0; j < map.Width; j++)
                {
                    Console.Write(gameManager.mapArray[i, j]);
                }
                Console.WriteLine();
            }
            gameManager.UpdateSnakePosition(snake, old);
            */
            

            while (!gameOver)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    steering.UpdateDirection(keyInfo);
                }
            }
            Console.WriteLine("Game Over");
        }
    }
}
