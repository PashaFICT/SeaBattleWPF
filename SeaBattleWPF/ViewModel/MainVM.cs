using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using SeaBattleWPF.Model;

namespace SeaBattleWPF.ViewModel
{
   public class MainVM : INotifyPropertyChanged
    {
        GameProcess gameProcess = new GameProcess();
        Game game = new Game();
        Location location = new Location();
        int count = 0;
        public void Init()
        {
            game = gameProcess.Init();
            gameProcess.AddRandomShip(game.PlayerFirst);
            gameProcess.StartGame(game);
        }
        public void ViewF(Player player, Grid gridField, bool isSecret=false)
        {
            for (int i = 0; i < player.Field.FieldArray.Length; i++)
            {
                for (int j=0; j< player.Field.FieldArray[i].Length; j++)
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
        public int Index(int i, int j)
        {
            int index=0;
            if(i == 0)
            {
                index = j + 1;
            }
            index = i * 10 + j + 1;
            return index;
        }
        public Location IndexLoc(int num)
        {
            location.X = num / 10;
            location.Y = num % 10;
            return location;
        }
        public Ship LocationIsShip(Player game, int k, int j)
        {
            Ship ship = null;
            foreach (Ship item in game.ShipsInField)
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
        }
        public static Grid GridField;
        public static Grid GridField_Bot;

        private RelayCommand addCommand;
        public RelayCommand Start
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Init();
                      ViewF(game.PlayerFirst, GridField);
                      ViewF(game.PlayerSecond, GridField_Bot);
                      MessageBox.Show("Start");
                  }));
            }

        }


        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
                      int num = Convert.ToInt32(obj)-1;
                      IndexLoc(num);
                      game = gameProcess.Move(game, location);
                      ViewF(game.PlayerFirst, GridField);
                      if (game.PlayerFirst.IsWin || game.PlayerSecond.IsWin)
                      {
                          MessageBox.Show("Win " + step);
                      }
                  }
                 ));
            }
        }
        private RelayCommand shot;
        public RelayCommand Shot
        {
            get
            {
                return shot ??
                  (shot = new RelayCommand(obj =>
                  {
                      string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
                      int num = Convert.ToInt32(obj) - 1;
                      IndexLoc(num);
                      game = gameProcess.Move(game, location);
                      ViewF(game.PlayerSecond, GridField_Bot);
                      if (game.PlayerFirst.IsWin || game.PlayerSecond.IsWin)
                      {
                          MessageBox.Show("Win " + step);
                      }
                  }
                 ));
            }
        }

        public int SelectedPhone
        {
            get { return count; }
            set
            {
                OnPropertyChanged("SelectedPhone");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
