using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.MyException;
using Spizy.UserModule;
using Spizy.HotelModule;
using Spizy.FoodModule;

namespace Spizy.MenuModule
{
    class AdminMenu
    {
       public static string strTypeOfRestaurent;
      // public static Dictionary<string, List<Restaurent>> dictOfRestaurentDetails = new Dictionary<string, List<Restaurent>>();
       public static Dictionary<string, List<Foods>> dictOfFoods = new Dictionary<string, List<Foods>>();
       public static List<Restaurent> listOfRestaurents = new List<Restaurent>();
       public static List<Foods> listOfFoods = new List<Foods>();
                        
        public static void AdminMenuPage()
        {
             string strHotelName, strHotelArea, strFoodName, strFoodType, strHotelType;
             long HotelPhone;
             int intHotelId, intFoodId;
             double dblFoodCost;
      
            RestaurentBO restaurentBO = new RestaurentBO();
            FoodBO foodBO = new FoodBO();   
            
            try
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("                   ADMIN MENU                  ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Press 1->Register Hotel \n2->View Hotel \n3->View By Restuarent Type \n4->Edit By Restuarent \n5->Delete By Restuarent \n6->Log Out");
                MainMenu.strChoiceReader = Console.ReadLine();
                MainMenu.intChoice = InputNotStringCharException.check(MainMenu.strChoiceReader);
                switch (MainMenu.intChoice)
                {
                    case 1:                        
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("          Restaurent Details Entry             ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Enter The Restaurent Type(Ex:Veg,Non-Veg,Both)");
                        strTypeOfRestaurent = Console.ReadLine();
                        strTypeOfRestaurent = InvalidRestaurentTypeException.restaurenTypeCheck(strTypeOfRestaurent);
                        do
                        {
                            //Console.WriteLine("The Details Format=> Hotel Id,Hotel Name,Hotel Phone,hotel Area:");
                            //strDetailsOfRestaurent = Console.ReadLine();
                            Console.WriteLine("Enter Restaurent Id:");
                            intHotelId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Restaurent Name:");
                            strHotelName = Console.ReadLine();
                            Console.WriteLine("Enter Restaurent Phone:");
                            HotelPhone = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter Restaurent Area:");
                            strHotelArea = Console.ReadLine();
                            Console.WriteLine("Enter Restaurent Type:");
                            strHotelType = Console.ReadLine();

                            //restaurentBO.CreateRestaurent(strTypeOfRestaurent, strDetailsOfRestaurent, dictOfRestaurentDetails, listOfRestaurents, dictOfFoods, listOfFoods);

                            Restaurent restaurent = restaurentBO.CreateNewRestaurent(intHotelId, strHotelName, HotelPhone, strHotelArea, strHotelType);
                            if (restaurent != null)
                            {
                                listOfRestaurents.Add(restaurent);
                                /*if (dictOfRestaurentDetails.ContainsKey(strTypeOfRestaurent))
                                {
                                    dictOfRestaurentDetails[strTypeOfRestaurent] = listOfRestaurents;
                                }
                                else
                                {
                                    dictOfRestaurentDetails.Add(strTypeOfRestaurent, listOfRestaurents);
                                }*/
                               
                                Console.WriteLine("Restaurent Details Created Successfully!...");
                                do {
                                    Console.WriteLine("--------Add Food Details To This Restaurent--------");
                                    Console.WriteLine();
                                    Console.WriteLine("Enter Food Id:");
                                    intFoodId = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Food Name:");
                                    strFoodName = Console.ReadLine();

                                    Console.WriteLine("Enter Food Type:");
                                    strFoodType = Console.ReadLine();

                                    Console.WriteLine("Enter Food Cost:");
                                    dblFoodCost = Convert.ToDouble(Console.ReadLine());

                                    //foodBO.CreateFoodDetails(dictOfFoods, listOfRestaurents, listOfFoods);

                                    Foods foods = foodBO.CreateNewFood(intFoodId, strFoodName, strFoodType, dblFoodCost);

                                    if (foods != null)
                                    {
                                        listOfFoods.Add(foods);
                                        if (dictOfFoods.ContainsKey(restaurent.Hotel_name))
                                        {
                                            dictOfFoods[restaurent.Hotel_name] = listOfFoods;
                                        }
                                        else
                                        {
                                            dictOfFoods.Add(restaurent.Hotel_name, listOfFoods);
                                        }
                                        Console.WriteLine("Food Details Added Successfully!..");
                                    }

                                    Console.WriteLine("Continue To Add Food To Same Hotel Press 'y'->yes 'n'->no");
                                    string choice = Console.ReadLine();
                                    if (!(choice.Equals("y") || choice.Equals("Y")))
                                    {
                                        UserBO.blnLoopControl = false;
                                    }

                                } while (UserBO.blnLoopControl);

                                UserBO.blnLoopControl = true;
                        }
                            Console.WriteLine("Continue To Add Same Type Of Hotel Press 'y'->yes 'n'->no");
                            string strUserChoice = Console.ReadLine();
                            if (!(strUserChoice.Equals("y")|| strUserChoice.Equals("Y")))
                            {
                                UserBO.blnLoopControl = false;
                                AdminMenuPage();
                            }
                        } while (UserBO.blnLoopControl);
                        UserBO.blnLoopControl = true;
                        break;
                    case 2:
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("           All Restaurent Details             ");
                        Console.WriteLine("-----------------------------------------------");
                        restaurentBO.ViewRestaurent(listOfRestaurents);
                        UserBO.blnLoopControl = true;
                        break;
                    case 3:
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("           View Restaurent Details             ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Enter Restuarent Type to View: ");
                        strTypeOfRestaurent = Console.ReadLine();
                        restaurentBO.ViewByRestaurentType(strTypeOfRestaurent,dictOfRestaurentDetails,dictOfFoods);
                        break;
                    case 4:
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("           Edit Restaurent Details             ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Enter Restuarent Type to View: ");
                        strTypeOfRestaurent = Console.ReadLine();
                        restaurentBO.EditRestaurentDetaisls(strTypeOfRestaurent, dictOfRestaurentDetails, dictOfFoods);                       
                        break;
                    case 5:
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("           Delete Restaurent Details           ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Enter Restuarent Type to View: ");
                        strTypeOfRestaurent = Console.ReadLine();
                        restaurentBO.DeleteRestaurentDetaisls(strTypeOfRestaurent, dictOfRestaurentDetails, dictOfFoods);
                        break;
                    case 6:
                        Console.WriteLine("Log Out Successfully!...");
                        MainMenu.RegisterOrLogin();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice");
                        AdminMenuPage();
                        break;
                }               
            }
            catch (InputNotStringCharException e)
            {
                Console.WriteLine("InputNotStringCharException: {0}", e.Message);
                AdminMenuPage();
            }
            catch (InvalidRestaurentTypeException e)
            {
                Console.WriteLine("InvalidRestaurentTypeException: {0}", e.Message);
                AdminMenuPage();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                AdminMenuPage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AdminMenuPage();
            }
        }
    }
}
