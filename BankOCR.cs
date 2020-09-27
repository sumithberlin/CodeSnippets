using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace BankOCR
{
    public class Program
    {
        private static int DIGIT_COLS = 3;
        private static int DIGIT_ROWS = 3;
        private static int TOTAL_DIGITS = 9;
        public string ErrorMessage = "No Match Found";

        //Main Program
        public static void Main(string[] args)
        {
            string dirPath;
            Console.Write("Enter the file path: ");
            dirPath = Console.ReadLine();

            Program pg = new Program();
            pg.getAccountNumbers(dirPath);
        }

        //Extract the numbers for comparison from the file.
        public void getAccountNumbers(string dirPath)
        {
            List<string> accountNumbers = new List<string>();
            FileInfo txtFiles = new FileInfo(dirPath);

            //Read each of the lines.
            string[] fileContents = readLines(txtFiles);

            for (int lineIndex = 0; lineIndex < fileContents.Length; lineIndex += 4)
            {
                string[] accountEntry = new string[3];
                accountEntry[0] = fileContents[lineIndex];
                accountEntry[1] = fileContents[lineIndex + 1];
                accountEntry[2] = fileContents[lineIndex + 2];
                accountNumbers.Add(parseEntry(accountEntry));
            }

            //Print the values
            foreach (string value in accountNumbers)
                Console.WriteLine(value);
        }

        public string[] readLines(FileInfo file)
        {

            List<string> lines = new List<string>();

            using (StreamReader sr = file.OpenText())
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }

        public string parseEntry(string[] accountEntry)
        {

            StringBuilder sb = new StringBuilder();

            for (int digitIndex = 0; digitIndex < TOTAL_DIGITS; digitIndex++)
            {
                string[] digitRows = new string[DIGIT_ROWS];

                int substringStartIndex = digitIndex * DIGIT_COLS;
                digitRows[0] = accountEntry[0].Substring(substringStartIndex,  3);
                digitRows[1] = accountEntry[1].Substring(substringStartIndex,  3);
                digitRows[2] = accountEntry[2].Substring(substringStartIndex,  3);

                string value = ParseDigit(digitRows);

                if (value.Equals(ErrorMessage))
                {
                    Console.WriteLine("The input is faulty");
                    sb.Clear();
                    break;
                }
                else
                {
                    sb.Append(value);
                }
                
            }

            return sb.ToString();
        }

        //Method to Parse the digits.
        public string ParseDigit(string[] digitRows)
        {

            if (digitRows.SequenceEqual(Digits.ZERO))
            {
                return "0";
            }
            else if (digitRows.SequenceEqual(Digits.ONE))
            {
                return "1";
            }
            else if (digitRows.SequenceEqual(Digits.TWO))
            {
                return "2";
            }
            else if (digitRows.SequenceEqual(Digits.THREE))
            {
                return "3";
            }
            else if (digitRows.SequenceEqual(Digits.FOUR))
            {
                return "4";
            }
            else if (digitRows.SequenceEqual(Digits.FIVE))
            {
                return "5";
            }
            else if (digitRows.SequenceEqual(Digits.SIX))
            {
                return "6";
            }
            else if (digitRows.SequenceEqual(Digits.SEVEN))
            {
                return "7";
            }
            else if (digitRows.SequenceEqual(Digits.EIGHT))
            {
                return "8";
            }
            else if (digitRows.SequenceEqual(Digits.NINE))
            {
                return "9";
            }
            else
            {
                return ErrorMessage;
            }
        }

        //Collection of each digit representation.
        public static class Digits
        {
            public static string[] ZERO = new string[]
            {
                        " _ ",
                        "| |",
                        "|_|"
            };

            public static string[] ONE = new string[]
            {
                        "   ",
                        "  |",
                        "  |"
            };

            public static string[] TWO = new string[]
            {
                        " _ ",
                        " _|",
                        "|_ "
            };

            public static string[] THREE = new string[]
            {
                        " _ ",
                        " _|",
                        " _|"
            };

            public static string[] FOUR = new string[]
            {
                        "   ",
                        "|_|",
                        "  |"
            };

            public static string[] FIVE = new string[]
            {
                        " _ ",
                        "|_ ",
                        " _|"
            };

            public static string[] SIX = new string[]
            {
                        " _ ",
                        "|_ ",
                        "|_|"
            };

            public static string[] SEVEN = new string[]
            {
                        " _ ",
                        "  |",
                        "  |"
            };

            public static string[] EIGHT = new string[]
            {
                        " _ ",
                        "|_|",
                        "|_|"
            };

            public static string[] NINE = new string[]
            {
                        " _ ",
                        "|_|",
                        " _|"
            };
        }

    }

}
