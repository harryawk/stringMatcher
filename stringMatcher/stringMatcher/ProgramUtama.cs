using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringMatcher
{
    class ProgramUtama { 
     public static void Main(string[] args) {
      kmpMatching mesin = new kmpMatching("aaahaaasaabaaaax");
            //mesin.setText("aaaaaaaaab");
            
            mesin.matchString("aaab");
      
            
      Console.WriteLine("\nPress return key to continue...");
      Console.ReadLine();
     }
    }
}
