using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Program
    {
        static public Map getMap = new Map();
        static public Player player = new Player();
        static public Enemy enemy = new Enemy();
        static public bool redraw = true;
        public static bool gameOver = false;

        public static int height;
        public static int width;

        static void Main(string[] args)
        {
            height = getMap.worldMap.GetLength(0) + 2;
            width = getMap.worldMap.GetLength(1) + 2;

            RefreshWindow();
            Console.CursorVisible = false;

            MainMenu();

            while (gameOver == false)
            {
                if (redraw)
                {
                    getMap.DrawMap(getMap.worldMap);
                    redraw = false;
                }

                player.Draw(player.x + 2, player.y + 1, player.character);
                player.ShowHud();
                enemy.Draw(enemy.x + 2, enemy.y + 1, enemy.character);
                player.Update(getMap.worldMap);
                RefreshWindow();
                HealCheck(player);
                Battle.BattleCheck(player, enemy);
                enemy.Chase(player.x, player.y, getMap.worldMap);
                Battle.BattleCheck(enemy, player);
            }

        }

        static void RefreshWindow()
        {
            if (Console.WindowHeight != height || Console.WindowWidth != width)
            {
                Console.SetWindowSize(width, height);
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                redraw = true;
            }
        }

        static void HealCheck(Character player)
        {
            if (player.x == 44 && player.y == 19)
            {
                player.health = player.healthMax;
            }
        }
        static void MainMenu()
        {
            int next = 3;

            RefreshWindow();
            getMap.DrawMap(getMap.blank_frame);
            Console.SetCursorPosition(4, next);
            Console.WriteLine("WELCOME TO THE GRAVEYARD!");
            next += 2;

            Console.SetCursorPosition(4, next);
            Console.WriteLine("Please choose from the following options:");

            Console.SetCursorPosition(4, 7);
            Console.WriteLine("(N)ew Game");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("(Q)uit Game");

            Console.SetCursorPosition(4, 40);
            Console.WriteLine("By Chris Schnurr");

            ConsoleKeyInfo choice = Console.ReadKey(true);

            switch (choice.Key)
            {
                default:
                    RefreshWindow();
                    getMap.DrawMap(getMap.blank_frame);
                    next = 5;
                    Console.SetCursorPosition(8, next);
                    Console.WriteLine("¡Θ¡");
                    next++;
                    Console.SetCursorPosition(8, next);
                    Console.WriteLine("╤═╤     Visit the shrine to heal!");
                    next++;
                    Console.SetCursorPosition(8, next);
                    Console.WriteLine("┴▀┴");
                    next += 2;
                    Console.SetCursorPosition(9, next);
                    Console.WriteLine((char)2 + "     Watch out for the Undead!");
                    next += 2;
                    Console.SetCursorPosition(8, next);
                    Console.WriteLine("Press escape from the map to quit!");
                    next += 6;

                    Console.SetCursorPosition(4, 40);
                    Console.WriteLine("By Chris Schnurr");

                    Console.SetCursorPosition(4, next);
                    Console.Write("Before we begin, please enter your name: ");
                    player.name = Console.ReadLine();

                    break;

                case ConsoleKey.Q:
                    gameOver = true;
                    break;
            }
        }

    }
}
