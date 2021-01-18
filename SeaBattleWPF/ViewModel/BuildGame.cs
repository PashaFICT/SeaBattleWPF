using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SeaBattleWPF.Model;
namespace SeaBattleWPF.ViewModel
{
    public class BuildGame : IBuildGame
    {
        public Ship BuildShipOfOne()
        {
            Ship ship = new Ship(new List<ShipCell>() { new ShipCell(false) });
            return ship;
        }
        public Ship BuildShipOfTwo()
        {
            Ship ship = new Ship(new List<ShipCell>() { new ShipCell(false), new ShipCell(false) });
            return ship;
        }
        public Ship BuildShipOfThree()
        {
            Ship ship = new Ship(new List<ShipCell>() { new ShipCell(false), new ShipCell(false), new ShipCell(false) });
            return ship;
        }
        public Ship BuildShipOfFour()
        {
            Ship ship = new Ship(new List<ShipCell>() { new ShipCell(false), new ShipCell(false), new ShipCell(false), new ShipCell(false) });
            return ship;
        }
        
        public ObservableCollection<Cell> Cells;

        public Field BuildField()
        {
            Cells = new ObservableCollection<Cell>();
            for (int i = 0; i < 100; i++)
            {
                Cells.Add(new Cell(true, i));
            }
            Field field = new Field(Cells);
            return field;
        }
    }
}
