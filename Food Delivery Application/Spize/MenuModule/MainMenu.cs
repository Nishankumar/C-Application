using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.UserModule;
using Spizy.MyException;


namespace Spizy.MenuModule
{
    class MainMenu
    {
        public static string strChoiceReader;
        public static int intChoice;
        static string strUserEmail, strUserPassword,strUserName;
        //static string strUserDetails;
        static List<User> userList = new List<User>();
        public static void RegisterOrLogin()
        {
            UserBO userBO = new UserBO();
            UserDataValidation dataValidation = new UserDataValidation();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("                    MENU                       ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Press 1->Login  \n2->Register \n3->Exit");
            try
            {
                strChoiceReader = Console.ReadLine();
                intChoice = InputNotStringCharException.check(strChoiceReader);

                switch (intChoice)
                {
                    case 1:
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("                SIGN IN ACCOUNT                ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Enter your email:");
                        strUserEmail = Console.ReadLine();
                        Console.WriteLine("Enter your password:");
                        strUserPassword = Console.ReadLine();
                        userBO.LoginUser(strUserEmail,strUserPassword,userList);
                        break;
                    case 2:                        
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine("              Register User Account            ");
                            Console.WriteLine("-----------------------------------------------");
                            //Console.WriteLine("Input Format => Name,Email,Password,User_Type(Admin or User)");
                            Console.WriteLine("Enter User Details:");
                            Console.WriteLine("Enter your user name:");
                            strUserName = Console.ReadLine();
                            Console.WriteLine("Enter your email:");
                            strUserEmail = Console.ReadLine();
                            Console.WriteLine("Enter your password:");
                            strUserPassword = Console.ReadLine();
                            User user = userBO.CreateUserNew(strUserName, strUserEmail, strUserPassword);
                            if (user != null)
                            {                                
                                userList.Add(user);
                                Console.WriteLine("Your User Account Has Been Created Successfully!...");
                                RegisterOrLogin();
                            }
                            else
                            {
                                Console.WriteLine("Your User Account Has Not Been Created...");
                                Console.WriteLine("Try Again!");
                                RegisterOrLogin();
                            }                                                                                            
                        break;
                    case 3:
                        Console.WriteLine("Thank You For Choosing Spizy");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        RegisterOrLogin();
                        break;
                }
            }
            catch (InputNotStringCharException e)
            {
                Console.WriteLine("InputNotStringCharException: {0}", e.Message);
                RegisterOrLogin();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                RegisterOrLogin();
            }
        }
    }
}
