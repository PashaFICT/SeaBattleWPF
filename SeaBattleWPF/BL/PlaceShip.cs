using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.BL
{
    class PlaceShip
    {
        //public void PlaceShipRandom(Player player)
        //{
        //    //for (int i = 0; i < player.Field.FieldArray.Length; i++)
        //    //{
        //    for (int j = 0; j < player.Field.FieldArray[i].Length; j++)
        //    {
        //        if (player.Field.FieldArray[i][j].IsShot)
        //        {
        //            Ship ship = LocationIsShip(player, j, i);
        //            if (ship != null)
        //            {
        //                player.Field.FieldArray[i][j].View = ConfigGame.CellWarning;
        //            }
        //            else
        //            {
        //                player.Field.FieldArray[i][j].View = ConfigGame.CellShot;
        //            }
        //        }

        //        else if (player.Field.FieldArray[i][j].Empty || ConfigGame.isSecret)
        //        {
        //            player.Field.FieldArray[i][j].View = ConfigGame.CellEmpty;
        //        }
        //        //foreach (Button but in gridField.Children)
        //        //{
        //        //    if (but.CommandParameter.ToString() == Index(i, j).ToString())
        //        //    {
        //        //        but.Content = player.Field.FieldArray[i][j].View;
        //        //    }

        //        //}
        //    }
        //    // }
        //}
        public void PlaceShipRandom(Player player)
        {
            //for (int i = 0; i < player.Field.FieldArray.Length; i++)
            //{
                foreach (var cell in player.Field.FieldArray)
                {
                    if (player.Field.FieldArray[cell.number].IsShot)
                    {
                        Ship ship = LocationIsShip(player, cell.number);
                        if (ship != null)
                        {
                            player.Field.FieldArray[cell.number].View = ConfigGame.CellWarning;
                        }
                        else
                        {
                            player.Field.FieldArray[cell.number].View = ConfigGame.CellShot;
                        }
                    }

                    else if (player.Field.FieldArray[cell.number].Empty || ConfigGame.isSecret)
                    {
                        player.Field.FieldArray[cell.number].View = ConfigGame.CellEmpty;
                    }
                    //foreach (Button but in gridField.Children)
                    //{
                    //    if (but.CommandParameter.ToString() == Index(i, j).ToString())
                    //    {
                    //        but.Content = player.Field.FieldArray[i][j].View;
                    //    }

                    //}
                }
           // }
        }
        //public Ship LocationIsShip(Player player, int k, int j)
        //{
        //    Ship ship = null;
        //    foreach (Ship item in player.ShipsInField)
        //    {
        //        int count = 0;
        //        foreach (ShipCell cell in item.Cells)
        //        {
        //            if (cell.Location == null)
        //            {
        //                continue;
        //            }
        //            if (cell.Location.X == j && cell.Location.Y == k)
        //            {
        //                item.IsWarning = true;
        //                cell.IsWarning = true;
        //                ship = item;

        //            }
        //            if (cell.IsWarning)
        //            {
        //                count++;
        //            }
        //        }

        //        if (count == item.Cells.Count)
        //        {
        //            item.IsLive = false;
        //        }
        //    }

        //    return ship;
        //}
        public Ship LocationIsShip(Player player, int k)
        {
            Ship ship = null;
            foreach (Ship item in player.ShipsInField)
            {
                int count = 0;
                foreach (ShipCell cell in item.Cells)
                {
                    if (cell.Location == null)
                    {
                        continue;
                    }
                    if (cell.number == k)
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
