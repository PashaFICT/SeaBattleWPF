using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Player
    {
        public Field Field;
        public bool IsWin;

        public List<Ship> Ships;
        public List<Ship> ShipsInField;
        public Guid GuidPlayerId;
        public Player(Field field, bool iswin, List<Ship> ships)
        {
            Field = field;
            IsWin = iswin;
            Ships = ships;
            GuidPlayerId = Guid.NewGuid();
            ShipsInField = new List<Ship>();
        }

        public void WriteShip()
        {
            int i = 0;
            foreach (Ship ship in Ships)
            {
                if (ShipsInField.Any(p => p.ShipId == ship.ShipId))
                {
                    i++;
                    continue;
                }
                i++;
                ship.NumberInConsole = i;
            }
        }

        public void AddNumeric()
        {
            int i = 0;
            foreach (Ship ship in Ships)
            {
                i++;
                ship.NumberInConsole = i;
            }
        }

        public Ship LocationIsShip(Player player, int i)
        {
            Ship ship = null;
            foreach (Ship item in player.ShipsInField)
            {
                int count = 0;
                foreach (ShipCell cell in item.Cells)
                {
                    if (cell.number == i)
                    {
                        item.IsWarning = true;
                        cell.IsWarning = true;
                        ship = item;
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
