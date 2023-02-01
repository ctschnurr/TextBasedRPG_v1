using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Program
    {
        static Map getMap = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static bool redraw = true;
        public static bool gameOver = false;

        static void Main(string[] args)
        {
            int height = getMap.worldMap.GetLength(0) + 2;
            int width = getMap.worldMap.GetLength(1) + 2;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
                        
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
                BattleCheck(player, enemy);
                enemy.Chase(player.x, player.y, getMap.worldMap);
                BattleCheck(enemy, player);
            }

        }

        static void BattleCheck(Character first, Character second)
        {
            if (first.x == second.x && first.y == second.y)
            {
                getMap.DrawMap(getMap.blank_frame);
                player.ShowHud();

                int next = 3;
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

                            if (next > 38)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                next = 3;
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

                            Console.ReadKey(true);

                            if (next > 38)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                next = 3;
                            }

                            if (second.health < 0)
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

                            if (next > 38)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                next = 3;
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
                            Console.ReadKey(true);


                            if (next > 38)
                            {
                                Console.Clear();
                                getMap.DrawMap(getMap.blank_frame);
                                next = 3;
                            }

                            if (first.health < 0)
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

                loser.x = loser.spawn[0];
                loser.y = loser.spawn[1];

                if (loser == player)
                {
                    Console.SetCursorPosition(4, next);
                    Console.WriteLine("I guess you suck, but I'll restore and respawn you!");
                    Console.ReadKey(true);
                    loser.lives -= 1;
                }

                loser.health = loser.healthMax;

            }
        }

    }
}
