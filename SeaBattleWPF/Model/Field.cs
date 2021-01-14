using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeaBattleWPF.Model
{
    public class Field
    {
        public ObservableCollection<Cell> FieldArray;
        public Field(ObservableCollection<Cell> fieldArray)
        {
            FieldArray = fieldArray;
        }
    }
}
