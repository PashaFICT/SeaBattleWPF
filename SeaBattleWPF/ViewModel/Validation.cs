using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.ViewModel
{
    public class Validation
    {
        public bool ValidationAddShip(Player game, int loc, int isVertical, Ship ship)
        {
             if (loc >= 100 || loc < 0)
             {
                 return false;
             }
            if ((ship.Cells.Count() + loc % 10) >  10)
            {
                return false;
            }
            //foreach (Cell cells in ship.Cells)
            //{
                try
                {
                    if (game.Field.FieldArray[loc - 11].Empty == false || game.Field.FieldArray[loc - 10].Empty == false || game.Field.FieldArray[loc - 9].Empty == false || game.Field.FieldArray[loc - 1].Empty == false || game.Field.FieldArray[loc].Empty == false || game.Field.FieldArray[loc + 1].Empty == false || game.Field.FieldArray[loc + 9].Empty == false || game.Field.FieldArray[loc + 10].Empty == false || game.Field.FieldArray[loc + 11].Empty == false)
                    {
                        return false;
                    }
                }
                catch
                {

                }
           // }
            

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
                    for (int i = 0; i < game.Field.FieldArray.Count; i++)
                    {
                        //for (int k = 0; k < game.Field.FieldArray[i].Length; k++)
                        //{
                            if (loc == i && isVertical == 0)
                            {
                                if (!game.Field.FieldArray[loc].Empty)
                                {
                                    return false;
                                }
                            }
                            else if (loc == i + j && isVertical == 1)
                            {
                                if (!game.Field.FieldArray[loc].Empty)
                                {
                                    return false;
                                }
                            }

                       // }
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
