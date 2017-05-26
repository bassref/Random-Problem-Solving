using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aaaskkdslleiiieiiwncfffhfdxhbkkkkkkkkdffdk";
            char currentChar = input[0];
            int currentCount = 0;
            Dictionary<char, int> collisions = new Dictionary<char, int>();

            for(int i = 1; i < input.Length; i++)
            {
                bool matchesCurrentChar = input[i] == currentChar;
                if(matchesCurrentChar)
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                    currentChar = input[i];
                }
                UpdateCharCount(collisions, currentChar, currentCount);
            }
            PrintCollissions(collisions);

            char mostFreq = GetMostFrequent(collisions);
            Console.WriteLine("Character with the longest consecutive char is {0} with {1} occurrences", mostFreq, collisions[mostFreq]);

            Console.ReadKey();
        }

        public static void UpdateCharCount(Dictionary<char, int> collissions, char key, int count)
        {
            if(collissions.ContainsKey(key) && count > collissions[key])
            {
                collissions[key] = count;
            }
            else if (!collissions.ContainsKey(key))
            {
                collissions[key] = 1;
            }
        }

        public static void IncrementCharCount(Dictionary<char, int> collissions, char key)
        {
            if (collissions.ContainsKey(key))
                collissions[key] += 1;
            else
                collissions[key] = 1;
        }

        public static void PrintCollissions(Dictionary<char, int> collissions)
        {
            foreach (char key in collissions.Keys)
                Console.WriteLine("Key {0}  Value:{1}", key, collissions[key]);
        }

        public static char GetMostFrequent(Dictionary<char, int> collissions)
        {
            var mostFreqChar = (from key in collissions.Keys
                                orderby collissions[key] descending
                                select key).FirstOrDefault();

            return Convert.ToChar(mostFreqChar);
        }
    }
}
