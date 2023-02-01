using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Battle
    {
        public static bool battleOver;
        public static Character loser;
        public static int next;
        public static void BattleCheck(Character first, Character second)
        {
            Random rand = new Random();
            battleOver = true;
            next = 2;
            int swing;
            int damage;
            int turn = 1;

            Character loser = null;

            if (first.x == second.x && first.y == second.y)
            {
                battleOver = false;
                ReDraw();
            }

            Console.SetCursorPosition(4, next);
            Console.WriteLine(first.name + " started a fight! " + first.name + " goes first!");
            next += 2;

            while (battleOver == false)
            {                
                battleOver = Attack(first, second);

                if (battleOver == false)
                {
                    battleOver = Attack(second, first);
                }                
            }


        }

        static void ReDraw()
        {
            Program.getMap.DrawMap(Program.getMap.blank_frame);
            Program.player.ShowHud();
            Program.enemy.ShowHud();
        }

        static bool Attack(Character attacker, Character victim)
        {
            Random rand = new Random();
            int swing = rand.Next(1, 4);
            int damage;

            if (swing == 1)
            {
                Console.SetCursorPosition(4, next);
                Console.WriteLine(attacker.name + " missed!");
                next += 2;

                Console.ReadKey(true);

                if (next > 36)
                {
                    ReDraw();
                    next = 2;
                }

                return false;
            }

            else
            {
                damage = rand.Next(1, 11);

                Console.SetCursorPosition(4, next);
                Console.WriteLine(attacker.name + " hit " + victim.name + " for " + damage + " damage!");
                next += 2;

                victim.health -= damage;
                Program.player.ShowHud();
                Program.enemy.ShowHud();

                Console.ReadKey(true);

                if (next > 36)
                {
                    Console.Clear();
                    Program.getMap.DrawMap(Program.getMap.blank_frame);
                    next = 2;
                }

                if (victim.health <= 0)
                {
                    Console.SetCursorPosition(4, next);
                    Console.WriteLine(victim.name + " has DIED!");
                    next += 2;
                    Console.ReadKey(true);
                    battleOver = true;
                    Program.redraw = true;
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }
         
        
    }
}
