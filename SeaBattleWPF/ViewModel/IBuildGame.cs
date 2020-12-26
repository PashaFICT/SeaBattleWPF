using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
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
