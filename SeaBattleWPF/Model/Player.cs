using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Player
    {
        public Field Field;
        public bool IsWin;

        public List<Ship> Ships;
        public List<Ship> ShipsInField;
        public Guid GuidPlayerId;
        public Player(Field field, bool iswin, List<Ship> ships)
        {
            Field = field;
            IsWin = iswin;
            Ships = ships;
            GuidPlayerId = Guid.NewGuid();
            ShipsInField = new List<Ship>();
        }

        public void WriteShip()
        {
           // Console.WriteLine(' ');
            int i = 0;
            foreach (Ship ship in Ships)
            {
                if (ShipsInField.Any(p => p.ShipId == ship.ShipId))
                {
                    i++;
                    continue;
                }
                i++;
                ship.NumberInConsole = i;
               // Console.WriteLine(" - " + i.ToString());
            }
        }

        public void AddNumeric()
        {
            int i = 0;
            foreach (Ship ship in Ships)
            {
                i++;
                ship.NumberInConsole = i;
            }
        }

        /*public void FieldView(Player game, bool isClear = true, bool isSecret = false)
        {
            if (isClear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < game.Field.FieldArray.Length; i++)
            {
                Console.Write(ConfigGame.str1[i].ToString() + ' ');
            }
            Console.WriteLine();
            for (int k = 0; k < game.Field.FieldArray.Length; k++)
            {
                if (k < 9)
                {
                    Console.Write(ConfigGame.str2[k].ToString() + ' ');
                }
                else
                {
                    Console.Write(ConfigGame.str2[k].ToString());
                }
                for (int j = 0; j < game.Field.FieldArray[k].Length; j++)
                {
                    if (game.Field.FieldArray[k][j].IsShot)
                    {
                        Ship ship = LocationIsShip(game, j, k);
                        if (ship != null)
                        {
                            game.Field.FieldArray[k][j].View = 'X';
                        }
                        else
                        {
                            game.Field.FieldArray[k][j].View = '+';
                        }
                    }

                    else if (game.Field.FieldArray[k][j].Empty || isSecret)
                    {
                        game.Field.FieldArray[k][j].View = '-';
                    }
                    Console.Write(game.Field.FieldArray[k][j].View + " ");
                }
                Console.WriteLine();
            }
        }*/

        public Ship LocationIsShip(Player game, int i)
        {
            Ship ship = null;
            foreach (Ship item in game.ShipsInField)
            {
                int count = 0;
                foreach (ShipCell cell in item.Cells)
                {
                    //if (cell.number == null)
                    //{
                    //    continue;
                    //}
                    if (cell.number == i)
                    {
                        item.IsWarning = true;
                        cell.IsWarning = true;
                        ship = item;

                    }
                    if (cell.IsWarning)
                    {
                        count++;
                    }
                }

                if (count == item.Cells.Count)
                {
                    item.IsLive = false;
                }
            }

            return ship;
        }



    }
}
