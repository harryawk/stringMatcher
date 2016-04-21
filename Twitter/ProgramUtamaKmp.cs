using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuittuit
{
    class ProgramUtama { 
     public static void ProgramUtamaKMP(string[] args) {
      kmpMatching mesin = new kmpMatching("nobody noticed him");
            //mesin.setText("aaaaaaaaab");
            
            mesin.matchString("not");
      
            
      Console.WriteLine("\nPress return key to continue...");
      Console.ReadLine();
     }
    }
}
