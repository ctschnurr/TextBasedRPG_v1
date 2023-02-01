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
            name = "Enemy";
            health = 50;
            healthMax = 10;
            lives = 100;
            x = 25;
            y = 25;

            spawn[0] = 25;
            spawn[1] = 25;
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
