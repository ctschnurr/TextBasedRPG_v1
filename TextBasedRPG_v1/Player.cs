using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Player: Character
    {
        public char character = (char)1;
        public Player()
        {
            name = "Player";
            healthMax = 100;
            health = healthMax;
            lives = 3;
            x = 5;
            y = 5;
            spawn[0] = 5;
            spawn[1] = 5;
            type = "player";
        }

        public void Update(char[,] map)
        { 
            bool isWalkable;
            bool isEnemy;
            char destination = ' ';

            ConsoleKeyInfo choice = Console.ReadKey(true);

            Console.SetCursorPosition(x + 2, y + 1);
            char tile = map[y, x];

            Map.DrawTile(tile);

            switch (choice.Key)
            {
                case ConsoleKey.Escape:
                    Program.gameOver = true;
                    break;

                case ConsoleKey.W:
                    destination = map[y - 1, x];
                    isWalkable = Map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        y--;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.S:
                    destination = map[y + 1, x];
                    isWalkable = Map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        y++;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.A:
                    destination = map[y, x - 1];
                    isWalkable = Map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        x--;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case ConsoleKey.D:
                    destination = map[y, x + 1];
                    isWalkable = Map.CheckWalkable(destination);

                    if (isWalkable == true)
                    {
                        x++;
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
        }

        public void ShowHud()
        {
            string hudHealth = health.ToString();
            Console.SetCursorPosition(4, 40);
            Console.WriteLine(name.PadRight(name.Length + 1) + ": Health: " + hudHealth.PadRight(5) + "Lives: " + lives + " " + x + "," + y);
        }
    }
}
