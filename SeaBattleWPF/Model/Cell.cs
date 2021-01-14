using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.ViewModel;

namespace SeaBattleWPF.Model
{
    public class Cell : BaseViewModel
    {
        public Location Location;
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
        public Cell(Location loc)
        {
            Location = loc;
            Empty = true;
            _view = ConfigGame.CellEmpty;
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
        public ShipCell(Location loc) : base(loc)
        {

        }
        public bool IsWarning;
    }
}
