using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Ship
    {
        public List<ShipCell> Cells;
        public bool IsLive;
        public Guid ShipId;
        public bool IsWarning;
        public int NumberInConsole;

        public Ship(List<ShipCell> cells)
        {
            Cells = cells;
            IsWarning = false;
            IsLive = true;
            ShipId = Guid.NewGuid();
        }
    }
}
