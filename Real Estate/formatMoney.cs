using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate
{
    class FormatMoney
    {
        public string addComma(string amount)
        {
            try
            {
                amount = Convert.ToDecimal(amount).ToString("C0");
                amount = amount.Remove(0, 1);
            }
            catch
            {
                Console.WriteLine("can't convert to decimal");
            }
            return amount;
        }

        public string addRial(string amount)
        {
            return amount + " ریال";
        }
    }
}
