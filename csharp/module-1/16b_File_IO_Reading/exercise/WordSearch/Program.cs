using System;
using System.IO;

namespace WordSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter path to the book file: ");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter the key word");
            string word = Console.ReadLine();
            Console.WriteLine("Do you want case senstive?");
            string letter = Console.ReadLine();

            /*
            Step 2: Step Two: Open the book file and handle errors

            */
            
            if(letter == "n")
            try
            {

                using (StreamReader sr = new StreamReader(filePath))
                {

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        lineCount++;
                        if (line.Contains(word))
                        { Console.WriteLine(lineCount + ") " + line); }

                    }
                    //Loop until the end of file is reached
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            StreamReader dataInput = new StreamReader(filePath);
            int lineCount = 0;
            {
                try
                {

                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();
                            lineCount++;
                            if (line.Contains(word))
                            { Console.WriteLine(lineCount + ") " + line); }

                        }
                        //Loop until the end of file is reached
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //1. Ask the user for the file path
                //2. Ask the user for the search string
                //3. Open the file
                //4. Loop through each line in the file
                //5. If the line contains the search string, print it out along with its line number
            }
        }
    }
}
