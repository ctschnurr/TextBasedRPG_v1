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
        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.SetWindowSize(91, 41);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;

            map.DrawMap();

            while (gameOver == false)
            {
                map.PlayerDraw(player.x + 2, player.y + 1, player.character);
                PlayerUpdate();
            }

        }

        static void PlayerUpdate()
        {
            bool isWalkable;
            char destination = ' ';

            ConsoleKeyInfo choice = Console.ReadKey(true);

            Console.SetCursorPosition(player.x + 2, player.y + 1);
            char tile = Map.map[player.y, player.x];

            Map.DrawTile(tile);

            switch (choice.Key)
            {
                case ConsoleKey.Escape:
                    gameOver = true;
                    break;

                case ConsoleKey.W:
                    destination = Map.map[player.y - 1, player.x];
                    isWalkable = map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        player.y--;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.S:
                    destination = Map.map[player.y + 1, player.x];
                    isWalkable = map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        player.y++;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.A:
                    destination = Map.map[player.y, player.x - 1];
                    isWalkable = map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        player.x--;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.D:
                    destination = Map.map[player.y, player.x + 1];
                    isWalkable = map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        player.x++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            // CheckForDoor();
        }
    }
}
