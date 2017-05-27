using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "Test* t = new Test();", "t->a = 1;", "t->b = 2;", "t->go(); // a=1, b=2 --> a=2, b=3" };

            // Returns: {"Test* t = new Test();", "t.a = 1;", "t.b = 2;", "t.go(); // a=1, b=2 --> a=2, b=3" }
            foreach (string s in input)
            {
                string result = CleanString(s);
                Console.Write("\" {0} \"," ,result);
            }
            Console.ReadKey();
        }

        public static string CleanString(string sample)
        {
            int index = 0;
            string before = "";
            string after = "";
            string comments = "";
            string result = "";

           
                if (sample.Contains("//"))
                {
                    // find where the // start
                    index = sample.IndexOf("//");
                    // assign the comments
                    comments = sample.Substring(index);
                    // input without everything after the comments
                    before = sample.Replace(comments, "");
                    //make replacement according to the question
                    after = before.Replace("->", ".");
                    result = after + comments;
                }
                else
                    result = sample.Replace("->", ".");
            
            //returns string without comments
            return result;
        }

    }
}
