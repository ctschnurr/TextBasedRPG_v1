using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Enemy: Character
    {
        public char character = (char)2;

        public Enemy()
        {
            Random rand = new Random();
            int roll = rand.Next(1, 6);
            
            switch (roll)
            {
                case 1:
                    name = "Larry";
                    break;

                case 2:
                    name = "Stan";
                    break;

                case 3:
                    name = "Bucky";
                    break;

                case 4:
                    name = "George";
                    break;

                case 5:
                    name = "Steve";
                    break;
            }

            type = "npc";
            health = 100;
            healthMax = 10;
            lives = 100;
            x = rand.Next(25, 30);
            y = rand.Next(25, 30);
        }

        public void ShowHud()
        {
            string hudHealth = health.ToString();
            Console.SetCursorPosition(42, 40);
            Console.WriteLine("║ " + name.PadRight(name.Length + 1) + ": Health: " + hudHealth.PadRight(5));
        }

        public void Chase(int playerX, int playerY, char[,] map)
        {
            bool isWalkable = true;
            char destination = ' ';

            Console.SetCursorPosition(x + 2, y + 1);
            char tile = map[y, x];

            Map.DrawTile(tile);

            string choice = "blank";

            if (playerY == y)
            {
                if (playerX > x)
                {
                    choice = "right";
                }

                if (playerX < x)
                {
                    choice = "left";
                }
            }

            if (playerX == x)
            {
                if (playerY > y)
                {
                    choice = "down";
                }
                if (playerY < y)
                {
                    choice = "up";
                }
            }

            else
            {
                Random rnd = new Random();
                int walk = rnd.Next(1, 3);

                switch (walk)
                {
                    case 1:
                        {
                            if (playerX > x)
                            {
                                choice = "right";
                            }

                            if (playerX < x)
                            {
                                choice = "left";
                            }
                            break;
                        }

                    case 2:
                        {
                            if (playerY > y)
                            {
                                choice = "down";
                            }

                            if (playerY < y)
                            {
                                choice = "up";
                            }
                            break;
                        }
                }
            }

            switch (choice)
            {
                case "left":
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

                case "right":
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

                case "up":
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

                case "down":
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
            }             
        }

        public bool CheckPosition(int pX, int pY)
        {
            bool goTime = false;

            if (x == pX && y == pY)
            {
                goTime = true;
            }

            return goTime;
        }
    }
}
