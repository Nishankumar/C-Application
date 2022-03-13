using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.MyException;
using Spizy.HotelModule;
using Spizy.MenuModule;

namespace Spizy.UserModule
{
    class UserBO
    {        
        //string[] userArray;
        public static bool blnLoopControl = true;     
        static RestaurentBO restaurentBO = new RestaurentBO();
        UserDataValidation dataValidation = new UserDataValidation();
        string strAdminEmail = "appadmin@gmail.com";
        public void LoginUser(string strUserEmail,string strUserPassword,List<User> userList)
        {
            try
            {                              

            if(userList.Count > 0 && userList != null)
                {
                    foreach (User user in userList)
                    {
                        if (user.User_mail.Equals(strUserEmail) && user.User_pass.Equals(strUserPassword))
                        {
                            Console.WriteLine("Login Successfull...");
                            if (user.User_mail.Equals(strAdminEmail))
                            {
                                Console.WriteLine();
                                AdminMenu.AdminMenuPage();
                            }
                            else
                            {
                                Console.WriteLine();
                                UserMenu.UserMenuPage();
                            }                            
                        }                                       
                    }
                }
            else
            {
                    Console.WriteLine("Invalid User Details");
                    Console.Write("Enter valid User Details or Create New Account");
                    MainMenu.RegisterOrLogin();
            }                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MainMenu.RegisterOrLogin();
            }
        }
        public string CheckExistingUser(string strUserEmail,List<User> userList)
        {
            try {

                foreach (User user in userList)
                {
                    if (user.User_mail.Equals(strUserEmail))
                    {
                        Console.WriteLine("This Email Address Exist \nRegister Valid Details");
                        MainMenu.RegisterOrLogin();
                    }                  
                }               

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MainMenu.RegisterOrLogin();
            }

            return strUserEmail;
        }
       public User CreateUserNew(string userName, string userMail,string password)
        {
            User newuser = new User(userName,userMail,password);

            return newuser;
        }
        /*public void CreateUser(string userDetails,List<User> userList)
        {
            try {
                userArray = userDetails.Split(",");
                userArray = ArrayNumberOfValueException.checkSizeOfArray(userArray);
                //checkExistingUser(dataValidation.validateEmail(userArray[1]));
              //  userList.Add(new User(userArray[0], CheckExistingUser(userArray[1], userList), userArray[2], userArray[3]));
                Console.WriteLine("Your User Account Has Been Created Successfully!...");
                Console.WriteLine();
                MainMenu.RegisterOrLogin();

            }
            catch (ArrayNumberOfValueException e)
            {
                Console.WriteLine("ArrayNumberOfValueException: {0}", e.Message);
                Console.WriteLine();
                Console.WriteLine("Enter User Input Properly");
                MainMenu.RegisterOrLogin();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("Enter User Input Properly");
                MainMenu.RegisterOrLogin();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Enter User Input Properly");
                MainMenu.RegisterOrLogin();
            }            
        }*/                          
    }
}
