using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF.Exceptions
{
    public class InputInvalidParametrException : System.Exception
    {
        public InputInvalidParametrException(string message) : base(message)
        {

        }
    }
}
