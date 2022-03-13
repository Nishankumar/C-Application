using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spizy.UserModule;
using Spizy.FoodModule;
using Spizy.MyException;
using Spizy.MenuModule;

namespace Spizy.HotelModule
{
    class RestaurentBO
    {
        
        string[] arrayOfRestaurent;
        FoodBO foodBO = new FoodBO();
        bool blnLoopControl = true;

        public Restaurent CreateNewRestaurent(int HotelId,string HotelName, long HotelPhone ,string HotelArea,string HotelType)
        {
            Restaurent restaurent = null;
            try
            {
                restaurent = new Restaurent(HotelId, HotelName, HotelPhone, HotelArea, HotelType);
                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restaurent;
        }    
        
        
       /* public void CreateRestaurent(string typeOfRestaurent,string detailsOfRestaurent, 
            Dictionary<string, List<Restaurent>> dictOfRestaurentDetails, List<Restaurent> listOfRestaurents,Dictionary<String, List<Foods>> dictOfFoods, List<Foods> listOfFoods)
        {
            try
            {               
                    arrayOfRestaurent = detailsOfRestaurent.Split(",");
                    ArrayNumberOfValueException.checkSizeOfArray(arrayOfRestaurent);
                    if (dictOfRestaurentDetails.ContainsKey(typeOfRestaurent))
                    {
                        string strHotelId = arrayOfRestaurent[0];
                        int intId = InputNotStringCharException.check(strHotelId);
                        listOfRestaurents.Add(new Restaurent(intId, arrayOfRestaurent[1], Convert.ToInt64(arrayOfRestaurent[2]), arrayOfRestaurent[3]));
                        dictOfRestaurentDetails[typeOfRestaurent] = listOfRestaurents;
                        Console.WriteLine("Restaurent Details Added Successfully!...");
                        Console.WriteLine("Add Food Details To This Restaurent");
                        foodBO.CreateFoodDetails(dictOfFoods,listOfRestaurents, listOfFoods);
                    }
                    else
                    {
                        listOfRestaurents = new List<Restaurent>();
                        listOfRestaurents.Add(new Restaurent(Convert.ToInt32(arrayOfRestaurent[0]), arrayOfRestaurent[1], Convert.ToInt64(arrayOfRestaurent[2]), arrayOfRestaurent[3]));
                        dictOfRestaurentDetails.Add(typeOfRestaurent, listOfRestaurents);
                        Console.WriteLine("Restaurent Details Added Successfully!...");
                        Console.WriteLine("--------Add Food Details To This Restaurent--------");
                        foodBO.CreateFoodDetails(dictOfFoods,listOfRestaurents, listOfFoods);
                    }                                             
            }
            catch(InputNotStringCharException e)
            {
                Console.WriteLine("InputNotStringCharException: {0}", e.Message);                
                AdminMenu.AdminMenuPage();
            }            
            catch (ArrayNumberOfValueException e)
            {
                Console.WriteLine("ArrayNumberOfValueException: {0}", e.Message);
                AdminMenu.AdminMenuPage();
            }
            catch (Exception e)
            {  
                Console.WriteLine(e.Message);
                AdminMenu.AdminMenuPage();
            }
        }*/
        public void ViewRestaurent(Dictionary<string, List<Restaurent>> dictOfRestaurentDetails)
        {            
            try
            {
                List<Restaurent> listOfRestaurents = null;

               if (dictOfRestaurentDetails.Count > 0 && dictOfRestaurentDetails != null)
                {
                    foreach (string type in dictOfRestaurentDetails.Keys)
                    {                                                                      
                        listOfRestaurents = dictOfRestaurentDetails[type];
                        int count = listOfRestaurents.Count();
                        Console.WriteLine("Restaurent Type -> {0} No. Of Hotels: {1}", type, count);
                        Console.WriteLine();

                        foreach(Restaurent restaurent in listOfRestaurents)
                        {
                            Console.WriteLine(restaurent);                         
                        }
                    }

                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press 'B' ->  Back");
                        MainMenu.strChoiceReader = Console.ReadLine();
                        if (MainMenu.strChoiceReader.Equals("B") || MainMenu.strChoiceReader.Equals("b"))
                        {
                            UserBO.blnLoopControl = false;
                            AdminMenu.AdminMenuPage();
                        }
                    } while (UserBO.blnLoopControl);
                }
                else
                {
                    Console.Write("No Restaurent Details Found!");
                    Console.WriteLine();
                    AdminMenu.AdminMenuPage();
                }                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ViewByRestaurentType(string typeOfRestaurent,  List<Restaurent> listOfRestaurents, Dictionary<string,List<Foods>> dictOfFoods)
        {             

            try
            {
                //List<Restaurent> listOfRestaurents = null;

                // int intCount = (from d in dictOfRestaurentDetails where d.Key.Equals(typeOfRestaurent) select d).Count();               

                int intCount = listOfRestaurents.Count();

                if (dictOfRestaurentDetails.Count > 0 && dictOfRestaurentDetails != null)
                {
                    if (dictOfRestaurentDetails.ContainsKey(typeOfRestaurent))
                    {
                        listOfRestaurents = dictOfRestaurentDetails[typeOfRestaurent];
                        foreach(Restaurent restaurent in listOfRestaurents)
                        {
                            Console.WriteLine(restaurent);
                            Console.WriteLine();
                            Console.WriteLine("Do You Want To View Food Details? Press 'y' for Yes or 'n' for Back");
                            MainMenu.strChoiceReader = Console.ReadLine();
                            if (MainMenu.strChoiceReader.Equals("y") || MainMenu.strChoiceReader.Equals("Y"))
                            {
                                foodBO.viewFoods(dictOfFoods);
                            }
                        }
                    }                                        
                    do
                    {
                        Console.WriteLine("Press 'B' for Back");
                        MainMenu.strChoiceReader = Console.ReadLine();
                        if (MainMenu.strChoiceReader.Equals("B") || MainMenu.strChoiceReader.Equals("b"))
                        {
                            blnLoopControl = false;
                            AdminMenu.AdminMenuPage();
                        }
                    } while (blnLoopControl);                                      
                }
                else
                {
                    Console.WriteLine("No Details Found!..");
                    Console.WriteLine();
                    AdminMenu.AdminMenuPage();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EditRestaurentDetaisls(string typeOfRestaurent, Dictionary<string, List<Restaurent>> dictOfRestaurentDetails,
             Dictionary<string, List<Foods>> dictOfFoods)
        {
            try
            {
                List<Restaurent> listOfRestaurents = dictOfRestaurentDetails[typeOfRestaurent];
                foreach (Restaurent restaurentdetails in listOfRestaurents)
                {
                    Console.WriteLine(restaurentdetails);
                }
                Console.WriteLine("Enter The Restaurent Id For Edit:");
                int intRestaurentId = Convert.ToInt32(Console.ReadLine());

                if (listOfRestaurents.Count > 0)
                {                    
                    int intIndexCount = 0;
                    foreach(Restaurent restaurent in listOfRestaurents)
                    {                        
                        if (restaurent.Hotel_id.Equals(intRestaurentId))
                        {
                            Console.WriteLine("Existing Details:");
                            Console.WriteLine();
                            Console.WriteLine(restaurent);
                            Console.WriteLine();
                            Console.WriteLine("Enter Details To Edit:");
                            Console.WriteLine("The Details Format=> Hotel Name,Hotel Phone,hotel Area:");
                            string detailsOfRestaurent = Console.ReadLine();
                            arrayOfRestaurent = detailsOfRestaurent.Split(",");
                           // listOfRestaurents[intIndexCount] = new Restaurent(Convert.ToInt32(intRestaurentId), arrayOfRestaurent[0], Convert.ToInt64(arrayOfRestaurent[2]), arrayOfRestaurent[2]);
                            Console.WriteLine("Do You Want To Edit or Delete Food Details? Press 'E' for Edit or 'D' for Delete 'B' for Back");
                            MainMenu.strChoiceReader = Console.ReadLine();
                            if (MainMenu.strChoiceReader.Equals("E") || MainMenu.strChoiceReader.Equals("e"))
                            {
                                foodBO.EditFoodDetaisls(restaurent.Hotel_name,dictOfFoods);
                                Console.WriteLine("Restaurent Details Updated Successfully!...");
                            }
                            else if(MainMenu.strChoiceReader.Equals("D") || MainMenu.strChoiceReader.Equals("d"))
                            {
                                foodBO.DeleteFoodDetaisls(restaurent.Hotel_name,dictOfFoods);
                                Console.WriteLine("Restaurent Details Updated Successfully!...");
                            }
                            else
                            {
                                Console.WriteLine();
                                AdminMenu.AdminMenuPage();
                            }                            
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

        public void DeleteRestaurentDetaisls(string typeOfRestaurent, Dictionary<string, List<Restaurent>> dictOfRestaurentDetails,
            Dictionary<string, List<Foods>> dictOfFoods)
        {
            try
            {
                List<Restaurent> listOfRestaurents = dictOfRestaurentDetails[typeOfRestaurent];
                foreach(Restaurent restaurentdetails in listOfRestaurents)
                {
                    Console.WriteLine(restaurentdetails);
                }

                Console.WriteLine("Enter The Restaurent Id For Edit:");
                int intRestaurentId = Convert.ToInt32(Console.ReadLine());

                if (listOfRestaurents.Count > 0)
                {
                    int intIndexCount = 0;
                    foreach (Restaurent restaurent in listOfRestaurents)
                    {
                        if (restaurent.Hotel_id.Equals(intRestaurentId))
                        {
                            dictOfFoods.Remove(restaurent.Hotel_name);
                            listOfRestaurents.RemoveAt(intIndexCount);
                            Console.WriteLine("Restaurent Details Deleted Successfully!...");
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
