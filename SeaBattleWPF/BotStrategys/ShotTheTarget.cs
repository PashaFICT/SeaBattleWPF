using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.BotStrategys
{
    public class ShotTheTarget : BotStrategy
    {
        Random _random = new Random();
        public override Location Shot(Location prevLoc)
        {
            int isVertical = _random.Next(0, 2);
            int IsUp = _random.Next(0, 2);

            if (isVertical == 1)
            {
                if (prevLoc.X == ConfigGame.str1.Length - 1)
                {
                    return new Location(prevLoc.X - 1, prevLoc.Y);
                }
                if (prevLoc.X == 0)
                {
                    return new Location(1, prevLoc.Y);
                }

                return new Location(IsUp == 1 ? prevLoc.X + 1 : prevLoc.X - 1, prevLoc.Y);
            }
            else
            {
                if (prevLoc.Y == ConfigGame.str2.Length - 1)
                {
                    return new Location(prevLoc.X, prevLoc.Y - 1);
                }
                if (prevLoc.Y == 0)
                {
                    return new Location(prevLoc.X, 1);
                }

                return new Location(prevLoc.X, IsUp == 1 ? prevLoc.Y + 1 : prevLoc.Y - 1);
            }
        }
    }
}
