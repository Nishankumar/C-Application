using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.MyException
{
    class InputNotStringCharException : Exception
    {
        public InputNotStringCharException(string message) : base(message)
        {
          
        }

        public static int check(string s)
        {
            int i;
            bool b = int.TryParse(s, out i);
            if (!b)
            {
                throw(new InputNotStringCharException("Input should be int value not string or char"));
            }
            else
            {
                return i;
            }
        }
    }
}
