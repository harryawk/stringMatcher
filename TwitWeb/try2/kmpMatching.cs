using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuittuit
{
	public class kmpMatching:Matching
    {
        private String teks;
        private String pattern = "";
        private int[] border;
        private int currPIdx = 0;
        private int currTIdx = 0;
        private bool finish = false;
        private int sumMatch = 0;
        private int start = -1;
        private int idxfinish = -1;
        
        /*public int getCharIdx(char x) {
            return 1;
        }*/

        public kmpMatching(String teksInput) {
            
            setText(teksInput);
        }

        public bool isCharMatch(int teksIndeksKe, int patternIndeksKe) {
			return (pattern[patternIndeksKe]== teks[teksIndeksKe]);
        }

        public void geserSejauh(int x) {
            currTIdx++;
        }

        public void setText(String text_input)
        {
			teks = text_input.ToLower();
        }

        public void setPattern(String pattern_input)
		{
			pattern = pattern_input.ToLower ();
			if (pattern_input.Length != 0) {
				border = new int[pattern_input.Length];
				//==============SET BORDER FUNCTION=============================
				//bool done = false;
				border [0] = 0;
				int i = 1;
				int j = 0;
				while (i < pattern.Length) {
					if (pattern [i] == pattern [j]) {
						border [i] = j + 1;
						i++;
						j++;
					} else if (j > 0) {
						j = border [j - 1];
					} else {
						i++;
					}
				}
			}
        }
        
        public int borderFunction(int indeksMissmatch)
        {
            return border[indeksMissmatch];
        }

        

        public void matchString(String pattern_input) {
			currPIdx = 0;
			currTIdx = 0;
			sumMatch = 0;
			finish = false;
            setPattern(pattern_input);
            int ibatas = teks.Length - pattern.Length;
            bool lewat = false;
            while (!finish && sumMatch < pattern.Length) {
                if (isCharMatch(currTIdx, currPIdx)) { //Char pada currTIdx di teks sama dengan char pada currPIdx di pattern
                    sumMatch++;
                    currPIdx++;
                    currTIdx++;
                    if (currPIdx >= pattern.Length || currTIdx >= teks.Length) { //Ketemu word
                        finish = true;
                        currTIdx--;
                        start = currTIdx - pattern.Length+1;
                        idxfinish = start + pattern.Length - 1;
                    } else {
						//go to next char
                    }
                } else if (border[currPIdx] > 0 && currTIdx < teks.Length - pattern.Length) { //Ga Sama, border function > 0
                                                                                              //Maju sejauh borderFunction + 1
                    sumMatch = 0;
                    currTIdx += borderFunction(currPIdx) +1;
                    currPIdx = 0;
                    if (currTIdx >= teks.Length && currPIdx >= pattern.Length-1) { //Not Match
						start = -1;
						idxfinish = -1;
                        finish = true;
                    }
                } else {
                    sumMatch = 0;
                    if (currTIdx < teks.Length - pattern.Length) {
                            currTIdx++;
                    } else if (!lewat) {
                        currTIdx = teks.Length - pattern.Length;
                        lewat = true;
                    } else { //Not Match
						start = -1;
						idxfinish = -1;
                        finish = true;
                    }
                    currPIdx = 0;
                    if (currTIdx >= teks.Length && currPIdx >= pattern.Length - 1) { //Not Match
						finish = true;
						start = -1;
						idxfinish = -1;
                    }
                }
            }
        }
		public int getStart()
		{
			return start;
		}

		public int getPatternLength()
		{
			return pattern.Length;
		}

		public int getFinish()
		{
			return idxfinish;
		}

		int Matching.search(String input, String[] pattern)
		{
			setText (input);

			int min = 99999999;
			int result = -1;
			int temp;
			int i = 0;
			foreach (String iteration in pattern)
			{
				matchString (iteration);
				temp = getStart ();
				if (min > temp && temp != -1)
				{
					min = temp;
					result = i;
				}
				i++;
			}
			return result;
		}  
    }
}