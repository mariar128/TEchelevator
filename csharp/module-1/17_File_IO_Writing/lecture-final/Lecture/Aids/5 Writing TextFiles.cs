using System;
using System.IO;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {
            //setup for file
            //string directory = @"C:\Users\Student\Curriculum\instructor-code\csharp\module-1\17_File_IO_Writing\lecture\Lecture";
            string directory = Environment.CurrentDirectory;
            //@ signifies that the following string is a file path and that the \ do not need to be escaped
            string fileName = "output.txt";

            string fullPath = Path.Combine(directory, fileName);
            

            try
            {
                //make sure to use the using statement 
                using (StreamWriter sw = new StreamWriter(fullPath)) //output.txt will be created since it doesn't exist 
                {
                    sw.WriteLine("This is the start of my first file!"); //writes a line to the file

                    sw.Write("Hello ");
                    sw.Write("World!"); //I should get "Hello World!" on one line with these two lines here 

                    sw.WriteLine(); // one empty line at the end 

                    sw.WriteLine("Tech Elevator!"); 

                }


            }
            catch(IOException ex)
            {
                Console.WriteLine("Oops, something went wrong writing output.txt."); 
            }

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}
