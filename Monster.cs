using System;
using System.Collections.Generic;

namespace game
{
    public class Monster
    {
        public string Name {get; set;}
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public string avatar;
        private int _health;

        public Monster(string name)
        {
            Name = name;         
            avatar = "";
            _health = 20;
        }

        public virtual int Attack(Human target)
        {
            int dmg = 5;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Name + " hit " + target.Name + " for " + dmg);
            Console.ForegroundColor = ConsoleColor.White;
            return target.Health;
        }
        public virtual int DragonAttack(Human target)
        {
            int dmg = 50;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Name + " hit " + target.Name + " for " + dmg);
            Console.ForegroundColor = ConsoleColor.White;
            return target.Health;
        }
    }

    
}