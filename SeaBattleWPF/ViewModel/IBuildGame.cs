using System;
using System.Collections.Generic;
using System.Text;
using SeaBattleWPF.Model;
namespace SeaBattleWPF.ViewModel
{
    public interface IBuildGame
    {
        Ship BuildShipOfOne();
        Ship BuildShipOfTwo();
        Ship BuildShipOfThree();
        Ship BuildShipOfFour();
        Field BuildField();
    }
}
