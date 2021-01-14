using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.BotStrategys
{
    public abstract class BotStrategy
    {
        public abstract int Shot(int prevLoc);
    }
}
