using System;
using System.Collections.Generic;
using System.Threading;

namespace game
{
    class Game
    {

        public string choice = "";
        public bool isValidchoice = false;
        public static Human player;
        public bool isDead = false;
        public static bool isTeleported = false;
        public static string name = "";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;


            string welcome = @"  ___  _      _                                            _   _                _                 
 / _ \| |    | |                                          | | | |              (_)                
/ /_\ \ | ___| |__   ___ _ __ ___  _   _    __ _ _ __   __| | | |     ___  __ _ _  ___  _ __  ___ 
|  _  | |/ __| '_ \ / _ \ '_ ` _ \| | | |  / _` | '_ \ / _` | | |    / _ \/ _` | |/ _ \| '_ \/ __|
| | | | | (__| | | |  __/ | | | | | |_| | | (_| | | | | (_| | | |___|  __/ (_| | | (_) | | | \__ \
\_| |_/_|\___|_| |_|\___|_| |_| |_|\__, |  \__,_|_| |_|\__,_| \_____/\___|\__, |_|\___/|_| |_|___/
                                    __/ |                                  __/ |                  
                                   |___/                                  |___/                   ";
            Console.WriteLine(welcome);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose a name for your hero: \n");
            name = Console.ReadLine().ToUpper();
            Thread.Sleep(1000);
            Console.WriteLine("Greetings " + name);
            Thread.Sleep(1500);
            Console.WriteLine("Choose a role for your hero (type: 'Mage'/'Rogue'/'Paladin'): ");

            bool isRole = false;

            while (!isRole)
            {
             string role = Console.ReadLine();

                if (role == "Mage" || role == "mage")
                {
                    player = new Mage(name);
                    Console.WriteLine(player.avatar);
                    isRole = true;

                }
                else if (role == "Rogue" || role == "rogue")
                {
                    player = new Rogue(name);
                    Console.WriteLine(player.avatar);
                    isRole = true;

                }
                else if (role == "Paladin" || role == "paladin")
                {
                    player = new Paladin(name);
                    Console.WriteLine(player.avatar);
                    isRole = true;
                }
                else
                {
                    Console.WriteLine("Choose the right role!");
                }
            }

            while (isRole)
            {
                Game game = new Game();
                Thread.Sleep(2000);
                Console.WriteLine("WELCOME TO THE WORLD OF LEGIONS AND ALCHEMY, " + name);
                game.LevelOne();
                isRole = false;
            }

            //call it here

            while(isTeleported)
            {   
                Game game = new Game();
                game.LevelTwo();
            }
        }


        public void LevelOne()
        {
            Monster spider = new Monster("SPIDER");
            spider.avatar = @"           ____                      ,
          /---.'.__             ____//
               '--.\           /.---'
          _______  \\         //
        /.------.\  \|      .'/  ______
       //  ___  \ \ ||/|\  //  _/_----.\__
      |/  /.-.\  \ \:|< >|// _/.'..\   '--'
         //   \'. | \'.|.'/ /_/ /  \\
        //     \ \_\/' ' ~\-'.-'    \\
       //       '-._| :H: |'-.__     \\
      //           (/'==='\)'-._\     ||
      ||                        \\    \|
      ||                         \\    '
      |/                          \\
                                   ||
                                   ||
                                   \\";

            Console.WriteLine("You have entered Stormwood Forest.\n");
            Thread.Sleep(2000);
            Console.WriteLine("You are walking through the forest...\n");
            Thread.Sleep(3000);
            Console.WriteLine(spider.avatar);
            Thread.Sleep(3000);
            Console.WriteLine("You have been suddenly attacked by a SPIDER\n");
            Console.WriteLine("You have to make a choice 'RUN AWAY' or 'FIGHT': \n");
            choice = Console.ReadLine().ToUpper();

            while (!isValidchoice)
            {
                if (choice == "RUN AWAY")
                {
                    Console.WriteLine(player.Name.ToUpper() + " says: 'Time to GTFO!'\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("SPIDER says: 'YOU COWARD!!!'\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("SPIDER starts to chase you!\n");
                    Thread.Sleep(3000);
                    Console.WriteLine("SPIDER has caught you in his web. You have lost 5 health\n");
                    player.Health -= 5;
                    Console.WriteLine("Time to fight now, you can't run away! \n Type 'FIGHT'");

                    choice = Console.ReadLine().ToUpper();
                    if (choice == "FIGHT")
                    {
                        while (spider.Health > 0 && player.Health > 0) 
                        {
                            Console.WriteLine("You attack spider!");
                            player.Attack(spider);
                            Thread.Sleep(3000);
                            spider.Attack(player);
                            Console.WriteLine("player: " + player.Health);
                            Console.WriteLine("spider: " + spider.Health);
                            Console.WriteLine("**************************");
                            
                        }
                        if(spider.Health < 0)
                        {
                            Console.WriteLine("SPIDER says: 'OUUUUWUWWUW!!!'");
                            Thread.Sleep(3000);
                            Console.WriteLine("You have killed " + spider.Name);
                            Thread.Sleep(2000);
                            Console.WriteLine("Do you want to loot SPIDER? (yes/no)");
                            choice = Console.ReadLine().ToUpper();

                            if(choice == "YES")
                            {
                            Console.WriteLine("Looting spider...");
                            Thread.Sleep(4000);
                            
                            Console.WriteLine("You received loot: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[Thunderfury Blessed Blade of the Windseeker]");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(4000);
                            Console.WriteLine(@"                P
             P /\  P
            /\|  |/\
         [] ||_/\_|| []
         ||_||____||_||
         ||____[]____||
        {::     \__    }
    ___  \v:    .''  _V ___
   (      \_      __/  --  )_
  (__---    |::\ :/  ---     )
     (       \::\/  ----- ___)
      (______  \/     _____)");
      Thread.Sleep(3000);
             Console.WriteLine("You have been teleported to THE KINGDOM OF COMPTON");
             isTeleported = true;


                            }
                            else
                            {
                                                            Console.WriteLine(@"                P
             P /\  P
            /\|  |/\
         [] ||_/\_|| []
         ||_||____||_||
         ||____[]____||
        {::     \__    }
    ___  \v:    .''  _V ___
   (      \_      __/  --  )_
  (__---    |::\ :/  ---     )
     (       \::\/  ----- ___)
      (______  \/     _____)");
      Thread.Sleep(3000);
                                Console.WriteLine("You have been teleported to THE KINGDOM OF COMPTON");
                                isTeleported = true;
                            }
                            
                        }
                        if(player.Health < 0)
                        {
                            Console.WriteLine("You died. SPIDER killed you");
                        }
                        isValidchoice = true;
                    }
                }
                else if (choice == "FIGHT")
                {
                    Console.WriteLine("You attack spider first time!");
                    isValidchoice = true;
                    break;

                }
            }
        }
        public void LevelTwo()
        {
            Thread.Sleep(3000);
            Console.WriteLine("THE KING OF COMPTON has appeared\n");
            Thread.Sleep(3000);
            Console.WriteLine(@"                 ,#####,
                 #_   _#
                 |a` `a|
                 |  u  |
                 \  =  /
                 |\___/|
        ___ ____/:     :\____ ___
      .'   `.-===-\   /-===-.`   '.
     /      .-''''-.-''''-.      \
    /'             =:=             '\
  .'  ' .:    o   -=:=-   o    :. '  `.
  (.'   /'. '-.....-'-.....-' .'\   '.)
  /' ._/   '.     --:--     .''   \_. '\
 |  .'|      ''.  ---:---  .'      |'.  |
 |  : |       |  ---:---  |       | :  |
  \ : |       |_____._____|       | : /
  /   (       |----|------|       )   \
 /... .|      |    |      |      |. ...\
|::::/''     /     |       \     ''\::::|
'''''       /'    .L_      `\       ''''
           /'-.,__/` `\__..-'\
          ;      /     \      ;
          :     /       \     |
          |    /         \.   |
          |`../           |  ,/
          ( _ )           |  _)
          |   |           |   |
          |___|           \___|
          :===|            |==|
           \  /            |__|
           /\/\           /'''`8.__
           |oo|           \__.//___)
           |==|
           \__/");
           Thread.Sleep(3000);
            Console.WriteLine("THE KING says: 'Thank you for saving our Kingdom from big ass spider!'\n" );
            Thread.Sleep(3000);
            Console.WriteLine("THE KING says: 'What can THE KINGDOM OF COMPTON do to repay you?'\n" );
            Thread.Sleep(3000);
            Console.WriteLine("Option 1 - 'Do you have any potions on you?'\n" );
            Thread.Sleep(3000);
            Console.WriteLine("Option 2 - 'Do you want some potions?'\n" );
            Thread.Sleep(3000);
            Console.WriteLine("Option 3 - 'Does anyone over here want any potions?'\n" );
            Console.WriteLine("Type either '1', '2', or '3'\n" );

            choice = Console.ReadLine();

            Console.WriteLine("The KING is dissapointed with your questions and has decided to kill you!\n");
            Thread.Sleep(3000);
            Console.WriteLine("The KING has called forth his MALICIOUS DRAGON and has attacked you!!\n");
            Thread.Sleep(4000);
            Console.WriteLine(@"                            ==(W{==========-      /===-                        
                              ||  (.--.)         /===-_---~~~~~~~~~------____  
                              | \_,|**|,__      |===-~___                _,-' `
                 -==\\        `\ ' `--'   ),    `//~\\   ~~~~`---.___.-~~      
             ______-==|        /`\_. .__/\ \    | |  \\           _-~`         
       __--~~~  ,-/-==\\      (   | .  |~~~~|   | |   `\        ,'             
    _-~       /'    |  \\     )__/==0==-\<>/   / /      \      /               
  .'        /       |   \\      /~\___/~~\/  /' /        \   /'                
 /  ____  /         |    \`\.__/-~~   \  |_/'  /          \/'                  
/-'~    ~~~~~---__  |     ~-/~         ( )   /'        _--~`                   
                  \_|      /        _) | ;  ),   __--~~                        
                    '~~--_/      _-~/- |/ \   '-~ \                            
                   {\__--_/}    / \\_>-|)<__\      \                           
                   /'   (_/  _-~  | |__>--<__|      |                          
                  |   _/) )-~     | |__>--<__|      |                          
                  / /~ ,_/       / /__>---<__/      |                          
                 o-o _//        /-~_>---<__-~      /                           
                 (^(~          /~_>---<__-      _-~                            
                ,/|           /__>--<__/     _-~                               
             ,//('(          |__>--<__|     /                  .----_          
            ( ( '))          |__>--<__|    |                 /' _---_~\        
         `-)) )) (           |__>--<__|    |               /'  /     ~\`\      
        ,/,'//( (             \__>--<__\    \            /'  //        ||      
      ,( ( ((, ))              ~-__>--<_~-_  ~--____---~' _/'/        /'       
    `~/  )` ) ,/|                 ~-_~>--<_/-__       __-~ _/                  
  ._-~//( )/ )) `                    ~~-'_/_/ /~~~~~~~__--~                    
   ;'( ')/ ,)(                              ~~~~~~~~~~                         
  ' ') '( (/                                                                   
    '   '  `");

            Monster dragon = new Monster("DRAGON");
            dragon.Health = 1000;
            Thread.Sleep(2500);
             while (dragon.Health > 0 && player.Health > 0) 
            {
                Console.WriteLine("You attacked the DRAGON!");
                player.Attack(dragon);
                Thread.Sleep(3000);
                dragon.DragonAttack(player);
                Console.WriteLine("Player Health: " + player.Health);
                Console.WriteLine("Dragon Health: " + dragon.Health);
                Console.WriteLine("**************************");

                if(player.Health < 0)
                {
                    Console.WriteLine(name + " DIED");
                    Thread.Sleep(2000);
                    Console.WriteLine("The MALICIOUS DRAGON t-bags his kill...");
                    Console.ReadLine();
                }
                
            }

            
            

        }
    }
}