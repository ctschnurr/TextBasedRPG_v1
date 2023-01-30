using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Program
    {
        static Map map = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        public static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.SetWindowSize(91, 41);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;

            map.DrawMap();

            while (gameOver == false)
            {
                player.Draw(player.x + 2, player.y + 1, player.character);
                enemy.Draw(enemy.x + 2, enemy.y + 1, enemy.character);
                player.Update();
                BattleCheck(player);
                enemy.Update();
                BattleCheck(enemy);
            }

        }

        static void BattleCheck(Character agressor)
        {
            if (player.x == enemy.x && player.y == enemy.y)
            {
                Console.WriteLine(agressor.name + " started a fight!");

                switch (agressor.name)
                {
                    case "Player":
                        Console.WriteLine("Player attacks first!");
                        break;

                    case "Enemy":
                        Console.WriteLine("Enemy attacks first!");
                        break;
                }
            }
        }
    }
}
