using System;
using System.IO;
namespace FindAndReplace
{
   public class Program
    {

        public static void Main(string[] args)
        {
            
            
            Console.WriteLine("What word are you looking for?");
            string findTheWord = Console.ReadLine();

            Console.WriteLine("What word are you trying to replace?");
            string whichWordYouWannaReplaceHomie = Console.ReadLine();

            Console.WriteLine("Please find the file!");
            string fullPath = Console.ReadLine();

            Console.WriteLine("What do you want to name the second file?");
            string secondFileName = Console.ReadLine();

            string currentFile = Environment.CurrentDirectory;
            string pathToSecondFile = Path.Combine(currentFile, secondFileName);
 

            try
            {
                using (StreamReader samReader = new StreamReader(fullPath))
                using (StreamWriter theWriter = new StreamWriter(pathToSecondFile))
                {
                    while (!samReader.EndOfStream)
                    {
                        string line = samReader.ReadLine();
                        if (line.Contains(findTheWord))
                        {
                            theWriter.WriteLine(line.Replace(findTheWord, whichWordYouWannaReplaceHomie));
                        }
                        else
                        {
                            theWriter.WriteLine(line);
                        }
                    }
                }

            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


    }
}

