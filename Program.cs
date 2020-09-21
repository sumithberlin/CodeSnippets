using System;
using System.Text;

namespace StringFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program pg = new Program();
            string inputString = "pwwkew";
            int longest = pg.LengthOfLongestSubstring(inputString);

            Console.WriteLine("The Longest Substring Without Repeating Characters ");
            Console.WriteLine(longest);

        }

        public int LengthOfLongestSubstring(string s)
        {
            StringBuilder stringArray = new StringBuilder(s);
            int length = 0;
            StringBuilder tempString = new StringBuilder();
            tempString.Append(stringArray[0].ToString());

            for( int i=1; i < stringArray.Length; i++)
            {
                bool result = checkString(tempString, stringArray[i].ToString());
                if (result == true)
                {
                    if (length < tempString.Length)
                    {
                        length = tempString.Length;
                    }
                    tempString.Clear();
                    tempString.Append(stringArray[i].ToString());
                }
                else
                {
                    tempString.Append(stringArray[i].ToString());
                }
            }

            if (length < tempString.Length)
            {
                length = tempString.Length;
            }

            return length;

        }

        public bool checkString(StringBuilder stringArray, string checkString)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i].ToString() == checkString)
                    return true;
            }
            return false;
        }
    }
}
