using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Cell
    {
        public Location Location;
        public bool Empty;
        public bool IsShot;
        public char View = '+';
        public Cell(bool empty)
        {
            Empty = empty;
            View = '=';
        }
        public Cell(Location loc)
        {
            Location = loc;
            Empty = true;
            View = ' ';
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
