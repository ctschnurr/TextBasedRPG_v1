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
        public int x = 25;
        public int y = 25;

        public void Update()
        {
            name = "Enemy";
            bool isWalkable;
            char destination = ' ';

            Random rnd = new Random();
            int choice = rnd.Next(1, 5);

            Console.SetCursorPosition(x + 2, y + 1);
            char tile = Map.map[y, x];

            Map.DrawTile(tile);

            switch (choice)
            {
                case 1:
                    destination = Map.map[y - 1, x];
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

                case 2:
                    destination = Map.map[y + 1, x];
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

                case 3:
                    destination = Map.map[y, x - 1];
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

                case 4:
                    destination = Map.map[y, x + 1];
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
