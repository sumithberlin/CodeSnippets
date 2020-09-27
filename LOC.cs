using System;
using System.IO;
using System.Threading;

namespace LOCProgram
{
    class LOC
    {
        //Global count for whitespace.
        public static int othercount = 0;

        //Main Method
        static void Main(string[] args)
        {

            //Get the file path
            string dirPath;
            Console.Write("Enter the file path: ");
            dirPath = Console.ReadLine();

            LOC pg = new LOC();
            int lines = pg.LOCinFile(dirPath);

            Console.WriteLine("The number of lines is " + lines);
            Console.WriteLine("The number of whitespace is " + LOC.othercount);

        }

        //Method to find the count
        public int LOCinFile(string dirPath)
        {

            FileInfo csFiles = new FileInfo(dirPath);

            int totalNumberOfLines = 0;

            Interlocked.Add(ref totalNumberOfLines, CountLine(csFiles));

            return totalNumberOfLines;

        }

        //Read the file line by line.
        public int CountLine(FileInfo fo)
        {

            int count = 0;
            int inComment = 0;

            using (StreamReader sr = fo.OpenText())
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (IsCode(line.Trim(), ref inComment))
                        count++;
                }
            }
            return count;
        }

        //Method to Check if it is a valid code.
        public bool IsCode(string trimmed, ref int inComment)
        {

            if (trimmed.StartsWith("/*") && trimmed.EndsWith("*/"))
            {
                LOC.othercount++;
                return false;
            }  
            else if (trimmed.StartsWith("/*"))
            {
                if (!trimmed.EndsWith("*/"))
                {
                    if (trimmed.EndsWith(";"))
                    {
                        return true;
                    }
                    else
                    {
                        inComment--;
                        LOC.othercount++;

                        return false;
                    }
                }
                else
                {
                    inComment++;
                    LOC.othercount++;

                    return false;
                }
            }
            else if (trimmed.EndsWith("*/"))
            {
                inComment--;
                LOC.othercount++;

                return false;
            }
            else if (trimmed == "")
            {
                LOC.othercount++;
                return false;
            }
            else

            return

            inComment == 0

            && !trimmed.StartsWith("//")

            && (trimmed.StartsWith("if")

            || trimmed.StartsWith("else if")

            || trimmed.StartsWith("using (")

            || trimmed.StartsWith("else if")

            || trimmed.Contains(";")

            || trimmed.StartsWith("public") 

            || trimmed.StartsWith("private") 

            || trimmed.StartsWith("protected") 

            );

        }
    }
}
