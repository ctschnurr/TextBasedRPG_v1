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
            if (player.x == 44 && player.y == 21)
            {
                player.health = player.healthMax;
            }
        }
        static void MainMenu()
        {
            getMap.DrawMap(getMap.blank_frame);
            Console.SetCursorPosition(4, 3);
            Console.WriteLine("Welcome to my Text Based RPG Prototype!");

            Console.SetCursorPosition(4, 5);
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
                    getMap.DrawMap(getMap.blank_frame);
                    Console.SetCursorPosition(4, 40);
                    Console.WriteLine("By Chris Schnurr");

                    Console.SetCursorPosition(4, 3);
                    Console.Write("Please enter your name: ");
                    player.name = Console.ReadLine();

                    break;

                case ConsoleKey.Q:
                    gameOver = true;
                    break;
            }
        }

    }
}
