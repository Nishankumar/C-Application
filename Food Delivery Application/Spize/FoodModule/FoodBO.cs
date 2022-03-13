using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.HotelModule;
using Spizy.MyException;
using Spizy.MenuModule;
using Spizy.UserModule;

namespace Spizy.FoodModule
{
    class FoodBO
    {        

       // string strDetailsOfFood;
        string[] arrayOfFood;        

        public Foods CreateNewFood(int FoodId,string FoodName,string FoodType,double FoodCost)
        {
            Foods foods = null;
            try
            {
                foods = new Foods(FoodId, FoodName, FoodType, FoodCost);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return foods;
        }

        /*public void CreateFoodDetails(Dictionary<string, List<Foods>> dictOfFoods, List<Restaurent> restaurents,List<Foods> listOfFoods)
        {                  
            try
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("              FOOD DETAILS ENTRY               ");
                Console.WriteLine("-----------------------------------------------");

                if (restaurents.Count > 0)
                {
                    foreach(Restaurent restaurent in restaurents)
                    {

                       do
                        {
                            Console.WriteLine("Enter The Food Details:");
                            Console.WriteLine("Details Format -> Food Id, Food Name, Food Type, Food Cost");

                            if (dictOfFoods.ContainsKey(restaurent.Hotel_name))
                            {
                                strDetailsOfFood = Console.ReadLine();
                                arrayOfFood = strDetailsOfFood.Split(",");
                                arrayOfFood = ArrayNumberOfValueException.checkSizeOfArray(arrayOfFood);
                                listOfFoods.Add(new Foods(Convert.ToInt32(arrayOfFood[0]), arrayOfFood[1], arrayOfFood[2], Convert.ToDouble(arrayOfFood[3])));
                                dictOfFoods[restaurent.Hotel_name] = listOfFoods;
                                Console.WriteLine("Food Details Added Successfully!..");
                            }
                            else
                            {
                                strDetailsOfFood = Console.ReadLine();
                                arrayOfFood = strDetailsOfFood.Split(",");
                                arrayOfFood = ArrayNumberOfValueException.checkSizeOfArray(arrayOfFood);
                                listOfFoods = new List<Foods>();
                                listOfFoods.Add(new Foods(Convert.ToInt32(arrayOfFood[0]), arrayOfFood[1], arrayOfFood[2], Convert.ToDouble(arrayOfFood[3])));
                                dictOfFoods.Add(restaurent.Hotel_name, listOfFoods);
                                Console.WriteLine("Food Details Added Successfully!..");
                            }

                            Console.WriteLine("Continue To Add Food To Same Hotel Press 'y'->yes 'n'->no");
                            string choice = Console.ReadLine();
                            if (!(choice.Equals("y") || choice.Equals("Y")))
                            {
                                UserBO.blnLoopControl = false;
                            }
                        }while (UserBO.blnLoopControl) ;                     
                    }

                    UserBO.blnLoopControl = true;
                }
                else
                {
                    Console.WriteLine("No Restaurent Details Found!..");
                    AdminMenu.AdminMenuPage();
                    
                }
            }catch(ArrayNumberOfValueException e)
            {
                UserBO.blnLoopControl = true;
                Console.WriteLine(e.Message);
                CreateFoodDetails(dictOfFoods,restaurents,listOfFoods);
                
            }catch(ArgumentOutOfRangeException e)
            {
                UserBO.blnLoopControl = true;
                Console.WriteLine(e.Message);
                CreateFoodDetails(dictOfFoods, restaurents, listOfFoods);
            }           
            catch(Exception e)
            {
                UserBO.blnLoopControl = true;
                Console.WriteLine(e.Message);
                CreateFoodDetails(dictOfFoods, restaurents, listOfFoods);
            }
        }*/

        public void viewFoods(Dictionary<string,List<Foods>> dictOfFoods)
        {
            try
            {

                List<Foods> listOfFoods = null;

                if (dictOfFoods.Count >0 && dictOfFoods != null)
                {
                    foreach(string hotel in dictOfFoods.Keys)
                    {

                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("          {0} Food Details                ", hotel);
                        Console.WriteLine("-----------------------------------------------");

                        Console.WriteLine("HOTEL NAME: {0}", hotel);
                        listOfFoods = dictOfFoods[hotel];
                        int intCountOfFoods = listOfFoods.Count();
                        Console.WriteLine("AVAILABLE FOODS COUNT: {0}",intCountOfFoods);
                        Console.WriteLine();
                        foreach(Foods foods in listOfFoods)
                        {
                            Console.WriteLine(foods);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Food Details Found!..");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EditFoodDetaisls(string Restaurent, Dictionary<string, List<Foods>> dictOfFoods)
        {
            try
            {
                List<Foods> listOfFoods = dictOfFoods[Restaurent];
                foreach(Foods food in listOfFoods)
                {
                    Console.WriteLine(food);
                }

                Console.WriteLine();
                Console.WriteLine("Enter The Food Id For Edit:");
                int intFoodId = Convert.ToInt32(Console.ReadLine());

                if (listOfFoods.Count > 0)
                {
                    int intIndexCount = 0;
                    foreach (Foods food in listOfFoods)
                    {
                        if (food.Food_Id.Equals(intFoodId))
                        {
                            Console.WriteLine("Existing Details:");
                            Console.WriteLine();
                            Console.WriteLine(food);
                            Console.WriteLine();
                            Console.WriteLine("Enter Details To Edit:");
                            Console.WriteLine("The Details Format=> Food Name,Food Type,Food Cost:");
                            string strDetailsOfFood = Console.ReadLine();
                            arrayOfFood = strDetailsOfFood.Split(",");
                            listOfFoods[intIndexCount] = new Foods(Convert.ToInt32(intFoodId), arrayOfFood[0], arrayOfFood[1], Convert.ToDouble(arrayOfFood[2]));
                            Console.WriteLine("Food Details Updated Successfully!...");
                            Console.WriteLine();                            
                        }
                        intIndexCount++;
                    }
                }
                else
                {
                    Console.WriteLine("NO Food Details Found!..");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteFoodDetaisls(string Restaurent, Dictionary<string, List<Foods>> dictOfFoods)
        {
            try
            {
                List<Foods> listOfFoods = dictOfFoods[Restaurent];
                foreach (Foods food in listOfFoods)
                {
                    Console.WriteLine(food);
                }

                Console.WriteLine();
                Console.WriteLine("Enter The Food Id For Delete:");
                int intFoodId = Convert.ToInt32(Console.ReadLine());

                if (listOfFoods.Count > 0)
                {
                    int intIndexCount = 0;
                    foreach (Foods food in listOfFoods)
                    {
                        if (food.Food_Id.Equals(intFoodId))
                        {
                            listOfFoods.RemoveAt(intIndexCount);
                            Console.WriteLine("Food Details Deleted Successfully!...");
                            Console.WriteLine();
                            AdminMenu.AdminMenuPage();
                        }
                        intIndexCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
