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
        private bool finish = false;
        private int sumMatch = 0;
        
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
            int i = 1;
            int j = 0;
            while (i < pattern.Length) {
                if (pattern[i] == pattern[j]) {
                    border[i] = j + 1;
                    i++;
                    j++;
                } else if (j > 0) {
                    j = border[j - 1];
                } else {
                    i++;
                }
            }
            for (int q = 0; q < pattern_input.Length; q++)
            {
                Console.WriteLine(border[q]);
            }
        }
        
        public int borderFunction(int indeksMissmatch)
        {
            return border[indeksMissmatch];
        }

        public void matchString(String pattern_input) {
            setPattern(pattern_input);
            Console.WriteLine("Teks : {0}",teks.Length);
            int ibatas = teks.Length - pattern.Length;
            bool lewat = false;
            while (!finish && sumMatch < pattern.Length) {
                if (isCharMatch(currTIdx, currPIdx)) { //Sama
                    Console.WriteLine("Match :");
                    sumMatch++;
                    currPIdx++;
                    currTIdx++;
                    if (currPIdx >= pattern.Length && currTIdx >= teks.Length -1) {
                        finish = true;
                        Console.WriteLine("Ketemu");
                    } else {

                    }
                } else if (border[currPIdx] > 0 && currTIdx < teks.Length - pattern.Length) { //Ga Sama, border function > 0
                                                                                              //Maju sejauh borderFunction + 1
                    Console.WriteLine("Missmatch1: {0}",currTIdx);
                    sumMatch = 0;
                    //currTIdx += borderFunction(currPIdx)+1;
                    currTIdx += borderFunction(currPIdx) +1;
                    currPIdx = 0;
                    if (currTIdx >= teks.Length && currPIdx >= pattern.Length-1) {
                        Console.WriteLine("Not match");
                        finish = true;
                    }
                } else {
                    Console.WriteLine("Missmatch2 :");
                    sumMatch = 0;
                    if (currTIdx < teks.Length - pattern.Length) {
                            currTIdx++;
                    } else if (!lewat) {
                        currTIdx = teks.Length - pattern.Length;
                        lewat = true;
                    } else {
                        Console.WriteLine("Not match");
                        finish = true;
                    }
                    currPIdx = 0;
                    if (currTIdx >= teks.Length && currPIdx >= pattern.Length - 1) {
                        finish = true;
                        Console.WriteLine("Not match");
                    }
                }
            }
        }

    }
}

//int k = 0;
//            for (int q = 1; q <= pattern.Length; q++) {
//                //Console.WriteLine(++k);
//                while (k >= 0 && pattern[q] == pattern[k]) {
//                    k = border[k];
//                }
//                if (pattern[q] == pattern[k + 1]) {
//                    k++;
//                }
//                border[q] = k;
//            }

//public void matchString(String pattern_input)
//{
//    setPattern(pattern_input);
//    bool finish = false;
//    //while (!finish) {
//    if (!finish && currTIdx <= teks.Length)
//    {
//        if (isCharMatch(currTIdx, currPIdx))
//        {
//            currTIdx++;
//            currPIdx++;
//            Console.WriteLine(currPIdx);
//            if (currPIdx != pattern.Length)
//            {
//                matchString(pattern_input);
//            }
//            else {
//                //Done
//                Console.WriteLine("Pattern Ketemu : "); Console.Write("Di indeks : "); Console.WriteLine(currTIdx - pattern.Length);
//                currPIdx = 0;
//            }
//        }
//        else {
//            Console.Write("Indeks Missmatch : "); Console.WriteLine(currTIdx);
//            if (currTIdx == teks.Length - 1)
//            {
//                finish = true;
//                //break;
//            }
//            currTIdx = currTIdx + borderFunction(currPIdx) + 1;
//            currPIdx = 0;
//            if (!finish)
//            {
//                matchString(pattern_input);
//            }
//            else {
//                Console.Write("Pattern tidak ditemukan : \n Indeks Missmatch : "); Console.WriteLine(currTIdx);
//            }
//        }

//    }
//}