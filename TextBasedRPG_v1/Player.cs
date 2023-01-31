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
        public int x = 5;
        public int y = 5;
        
        public Player()
        {
            name = "Player";
        }

        public void Update()
        { 
            bool isWalkable;
            bool isEnemy;
            char destination = ' ';

            ConsoleKeyInfo choice = Console.ReadKey(true);

            Console.SetCursorPosition(x + 2, y + 1);
            char tile = Map.map[y, x];

            Map.DrawTile(tile);

            switch (choice.Key)
            {
                case ConsoleKey.Escape:
                    Program.gameOver = true;
                    break;

                case ConsoleKey.W:
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

                case ConsoleKey.S:
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

                case ConsoleKey.A:
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

                case ConsoleKey.D:
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
    }
}
