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
   public class MainVM : BaseViewModel
    {
        GameProcess gameProcess = new GameProcess();
        Game game = new Game();
        public MainVM()
        {
            //game = gameProcess.Init();
            //gameProcess.StartGame(game);
            //CellsUser = game.PlayerFirst.Field.FieldArray;
            //CellsBot = game.PlayerSecond.Field.FieldArray;
        }
        private ObservableCollection<Cell> _cellsUser;
        public ObservableCollection<Cell> CellsUser
        {
            get { return _cellsUser; }
            set { _cellsUser = game.PlayerFirst.Field.FieldArray; OnPropertyChanged("CellsUser"); }
        }
        private Cell _cellUser;
        public Cell CellUser
        {
            get { return _cellUser; }
            set { _cellUser = value; ShotCell(value); OnPropertyChanged("CellUser"); }
        }
        private ObservableCollection<Cell> _cellsBot;
        public ObservableCollection<Cell> CellsBot
        {
            get { return _cellsBot; }
            set { _cellsBot = game.PlayerSecond.Field.FieldArray; OnPropertyChanged("CellsBot"); }
        }
        private Cell _cellBot;
        public Cell CellBot
        {
            get { return _cellBot; }
            set { _cellBot = value; ShotCell(value); OnPropertyChanged("CellBot"); }
        }
        private void ShotCell(Cell cell)
        {
            game = gameProcess.Move(game, cell);
            if (game.PlayerFirst.IsWin || game.PlayerSecond.IsWin)
            {
                MessageBox.Show(game.PlayerFirst.IsWin ? "Player is win" : "Bot is win");
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
        }
        private RelayCommand addCommand;
        public RelayCommand Start
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      game = gameProcess.Init();
                      gameProcess.StartGame(game);
                      CellsUser = game.PlayerFirst.Field.FieldArray;
                      CellsBot = game.PlayerSecond.Field.FieldArray;
                  }));
            }

        }
        //private RelayCommand shot;
        //public RelayCommand Shot
        //{
        //    get
        //    {
        //        return shot ??
        //          (shot = new RelayCommand(obj1 =>
        //          {
        //              string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
        //              int num = Convert.ToInt32(obj1) - 1;
        //              if (game.NextStep == NextStep.PlayerSecond)
        //              {
        //                  game.NextStep = NextStep.PlayerFirst;
        //              }
        //            else
        //            {
        //                  game.NextStep = NextStep.PlayerSecond;
        //            }
        //              if (game.PlayerFirst.IsWin || game.PlayerSecond.IsWin)
        //              {
        //                  MessageBox.Show("Win " + step);
        //              }
        //          }
        //         ));
        //    }
        //}

    }
}
