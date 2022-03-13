using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.MyException;
using Spizy.UserModule;
using Spizy.HotelModule;
using Spizy.OrderModule;

namespace Spizy.MenuModule
{
    class UserMenu
    {
        //static RestaurentBO restaurentBO = new RestaurentBO();
        static List<Orders> listOfOrders = new List<Orders>();        
        static OrderBO orderBO = new OrderBO();
        static int intOrderId = 1;

        public static void UserMenuPage()
        {            
            try
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("                  USER MENU                    ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Press 1->Order \n2->Log Out");
                MainMenu.strChoiceReader = Console.ReadLine();
                MainMenu.intChoice = InputNotStringCharException.check(MainMenu.strChoiceReader);
                switch (MainMenu.intChoice)
                {
                    case 1:
                        orderBO.GetOrders(listOfOrders,intOrderId);
                        intOrderId++;
                        break;
                    case 2:                        
                        Console.WriteLine("Log Out Successfully!...");
                        MainMenu.RegisterOrLogin();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice");
                        UserMenuPage();
                        break;
                }                
            }
            catch(InputNotStringCharException e)
            {
                Console.WriteLine("InputNotStringCharException: {0}", e.Message);
                UserMenuPage();
            }         
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                UserMenuPage();
            }
        }
    }
}
