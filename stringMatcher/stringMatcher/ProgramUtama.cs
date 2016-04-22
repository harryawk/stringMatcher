using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringMatcher
{
    class ProgramUtama { 
     public static void Main(string[] args) {
      kmpMatching mesin = new kmpMatching("aaahaaasaabaaaab");
            Console.WriteLine("Panjang teks : {0}", "aaahaaasaabaaaab".Length);
            mesin.matchString("aaab");
            Console.Write("String pattern yang didapat dari teks : ");
            Console.WriteLine("mesin.getStart() : {0}", mesin.getStart());
            Console.WriteLine("mesin.getPatternLength() : {0}", mesin.getPatternLength());
            int d = mesin.getStart();
            Console.WriteLine("d : {0}", d);
            int x = mesin.getFinish();
            Console.WriteLine("x : {0}",x );
            string s = "aaahaaasaabaaaab";
            Console.WriteLine(s[d]);
            int i = d;
            for (int j = d; j <= x; j++) {
                Console.Write(s[j]);
            }
            //Console.WriteLine();
            //mesin.setText("aaaaaaaaab");
            
            
      
            
      //Console.WriteLine("\nPress return key to continue...");
      Console.ReadLine();
     }
    }
}
