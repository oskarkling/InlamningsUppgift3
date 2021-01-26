using System;
using InlamningsUppgift3.Enemies;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InlamningsUppgift3 {
    public class Animations {

        /// <summary>
        /// A fun explosion for a player with God Mode true.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        public void ExplosionGodMode(Player player, Monster monster) {
            //step 0
            Console.Clear();
            Console.WriteLine($"\n{player.Name}: Omae Wa Mou Shindeiru");
            Console.WriteLine($"\n{monster.Name}: NANI?\n");

            Console.WriteLine(@"





              
              ´ _ `´
_______________(_)_______________
");
            Thread.Sleep(500);

            //step 1
            Console.Clear();
            Console.WriteLine($"\n{player.Name}: Omae Wa Mou Shindeiru");
            Console.WriteLine($"\n{monster.Name}: NANI?\n");

            Console.WriteLine(@"





               ___
              /   \
_____________/_ __ \_____________
");
            Thread.Sleep(500);

            //step 2
            Console.Clear();
            Console.WriteLine($"\n{player.Name}: Omae Wa Mou Shindeiru");
            Console.WriteLine($"\n{monster.Name}: NANI?\n");

            Console.WriteLine(@"


        `__´---``´´´-_
        (_   (_ . _) _) ,
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________
");
            Thread.Sleep(500);

            //step 3
            Console.Clear();
            Console.WriteLine($"\n{player.Name}: Omae Wa Mou Shindeiru");
            Console.WriteLine($"\n{monster.Name}: NANI?\n");


            Console.WriteLine(@"
          _ ._  _ , _ ._
        (_ ' ( `  )_  .__)
      ( (  (    )   `)  ) _)
     (__ (_   (_ . _) _) ,__)
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________
");
            Thread.Sleep(1000);
        }
    }
}
