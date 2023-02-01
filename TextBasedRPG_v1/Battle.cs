using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Battle
    {
        public static void BattleCheck(Character first, Character second)
        {
            Random rand = new Random();
            bool battleOver = true;
            int next = 2;
            int swing;
            int damage;
            int turn = 1;

            Character loser = null;

            if (first.x == second.x && first.y == second.y)
            {
                battleOver = false;
                ReDraw();
            }

            while (battleOver == false)
            {
                Console.SetCursorPosition(4, next);
                Console.WriteLine(first.name + " started a fight! " + first.name + " goes first!");
                next += 2;

                if (first.type == "npc" && turn > 1)
                {
                    swing = rand.Next(1, 4);
                    if (swing == 1)
                    {
                        Console.SetCursorPosition(4, next);
                        Console.WriteLine(first.name + " missed!");
                        next += 2;
                        turn++;

                        Console.ReadKey(true);

                        if (next > 36)
                        {
                            ReDraw();
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
                        Program.player.ShowHud();
                        Program.enemy.ShowHud();

                        Console.ReadKey(true);

                        if (next > 36)
                        {
                            Console.Clear();
                            Program.getMap.DrawMap(Program.getMap.blank_frame);
                            next = 2;
                        }

                        if (second.health <= 0)
                        {
                            Console.SetCursorPosition(4, next);
                            Console.WriteLine(second.name + " has DIED!");
                            next += 2;
                            Console.ReadKey(true);
                            battleOver = true;
                            Program.redraw = true;
                            loser = second;
                        }
                    }

                    Console.SetCursorPosition(4, 38);
                    Console.Write("(A)ttack - ");
                    ConsoleKeyInfo choice = Console.ReadKey(true);

                } 
                


            }
        }

        static void ReDraw()
        {
            Program.getMap.DrawMap(Program.getMap.blank_frame);
            Program.player.ShowHud();
            Program.enemy.ShowHud();
        }

        
            
        
    }
}
