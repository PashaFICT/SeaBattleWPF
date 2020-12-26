using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
{
    public class RandomShot : BotStrategy
    {
        Random _random = new Random();
        public override Location Shot(Location prevLoc)
        {
            return new Location(_random.Next(0, ConfigGame.str1.Length), _random.Next(0, ConfigGame.str2.Length));
        }
    }

    public class PlayerConsoleShot : BotStrategy
    {
        public override Location Shot(Location prevLoc)
        {
            Location loc = null;
            string line;
            while (true)
            {
                line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                string[] input = line.Split(' ');

                if (input.Length >= 2)
                {
                    loc = new Location(input[0], input[1]);
                    break;
                }
            }

            return loc;
        }
    }
}
