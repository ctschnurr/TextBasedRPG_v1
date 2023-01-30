using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_v1
{
    internal class Character
    {
        public int health = 10;
        public int strength = 10;
        public string name;
        public void Draw(int x, int y, char character)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(character);
        }
    }
}
