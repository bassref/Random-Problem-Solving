using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReformatting
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            int startIndex = 0;
            string s = "2-40rds-09";
            int k = 3;

            s = s.Replace("-", "");
            if(s.Length < k)
            {
                Console.WriteLine(s);
                return;
            }
            // if there are more than 2 extra characters after splitting the string into k
            if((s.Length % k) > 0)
            {
                startIndex = k - 1;
                // retrieves the substring starting at 0 with the length of the start index
                result = s.Substring(0, startIndex) + "-";
            }

            for(int i = startIndex; i < s.Length; i+=k )
            {
                if ((i + k) >= s.Length)
                {
                    result += s.Substring(i);
                }
                else
                {
                    result += (s.Substring(i, k) + "-");
                }                
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
        
    }
    
}
