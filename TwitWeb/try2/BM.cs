using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuittuit
{
    class bmMatching
    {
        private String teks;
        private String pattern = "";
        private List<char> lastoccurence;
        private int currPIdx = 0;
        private int currTIdx = 0;

        /*public int getCharIdx(char x) {
            return 1;
        }*/

        public bmMatching(String teksInput)
        {
            setText(teksInput);
            lastoccurence = new List<char>();
        }

        public bool isCharMatch(int teksIndeksKe, int patternIndeksKe)
        {
            return (pattern[patternIndeksKe] == teks[teksIndeksKe]);
        }

        public void geserSejauh(int x)
        {
            currTIdx++;
        }

        public void setText(String text_input)
        {
			teks = text_input.ToLower();
        }

        public int getLastOcc(int TeksIdx)
        {
            if (lastoccurence.Contains(teks[TeksIdx]))
            {
                return lastoccurence.LastIndexOf(teks[TeksIdx]);
            }
            else
            {
                return -1;
            }
/*            int i = pattern.Length - 1;
            while (i >= 0)
            {
                if(pattern[i] == teks[TeksIdx])
                {
                    return i;
                }
                i--;
            }
            return -1;*/
        }

        public void setPattern(String pattern_input)
        {
			pattern = pattern_input.ToLower();
            //set last occurence
            lastoccurence.Clear();
            for (int i = 0; i < pattern.Length; i++) {
                lastoccurence.Add(pattern[i]);
            }
        }

        /*        public int borderFunction(int indeksMissmatch)
                {
                    return border[indeksMissmatch];
                }*/

        public int matchString(String pattern_input)
        {
            setPattern(pattern_input);

            if(pattern.Length > teks.Length)
            {
//                Console.WriteLine("Tidak ditemukan, pattern lebih panjang dari teks");
            }

            bool found = false;
            int patternlength = pattern.Length;
            int tekslength = teks.Length;
            currPIdx = patternlength - 1;
            currTIdx = currPIdx;
            int lo = 0;
			if (pattern.Length <= teks.Length) {
				do {
					if (isCharMatch (currTIdx, currPIdx)) {
						if (currPIdx == 0) {
							found = true;
							//                      Console.WriteLine("Karakter ditemukan pada indeks ke {0}", currTIdx);
						} else {
							currPIdx--;
							currTIdx--;
						}
					} else {
						lo = getLastOcc (currTIdx);
						currTIdx = currTIdx + patternlength - Math.Min (currPIdx, 1 + lo);
						currPIdx = patternlength - 1;
					}
				} while (currTIdx < tekslength && !found);
			}
            if (found)
                return currTIdx;
            else
                return -1;
        }

		public int search(String input, String[] pattern)
		{
			setText (input);
			int min = 99999999;
			int result = -1;
			int temp;
			int i = 0;
			foreach (String iteration in pattern)
			{
				temp = matchString (iteration);

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
