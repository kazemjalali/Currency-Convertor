using HiringTask_Jalali.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringTask_Jalali
{
    
    public interface ICurrencyConverter
    {
        void ClearConfiguration();
        void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRate);
        double Convert(string fromCurrency, string toCurrency, double amount);
    }
    public class CurrencyConverter : ICurrencyConverter
    {
        Repository repository;
       
        public void ClearConfiguration()
        {
            repository = null;
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            return repository.GetShortestPath(fromCurrency, toCurrency, amount);
        }

        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRate)
        {
            if(repository == null)
                repository = new Repository();
            repository.updateGraph(conversionRate);
        }
    }
}
