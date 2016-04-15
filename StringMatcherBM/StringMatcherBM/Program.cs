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
            //aaaaaaaaaaaaaaaaaa
            bmMatching mesin = new bmMatching("nobody noticed him");
            //mesin.setText("aaaaaaaaab");

            mesin.matchString("not");


            Console.WriteLine("\nPress return key to continue...");
            Console.ReadLine();
        }
    }
}
