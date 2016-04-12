using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringMatcher
{
    class kmpMatching
    {
        private String teks;
        private String pattern = "";
        private int[] border;
        private int currPIdx = 0;
        private int currTIdx = 0;
        
        /*public int getCharIdx(char x) {
            return 1;
        }*/

        public kmpMatching(String teksInput) {
            
            setText(teksInput);
        }

        public bool isCharMatch(int teksIndeksKe, int patternIndeksKe) {
            return (pattern[patternIndeksKe] == teks[teksIndeksKe]);
        }

        public void geserSejauh(int x) {
            currTIdx++;
        }

        public void setText(String text_input)
        {
            teks = text_input;
        }

        public void setPattern(String pattern_input)
        {
            pattern = pattern_input;
            border = new int[pattern_input.Length];
            //==============SET BORDER FUNCTION=============================
            //bool done = false;
            border[0] = 0;
            int k = 0;
            for (int q = 1; q <= pattern.Length; q++) {
                if (k+1 > pattern.Length) {
                    while (k > 0 && pattern[q] == pattern[k + 1]) {
                        k = border[k];
                    }
                    if (pattern[q] == pattern[k + 1]) {
                        k++;
                    }
                    border[q] = k;
                } else {
                    //Done
                }
            }
        }
        
        public int borderFunction(int indeksMissmatch)
        {
            return border[indeksMissmatch];
        }

        public void matchString(String pattern_input) {
            setPattern(pattern_input);
            bool finish = false;
            //while (!finish) {
            if (!finish && currTIdx <= teks.Length) { 
                if (isCharMatch(currTIdx,currPIdx)) {
                    currTIdx++;
                    currPIdx++;
                    Console.WriteLine(currPIdx);
                    if (currPIdx != pattern.Length) {
                        matchString(pattern_input);
                    } else {
                    //Done
                        Console.WriteLine("Pattern Ketemu : "); Console.Write("Di indeks : "); Console.WriteLine(currTIdx-pattern.Length); 
                        currPIdx = 0;
                        //for (int ii = 0; ii < pattern.Length; ii++) {
                        //    for (int jj = 0; jj < ii; jj++) {
                        //        Console.Write(pattern[jj]);
                        //        Console.Write(" -> ");
                        //    }
                            
                        //}
                    }
                } else {
                    Console.Write("Indeks Missmatch : "); Console.WriteLine(currTIdx);
                    if (currTIdx == teks.Length-1) {
                        finish = true;
                        //break;
                    }
                    currTIdx = currTIdx + borderFunction(currPIdx) + 1;
                    currPIdx = 0;
                    if (!finish) {
                        matchString(pattern_input);
                    } else {
                        Console.Write("Pattern tidak ditemukan : \n Indeks Missmatch : "); Console.WriteLine(currTIdx);
                    }
                }
                
            }
        }

    }
}

