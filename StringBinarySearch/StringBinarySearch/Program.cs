using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[] { "cavern", "mountain", "valley", "bicycle", "capital", "mouth", "caw", "cayman", "dog", "devil", "excellent" };
            List<string> matches = new List<string>();
            int min = 0;
            int max = words.Length - 1;
            string key = "ca";
            //sort the array
            Array.Sort(words);
            SearchWords(words, matches, key, min, max);
            foreach (string mem in matches)
                Console.WriteLine(mem);

            Console.ReadKey();
        }

        public static List<string> SearchWords(string[] words, List<string> matches, string key, int min, int max)
        {
            int comValue = 0;

            if (max < min)
            {
                matches.Add("");
                return matches;
            }

            else if (max == min && words[max].StartsWith(key))
            {
                matches.Add(words[max]);
            }

            else
            {
                int mid = (min + (max - min)) / 2;
                if (words[mid].StartsWith(key))
                {
                    RecLeft(words, matches, mid - 1, key);
                    matches.Add(words[mid]);
                    RecRight(words, matches, mid + 1, key);                    
                }
                else
                {
                    comValue = string.Compare(key, words[mid]);
                    // check first half
                    if (comValue < 0)
                    {
                        return (SearchWords(words, matches, key, min, mid - 1));
                    }

                    //check second half
                    else if (comValue > 0)
                    {
                        return (SearchWords(words, matches, key, mid + 1, max));
                    }
                }                
           }
            return matches;
        }

        public static void RecLeft(string[] words, List<string> matches, int pos, string key)
        {
           
            if(words[pos].StartsWith(key))
            {
                RecLeft(words, matches, pos-1, key);
                matches.Add(words[pos]);
            }
        }

        public static void RecRight(string[] words, List<string> matches, int pos, string key)
        {            
            if (words[pos].StartsWith(key))
            {
                matches.Add(words[pos]);
                RecRight(words, matches, pos+1, key);                
            }
        }
    }
}
