using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace stream
{
    class Program
    {
        static void Main(string[] args)
        {
            char forTxt = ' ';
            char forCsv = ',';
            char usingChar;
            string fileToWritePath = $"C:\\Main\\output_23-02-2022.txt";
            List<int> f = new List<int>();
            Creator test = new Creator( f);


            test.Hello();
            test.ReadFromTextFile();
            foreach(var x in f)
            {
                Console.WriteLine(x);
            }
            if (fileToWritePath.Contains("txt"))
            {
                usingChar = forTxt;
            }
            else
            {
                usingChar = forCsv;
            }
            try
            {
                FileStream  fstream = new FileStream(fileToWritePath, FileMode.OpenOrCreate);
                fstream.Close();
                using (StreamWriter writer = new StreamWriter(fileToWritePath, true))
                {
                    writer.WriteLine($"{f[0]}{usingChar}{f[1]}{usingChar}{test.SumOfNumbers(f)}{usingChar}" +
                        $"{test.MuliplyOfNumbers(f)}{usingChar}{test.DivideFirstAndSecond(f)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine($"THX))) File in Path : {fileToWritePath}  was successfully written!))))");
        }
    }
}
