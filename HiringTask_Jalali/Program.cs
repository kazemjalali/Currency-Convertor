using System;
using System.Collections.Generic;

namespace HiringTask_Jalali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*MenuManager menuManager = new MenuManager();
            
            do
            {
                menuManager.ShowMenu();

            } while (menuManager.ProcessInput());*/

            List<Tuple<string, string, double>> conversionRates = new();
            conversionRates.Add(new Tuple<string, string, double>("USD", "EUR", 0.86));
            conversionRates.Add(new Tuple<string, string, double>("USD", "IRR", 0.1));
            conversionRates.Add(new Tuple<string, string, double>("EUR", "IRR", 0.08));
            conversionRates.Add(new Tuple<string, string, double>("IRR", "GBR", 8.5));
            conversionRates.Add(new Tuple<string, string, double>("CAD", "GBR", 0.58));
            conversionRates.Add(new Tuple<string, string, double>("EUR", "CAD", 0.87));
            var convertor = new CurrencyConverter();
            convertor.UpdateConfiguration(conversionRates);
            Console.WriteLine("Result:\t" + convertor.Convert("USD", "GBR", 10));
            Console.ReadKey();
        }
    }
}
