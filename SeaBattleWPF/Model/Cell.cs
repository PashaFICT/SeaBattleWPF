using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.ViewModel;

namespace SeaBattleWPF.Model
{
    public class Cell : BaseViewModel
    {
        public bool Empty;
        public bool IsShot;
        private string _view;
        public int number;
        public Cell(bool empty)
        {
            Empty = empty;
            _view = ConfigGame.CellEmpty;
        }
        public Cell(bool empty, int num)
        {
            Empty = empty;
            _view = ConfigGame.CellEmpty;
            number = num;
        }
        public string View
        {
            get { return _view; }
            set { _view = value; OnPropertyChanged("View"); }
        }
    }

    public class ShipCell : Cell
    {
        public ShipCell(bool empty) : base(empty)
        {

        }
        public bool IsWarning;
    }
}
