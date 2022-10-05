using System;
using System.IO;

namespace Lecture.Aids
{
    public class Memory_StreamSample
    {
        public static void ReadStream()
        {
            string folder = Environment.CurrentDirectory;
            string file = "input.txt";
            string fullPath = Path.Combine(folder, file);

            byte[] bytes = File.ReadAllBytes(fullPath); // File class has ReadAllBytes(path) that reads all the data in a file to byte array
            Console.Write(bytes);
        }
    }
}
