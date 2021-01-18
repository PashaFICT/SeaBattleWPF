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
                  if (prevLoc/10 == 9)
                  {
                    return prevLoc - 10;
                  }
                 else if (prevLoc / 10 == 0)
                  {
                    return prevLoc + 10;
                  }
                  else
                {
                    if (IsUp == 1)
                    {
                        prevLoc += 10;
                    }
                    else
                    {
                        prevLoc -= 10;
                    }
                }
                return prevLoc;
              }
            else
            {
                if (prevLoc % 10 == 9)
                {
                    return prevLoc - 1;
                }
                else if (prevLoc % 10 == 0)
                {
                    return prevLoc + 1;
                }
                else
                {
                    if (IsUp == 1)
                    {
                        prevLoc += 1;
                    }
                    else
                    {
                        prevLoc -= 1;
                    }
                }
                return prevLoc;

            }
        }
    }
}
