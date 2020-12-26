using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattleWPF
{
    public class Validation
    {
        public bool ValidationAddShip(Player game, Location loc, int isVertical, Ship ship)
        {
            if (loc.X >= ConfigGame.str1.Length || loc.Y >= ConfigGame.str2.Length || loc.X < 0 || loc.Y < 0)
            {
                return false;
            }

            if (isVertical == 1)
            {
                if (loc.X + ship.Cells.Count >= ConfigGame.str1.Length)
                {
                    return false;
                }
            }
            else
            {
                if (loc.Y + ship.Cells.Count >= ConfigGame.str2.Length)
                {
                    return false;
                }
            }
            try
            {
                for (int j = 0; j < ship.Cells.Count; j++)
                {
                    for (int i = 0; i < game.Field.FieldArray.Length; i++)
                    {
                        for (int k = 0; k < game.Field.FieldArray[i].Length; k++)
                        {
                            if (loc.X == k + j && loc.Y == i && isVertical == 0)
                            {
                                if (!game.Field.FieldArray[loc.X][loc.Y].Empty)
                                {
                                    return false;
                                }
                            }
                            else if (loc.X == k && loc.Y == i + j && isVertical == 1)
                            {
                                if (!game.Field.FieldArray[loc.X][loc.Y].Empty)
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public bool TryValidationGame(Field field, List<Ship> ships)
        {
            bool valid = true;
            return valid;
        }
    }
}
