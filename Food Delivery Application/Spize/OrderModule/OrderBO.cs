using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.MenuModule;
using Spizy.MyException;
using Spizy.HotelModule;
using Spizy.FoodModule;
using Spizy.UserModule;

namespace Spizy.OrderModule
{
    class OrderBO
    {
        string strTypeOfRestaurent;
        string intChoice;
        int intFoodQuantity = 0,intFoodId;
        double dblFoodCost = 0;
        FoodBO foodBO = new FoodBO();

        public void GetOrders(List<Orders> listOfOrders,int orderId)
        {            

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("              Order Your Food                  ");
            Console.WriteLine("-----------------------------------------------");

            List<string> listOfType = (from restuarentType in AdminMenu.dictOfRestaurentDetails.Keys select restuarentType).ToList();
            List<string> listOfRestaurent = (from resturentName in AdminMenu.dictOfFoods.Keys select resturentName).ToList();

            Console.WriteLine("Order Food By \nSearching Type Of Restaurent \nSearching Hotel Name");
            MainMenu.strChoiceReader = Console.ReadLine();
            MainMenu.intChoice = InputNotStringCharException.check(MainMenu.strChoiceReader);

            switch (MainMenu.intChoice)
            {
                case 1:
                    SearchByRestaurentType(listOfOrders, listOfType,orderId);
                    break;
                case 2:
                    SearchByHotelName(listOfOrders, listOfRestaurent);
                    break;
            }

            Console.WriteLine("Do You Want To View Food Details? Press 'y' for Yes or 'n' for Back");
            MainMenu.strChoiceReader = Console.ReadLine();
            if (MainMenu.strChoiceReader.Equals("y") || MainMenu.strChoiceReader.Equals("Y"))
            {
                
            }
            Console.WriteLine("Press 'P' for Payment");
            MainMenu.strChoiceReader = Console.ReadLine();
            if (MainMenu.strChoiceReader.Equals("P") || MainMenu.strChoiceReader.Equals("p"))
            {
                
            }
        }

        public void SearchByRestaurentType(List<Orders> listOfOrders,List<string> listOfRestaurentType,int orderId)
        {            

            foreach(string restaurentType in listOfRestaurentType)
            {
                Console.WriteLine(restaurentType);
            }
            Console.WriteLine("Enter Type Of Food(Ex:Veg,Non-Veg,Both)");
            strTypeOfRestaurent = Console.ReadLine();
            List<Restaurent> listOfRestuarent = AdminMenu.dictOfRestaurentDetails[strTypeOfRestaurent];
            List<Foods> listOfFoods = null;
            do
            {                                
                foreach (Restaurent restaurent in listOfRestuarent)
                {
                   listOfFoods = AdminMenu.dictOfFoods[restaurent.Hotel_name];
                }

                /*Console.WriteLine("Enter The Restaurent");
                MainMenu.choiceReader = Console.ReadLine(); */            
                 
                foreach(Foods food in listOfFoods)
                {
                    Console.WriteLine(food);
                }             

                    Console.WriteLine();
                    Console.WriteLine("Enter Food Id To Order");
                    MainMenu.strChoiceReader = Console.ReadLine();
                    intFoodId = InputNotStringCharException.check(MainMenu.strChoiceReader);
                    foreach (Foods food in listOfFoods)
                    {
                        if (food.Food_Id.Equals(intFoodId))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter Quantity:");
                            MainMenu.strChoiceReader = Console.ReadLine();
                            intFoodQuantity = InputNotStringCharException.check(MainMenu.strChoiceReader);
                            dblFoodCost = food.Food_cost * intFoodQuantity;                            
                            listOfOrders.Add(new Orders(orderId, intFoodQuantity, new Foods(food.Food_Id, food.Food_name, food.Food_type, dblFoodCost)));                            
                        
                            foreach(Orders orders in listOfOrders)
                             {
                            Console.WriteLine("Order Details:");
                            Console.WriteLine(orders);
                            }
                    
                        }
                    }

                    Console.WriteLine("Press Continue Order In {0} ->'Y' \nPress Search Another Type ->'A' \nBack -> 'B'", strTypeOfRestaurent);
                    intChoice = Console.ReadLine();
                    if (intChoice.Equals("y") || intChoice.Equals("Y"))
                    {
                        UserBO.blnLoopControl = true;
                    } else if(intChoice.Equals("a") || intChoice.Equals("A"))
                    {
                        SearchByRestaurentType(listOfOrders, listOfRestaurentType, orderId);
                    }
                    else
                    {
                        UserBO.blnLoopControl = false;
                    }      
                    
            } while (UserBO.blnLoopControl);
        }
        public void SearchByHotelName(List<Orders> listOfOrders, List<string> listOfHotels)
        {

        }
    }
}
