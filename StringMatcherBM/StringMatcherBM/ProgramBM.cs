using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatcherBM
{
    class Program
    {
        static void Main(string[] args)
        {
            //bmMatching mesin = new bmMatching("April 19th patch changes Balance: Stability change – only 1 stack can be removed per second.Balance: Unlimited target spells like Static Field get a 10 target cap.");
            //mesin.setText("aaaaaaaaab");
            bmMatching mesin = new bmMatching("nobody noticed him");
            int indeks = mesin.matchString("ime");
            if (indeks != -1)
            {
                Console.WriteLine("ketemu dong di indeks {0}", indeks);
            }
            else
            {
                Console.WriteLine("ga ketemu :(");
            }

            Console.WriteLine("\nPress return key to continue...");
            Console.ReadLine();
        }
    }
}
