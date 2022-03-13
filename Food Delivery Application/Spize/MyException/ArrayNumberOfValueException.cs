using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.MyException
{
    class ArrayNumberOfValueException : Exception
    {
        public ArrayNumberOfValueException(string message) : base(message)
        {

        }

        public static string[] checkSizeOfArray(string[] s)
        {
            if(s.Length < 4)
            {
                throw (new ArrayNumberOfValueException("User input missing one or more details"));
            }else if (s.Length > 4)
            {
                throw (new ArrayNumberOfValueException("User input exceeds their limit of details"));
            }
            else
            {
                return s;
            }
        }
    }
}
