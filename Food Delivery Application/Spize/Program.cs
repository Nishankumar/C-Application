/*
Title      : Spizy Food App
Authour    : Nishankumar
Created at : 31-Dec-2021
Reviewed by: Akshaya
Updated at : 04-Jan-2022
*/
using System;
using Spizy.MenuModule;

namespace Spizy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("                 SpizY Food App                ");
            Console.WriteLine("-----------------------------------------------");                                  
            MainMenu.RegisterOrLogin();            
        }
    }
}
