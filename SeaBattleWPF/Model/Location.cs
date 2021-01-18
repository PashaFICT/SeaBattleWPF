using SeaBattleWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Location
    {
        public int X;
        public int Y;
        public Location(string x, string y)
        {
            if (!int.TryParse(x, out X) || !int.TryParse(y, out Y))
            {
                throw new InputInvalidParametrException("Location parametr is not correct");
            }

        }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"{X} - {Y}";
        }
    }
}
