using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Field
    {
        public Cell[][] FieldArray;
        public Field(Cell[][] fieldarray)
        {
            FieldArray = fieldarray;
        }
        public static readonly string[] str1 = { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "к" };
        public static readonly string[] str2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
    }
}
