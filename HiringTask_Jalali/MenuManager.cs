using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringTask_Jalali
{
    public class MenuManager
    {
        
        public MenuManager()
        {
            
        }
        public void ShowMenu()
        {
            Console.WriteLine("1.Clear Configurations");
            Console.WriteLine("2.Update Configuration");
            Console.WriteLine("3.Convert");
            Console.WriteLine("4.Exit");
        }
        public bool ProcessInput()
        {
            CurrencyConverter currencyConverter = new CurrencyConverter();

            var input = Console.ReadLine();
            if(input == "1")
                currencyConverter.ClearConfiguration();
            if(input == "2")
            {
                Console.WriteLine("Enter source, target and conversion rate with space between. press 0 when finished");
                List<Tuple<string, string, double>> conversionRate = new List<Tuple<string, string, double>>();
                while (true)
                {
                    var config = Console.ReadLine();
                    if(config == "0")
                        break;
                    string[] parameters = config.Split(' ');
                    conversionRate.Add(new Tuple<string, string, double>(parameters[0], parameters[1], Convert.ToDouble(parameters[2])));

                }
                currencyConverter.UpdateConfiguration(conversionRate);
            }
            if (input == "3")
            {
                Console.WriteLine("Enter source, target and amount with space between.");
                var convertInput = Console.ReadLine();
                string[] parameters = convertInput.Split(' ');
                currencyConverter.Convert(parameters[0], parameters[1], Convert.ToDouble(parameters[2]));
            }
            if (input == "4")
                return false;
            return true;

        }

    }
}
