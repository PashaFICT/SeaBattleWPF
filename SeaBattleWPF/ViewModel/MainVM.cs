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
    }
}
