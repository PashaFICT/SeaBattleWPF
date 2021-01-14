using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
{
    public static class ConfigGame
    {
        public static int CountOfOne = 4;
        public static int CountOfTwo = 3;
        public static int CountOfThree = 2;
        public static int CountOfFour = 1;
        public static readonly bool isSecret = true;
        public static readonly string CellEmpty = "*";
        public static readonly string CellWarning = "X";
        public static readonly string CellShot = "+";
        public static readonly string CellShip = "|";
    }
}
