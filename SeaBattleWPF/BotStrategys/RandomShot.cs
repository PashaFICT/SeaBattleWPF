using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.BotStrategys
{
    public class RandomShot : BotStrategy
    {
        Random _random = new Random();
        public override int Shot(int prevLoc)
        {
            // return new Location(_random.Next(0, ConfigGame.str1.Length), _random.Next(0, ConfigGame.str2.Length));
            //Location loc = new Location();
            int loc = 0;
            return loc;
        }
    }

    public class PlayerConsoleShot : BotStrategy
    {
        public override int Shot(int prevLoc)
        {
            //Location loc = null;
            int loc = 0;
           // string line;
            //while (true)
            //{
                //line = Console.ReadLine();

               // if (string.IsNullOrEmpty(line))
               // {
               //     continue;
               // }

               //// string[] input = line.Split(' ');

               // if (input.Length >= 2)
               // {
               //     loc = new Location(input[0], input[1]);
               //     break;
               // }
          //  }

            return loc;
        }
    }
}
