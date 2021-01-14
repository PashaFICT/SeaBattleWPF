using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SeaBattleWPF.View
{
    class FieldView
    {
        //public void CreateField(Grid GridField, Grid GridField_Bot)
        //{
        //    int count = 1;
        //    for (int i = 0; i < ConfigGame.Height; i++)
        //    {
        //        for (int j = 0; j < ConfigGame.Width; j++)
        //        {
        //            Button button = new Button();
        //            button.CommandParameter = count.ToString();
        //            button.IsEnabled = false;
        //            GridField.Children.Add(button);
        //            Grid.SetRow(button, i);
        //            Grid.SetColumn(button, j);

        //            Button button_bot = new Button();
        //            button_bot.SetBinding(Button.CommandProperty, new Binding("Shot"));
        //            button_bot.CommandParameter = count.ToString();
        //            GridField_Bot.Children.Add(button_bot);
        //            Grid.SetRow(button_bot, i);
        //            Grid.SetColumn(button_bot, j);
        //            count++;
        //        }
        //    }
        //}
        /*  public void CreateF(Player player, Grid gridField, bool isSecret = false)
          {
              for (int i = 0; i < player.Field.FieldArray.Length; i++)
              {
                  for (int j = 0; j < player.Field.FieldArray[i].Length; j++)
                  {
                      if (player.Field.FieldArray[i][j].IsShot)
                      {
                          Ship ship = LocationIsShip(player, j, i);
                          if (ship != null)
                          {
                              player.Field.FieldArray[i][j].View = 'X';
                          }
                          else
                          {
                              player.Field.FieldArray[i][j].View = '+';
                          }
                      }

                      else if (player.Field.FieldArray[i][j].Empty || isSecret)
                      {
                          player.Field.FieldArray[i][j].View = '0';
                      }
                      foreach (Button but in gridField.Children)
                      {
                          if (but.CommandParameter.ToString() == Index(i, j).ToString())
                          {
                              but.Content = player.Field.FieldArray[i][j].View;
                          }

                      }
                  }


              }
          }
          public Ship LocationIsShip(Player player, int k, int j)
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
                      if (cell.Location.X == j && cell.Location.Y == k)
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
          }*/
    }
}
