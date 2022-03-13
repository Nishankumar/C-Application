using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.MyException
{
    class InvalidRestaurentTypeException : Exception
    {
        public InvalidRestaurentTypeException(string message) : base(message)
        {

        }

        public static string restaurenTypeCheck(string type)
        {
            if(!(type.Equals("Non-Veg") || type.Equals("Veg") || type.Equals("Both") 
                || type.Equals("NON-VEG") || type.Equals("VEG") || type.Equals("BOTH")))
            {
                throw (new InvalidRestaurentTypeException("Entered Restaurent Type Is Not Valid"));
            }
            else
            {
                return type;
            }
        }
    }
}
