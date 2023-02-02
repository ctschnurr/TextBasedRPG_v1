using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            int height = getMap.worldMap.GetLength(0) + 2;
            int width = getMap.worldMap.GetLength(1) + 2;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;

            MainMenu();

            while (gameOver == false)
            {
                if (redraw)
                {
                    getMap.DrawMap(getMap.worldMap);
                    player.ShowHud();
                    redraw = false;
                }

                player.Draw(player.x + 2, player.y + 1, player.character);
                enemy.Draw(enemy.x + 2, enemy.y + 1, enemy.character);
                player.Update(getMap.worldMap);
                //BattleCheck(player, enemy);
                Battle.BattleCheck(player, enemy);
                enemy.Chase(player.x, player.y, getMap.worldMap);
                Battle.BattleCheck(enemy, player);
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

        static void BattleCheck(Character first, Character second)
        {
            if (first.x == second.x && first.y == second.y)
            {
                getMap.DrawMap(getMap.blank_frame);
                player.ShowHud();
                enemy.ShowHud();

                int next = 2;
                Console.SetCursorPosition(4, next);
                Console.WriteLine(first.name + " started a fight! " + first.name + " goes first!");
                next += 2;
                Console.ReadKey(true);

                Random rand = new Random();
                bool battleOver = false;
                int swing;
                int damage;
                int turn = 1;
                Character loser = null;

                while (battleOver == false)
                {

                    if (turn == 1)
                    {
                        swing = rand.Next(1, 4);
                        if (swing == 1)
                        {
                            Console.SetCursorPosition(4, next);
                            Console.WriteLine(first.name + " missed!");
                            next += 2;
                            turn = 2;

                            Console.ReadKey(true);

                            if (next > 36)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                player.ShowHud();
                                enemy.ShowHud();
                                next = 2;
                            }
                        }

                        else
                        {
                            damage = rand.Next(1, 11);

                            Console.SetCursorPosition(4, next);
                            Console.WriteLine(first.name + " hit " + second.name + " for " + damage + " damage!");
                            next += 2;
                            turn = 2;

                            second.health -= damage;
                            player.ShowHud();
                            enemy.ShowHud();

                            Console.ReadKey(true);

                            if (next > 36)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                player.ShowHud();
                                enemy.ShowHud();
                                next = 2;
                            }

                            if (second.health <= 0)
                            {
                                Console.SetCursorPosition(4, next);
                                Console.WriteLine(second.name + " has DIED!");
                                next += 2;
                                Console.ReadKey(true);
                                battleOver = true;
                                redraw = true;
                                loser = second;
                            }
                        }
                    }

                    else if (turn == 2)
                    {
                        swing = rand.Next(1, 4);
                        if (swing == 1)
                        {
                            Console.SetCursorPosition(4, next);
                            Console.WriteLine(second.name + " missed!");
                            next += 2;
                            turn = 1;

                            Console.ReadKey(true);

                            if (next > 36)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                player.ShowHud();
                                enemy.ShowHud();
                                next = 2;
                            }
                        }

                        else
                        {
                            damage = rand.Next(1, 11);

                            Console.SetCursorPosition(4, next);
                            Console.WriteLine(second.name + " hit " + first.name + " for " + damage + " damage!");
                            next += 2;
                            turn = 1;
                            first.health -= damage;

                            player.ShowHud();
                            enemy.ShowHud();
                            Console.ReadKey(true);


                            if (next > 36)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                player.ShowHud();
                                enemy.ShowHud();
                                next = 2;
                            }

                            if (first.health <= 0)
                            {
                                Console.SetCursorPosition(4, next);
                                Console.WriteLine(first.name + " has DIED!");
                                next += 2;
                                Console.ReadKey(true);
                                battleOver = true;
                                redraw = true;
                                loser = first;
                            }
                        }
                    }                                
                }

                if (loser == player)
                {
                    Console.SetCursorPosition(4, next);
                    Console.WriteLine("I guess you suck, but I'll restore and respawn you!");
                    Console.ReadKey(true);
                    loser.lives -= 1;
                    loser.x = loser.spawn[0];
                    loser.y = loser.spawn[1];
                }

                else
                {
                    enemy = new Enemy();
                }

            }
        }

    }
}
