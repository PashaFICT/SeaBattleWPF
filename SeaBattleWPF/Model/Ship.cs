using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
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
        public void Write()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    foreach (Cell cell in Cells)
                    {
                        if (cell.Location.X == i && cell.Location.Y == k)
                        {
                            Console.Write("=");
                        }
                    }

                }
            }
        }

    }
}
