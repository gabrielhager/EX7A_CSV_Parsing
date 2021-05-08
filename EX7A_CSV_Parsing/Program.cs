//Collaborated with Matthew Forbes
using System;
using System.Collections.Generic;

namespace EX7A_CSV_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*************************
           * read CSV with embedded commas
           * parse CSV into separate fields and
           * ignore commas within quoted string
           * ***********************/
            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();
            string input1 = "\"a,b\",c";
            myList.Add(input1);
            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            myList.Add(input2);
            string input3 = "\"Ft. Benning, Georgia\",32.3632N,84.9493W," +
            "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," +
            "\"Ft. Gordon, Georgia\",33.4302N,82.1267W";
            myList.Add(input3);

            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s);
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");

                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
        }

        static List<string> getCSV(string input)
        {
            List<string> csvOutput = new List<string>();
            int subStart = 0;
            int subLength;
            bool withinQuotes = false;
            char[] charsToTrim = { ',', '"' };

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '"')
                {
                    switch (withinQuotes)
                    {
                        case true:
                            withinQuotes = false;
                            break;
                        case false:
                            withinQuotes = true;
                            break;
                    }
                        
                }
                if(input[i] == ',' || i == input.Length - 1)
                {
                    switch (withinQuotes)
                    {
                        case true:
                            break;
                        case false:
                            subLength = i;
                            csvOutput.Add(input.Substring(subStart + 1, subLength - subStart).Trim(charsToTrim));
                            subStart = subLength ;
                            break;
                    }
                }
            }
            return csvOutput;
        }
    }
}
