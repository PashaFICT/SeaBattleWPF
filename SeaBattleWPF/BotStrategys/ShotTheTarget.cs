using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.BotStrategys
{
    public class ShotTheTarget : BotStrategy
    {
        Random _random = new Random();
        public override int Shot(int prevLoc)
        {
            int isVertical = _random.Next(0, 2);
            int IsUp = _random.Next(0, 2);

              if (isVertical == 1)
              {
                  if (prevLoc == 9)
                  {
                    //return new Location(prevLoc - 1, prevLoc);
                    return prevLoc-1;
                  }
                  if (prevLoc == 0)
                  {
                    //return new Location(1, prevLoc);
                    return prevLoc;
                  }

                return 5;//new Location(IsUp == 1 ? prevLoc.X + 1 : prevLoc.X - 1, prevLoc.Y);
              }
              //else
              //{
              //    if (prevLoc == 9)
              //    {
              //        return new Location(prevLoc.X, prevLoc.Y - 1);
              //    }
              //    if (prevLoc == 0)
              //    {
              //        return new Location(prevLoc.X, 1);
              //    }

              //    return new Location(prevLoc.X, IsUp == 1 ? prevLoc.Y + 1 : prevLoc.Y - 1);
              //}
            return 5;//new Location(prevLoc.X, IsUp == 1 ? prevLoc.Y + 1 : prevLoc.Y - 1);
        }
    }
}
