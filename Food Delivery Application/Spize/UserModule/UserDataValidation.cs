using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Spizy.UserModule
{
    class UserDataValidation
    {
        string strTempPassword;
        bool blnRegexVerifier;
        public string ValidatePassword(string password)
        {
            do
            {
                Regex regex = new Regex("^[A-Z][a-z0-9][_@$%!]{8,15}$");              
                blnRegexVerifier = regex.IsMatch(password);
                   
                  
                        Console.WriteLine("Invalid Password Format");
                        Console.WriteLine("Password should 1.start be Capital letter 2.one @,#,$,! and 3.more than 8 & less than 15 character:");
                        Console.WriteLine("Enter Valid Password");
                        password = Console.ReadLine();
                        do
                        {
                             Console.WriteLine("Re-enter the password:");
                             this.strTempPassword = Console.ReadLine();
                        if (this.strTempPassword.Equals(password))
                        {
                            UserBO.blnLoopControl = false;                            
                        }                      

                    } while (UserBO.blnLoopControl);

                    UserBO.blnLoopControl = true;                
            } while (!blnRegexVerifier);


            return password;            

        }

        public string ValidateEmail(string email)
        {            
            do
            {
                Regex regex = new Regex("^[(^_A-Z0-9_!#)a-z0-9]@[a-z].[com|co.in]$");
                blnRegexVerifier = regex.IsMatch(email);
                if (!blnRegexVerifier)
                {
                    Console.WriteLine("Invalid Password Format");
                    Console.WriteLine("Password should 1.start be Capital letter 2.one @,#,$,! and 3.more than 8 & less than 15 character:");
                    Console.WriteLine("Enter Valid Password");
                    email = Console.ReadLine();
                }                
            } while (!blnRegexVerifier);

            return email;
        }
    }
}
