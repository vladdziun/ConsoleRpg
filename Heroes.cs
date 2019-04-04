using System;
using System.Collections.Generic;

namespace game
{
    public class Human
    {
        public string Name {get; set;}
        public int Strength {get; set;}
        public int Intellect;
        public int Stamina;
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public string avatar;
        public int level;
        private int _health;

        public List<string> inventory;


        public Human(string name)
        {
            Name = name;
            level = 1;
            Strength = 3;
            Intellect = 3;
            Stamina = 3;
            inventory = new List<string>();
            
            avatar = "";
            _health = 100;
        }

        public virtual int Attack(Monster target)
        {
            int dmg = Strength * 5;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine(Name + " hit " + target.Name + " for " + dmg);
            Console.ForegroundColor = ConsoleColor.White;
            return target.Health;
        }
    }

    public class Mage : Human
    {
        public Mage(string name) : base(name)
        {
            Name = name;
            Intellect = 25;
            Health = 50;
            inventory.Add("Staff");
            avatar = @"             _,-'|
           ,-'._  |
 .||,      |####\ |
\.`',/     \####| |
= ,. =      |###| |
/ || \    ,-'\#/,'`.
  ||     ,'   `,,. `.
  ,|____,' , ,;' \| |
 (3|\    _/|/'   _| |
  ||/,-''  | >-'' _,\\
  ||'      ==\ ,-'  ,'
  ||       |  V \ ,|
  ||       |    |` |
  ||       |    |   \
  ||       |    \    \
  ||       |     |    \
  ||       |      \_,-'
  ||       |___,,--')_\
  ||         |_|   ccc/
  ||        ccc/
  ||                MAGE";
            
        }

        public override int Attack(Monster target)
        {
            int dmg = Strength * 5;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You hit " + target.Name + " for " + dmg);
            Health += dmg;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You heal yourselft for " + dmg);
            Console.ForegroundColor = ConsoleColor.White;

            return target.Health;
        }

        public void Heal(Human target)
        {
            target.Health += 10;
            Console.WriteLine("You healed " + target.Name);
        }
    }


    public class Rogue : Human
    {
        public Rogue(string name) : base(name)
        {
            Name = name;
            Stamina = 175;
            inventory.Add("Dagger");
            avatar = @"             _,._
           ,'   ,`-.
|.        /     |\  `.
\ \      (  ,-,-` ). `-._ __
 \ \      \|\,'     `\  /'  `\
  \ \      ` |, ,  /  \ \     \
   \ \         `,_/`, /\,`-.__/`.
    \ \            | ` /    /    `-._
     \\\           `-/'    /         `-.
      \\`/ _______,-/_   /'             \
     ---'`|       |`  ),' `---.  ,       |
      \..-`--..___|_,/          /       /
                 |    |`,-,...,/      ,'     
                 \    | |_|   /     ,' __  r-'',
                  |___|/  |, /  __ /-''  `'`)  |  
               _,-'   ||__\ /,-' /     _,.--|  (
            .-'       )   `(_   / _,.-'  ,-' _,/
             `-------'       `--''       `''' ROGUE";
            

        }

        public override int Attack(Monster target)
        {
            Random rand = new Random();
            int random = rand.Next(11);
            int dmg = Stamina * 5;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You hit " + target.Name + " for " + dmg);
            if (random > 3)
            {   
                target.Health -= 10;
                Console.WriteLine("You dealt 10 additional damage");
            }
            Console.ForegroundColor = ConsoleColor.White;


            return target.Health;
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            Console.WriteLine("You stole 5 health form " + target.Name);
        }
    }
    public class Paladin : Human
    {
        public Paladin(string name) : base(name)
        {
            Name = name;
            Health = 200;
            inventory.Add("Hammer");
            avatar = @"  ,   A           {}
 / \, | ,        .--.
|    =|= >      /.--.\
 \ /` | `       |====|
  `   |         |`::`|
      |     .-;`\..../`;_.-^-._
     /\\/  /  |...::..|`   :   `|
     |:'\ |   /'''::''|   .:.   |
      \ /\;-,/\   ::  |..:::::..|
      |\ <` >  >._::_.| ':::::' |
      | `""`  /   ^^  |   ':'   |
      |       |       \    :    /
      |       |        \   :   /
      |       |___/\___|`-.:.-`
      |        \_ || _/    `
      |        <_ >< _>
      |        |  ||  |
      |        |  ||  |
      |       _\.:||:./_
      |      /____/\____\ PALADIN";
            

        }

        public override int Attack(Monster target)
        {
            base.Attack(target);
            string zebbie = Console.ReadLine();
            Console.WriteLine(zebbie);

            if (target.Health < 50)
            {
                target.Health = 0;
                Console.WriteLine("You killed " + target.Name);
            }
            return target.Health;
        }

        public void Meditate()
        {
            Health = 200;
            Console.WriteLine(Name + " restored hull health!");

        }
    }
}
