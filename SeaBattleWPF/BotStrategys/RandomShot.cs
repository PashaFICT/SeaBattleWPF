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
            return _random.Next(0, 100);
        }
    }
}
