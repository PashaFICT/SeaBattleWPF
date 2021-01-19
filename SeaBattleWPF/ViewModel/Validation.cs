using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.ViewModel
{
    public class Validation
    {
        public bool ValidationAddShip(Player player, int loc, int isVertical, Ship ship)
        {
             if (loc >= 100 || loc < 0)
             {
                 return false;
             }
            if ((ship.Cells.Count() + loc % 10) >  10)
            {
                return false;
            }
            foreach (Cell cell in ship.Cells)
            {
                try
                {
                    if (player.Field.FieldArray[cell.number].Empty == false)// || player.Field.FieldArray[cell.number - 11].Empty == false)
                    {
                        return false;
                    }
                    if(player.Field.FieldArray[cell.number - 11].Empty == false)
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            //foreach (Cell cell in ship.Cells)
            //{
            //    try
            //    {
            //        if (player.Field.FieldArray[cell.number - 11].Empty == false)
            //        {
            //            return false;
            //        }
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}
            //try
            //{
            //    if (player.Field.FieldArray[loc - 11].Empty == false || player.Field.FieldArray[loc - 10].Empty == false || player.Field.FieldArray[loc - 9].Empty == false || player.Field.FieldArray[loc - 1].Empty == false || player.Field.FieldArray[loc + 1].Empty == false || player.Field.FieldArray[loc + 9].Empty == false || player.Field.FieldArray[loc + 10].Empty == false || player.Field.FieldArray[loc + 11].Empty == false)
            //    {
            //        return false;
            //    }
            //}
            //catch
            //{
            //return false;
            //}

            if (isVertical == 1)
            {
                 if (loc + ship.Cells.Count*10 > 100 )
                 {
                     return false;
                 }
            }
            else
            {
                if (loc / 10 == (loc + ship.Cells.Count) / 10)
                {
                    return false;
                }
            }
            try
            {
                for (int j = 0; j < ship.Cells.Count; j++)
                {
                    for (int i = 0; i < player.Field.FieldArray.Count; i++)
                    {
                            if (loc == i && isVertical == 0)
                            {
                                if (!player.Field.FieldArray[loc].Empty)
                                {
                                    return false;
                                }
                            }
                            else if (loc == i + j && isVertical == 1)
                            {
                                if (!player.Field.FieldArray[loc].Empty)
                                {
                                    return false;
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
    }
}
