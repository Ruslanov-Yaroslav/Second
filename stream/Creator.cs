using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace stream
{
    class Creator
    {
        string txtPath = "C:\\Main\\2.txt";
        string csvPath = "C:\\Main\\1.csv";
        string fileToWritePath  = "C:\\Main\\3.txt";
        string path = "";
        public List<int> intFromTextFile;


        public Creator(List<int> intFrom)
        {
            this.intFromTextFile = intFrom;
        }

        public void Hello()
        {
            Console.WriteLine("Hello!!! I glad to see you");
            Console.WriteLine("Now we have to choose the file type");
            Console.WriteLine("If you want to select TXT file then press 'txt', and for CSV press 'csv'");
            var tmp = Console.ReadLine();
            do
            { 
                if (tmp == "txt")
                {
                    path = txtPath;
                    break;
                }
                else if (tmp == "csv")
                {
                    path = csvPath;
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry but you made a mistake. Write it again");
                    tmp = Console.ReadLine();
                }
            }
            while (tmp != "txt" || tmp != "csv");
        }
       
        public IEnumerable<int> ReadFromTextFile()
        {
            try
            {
                string s = Path.GetFileName(path);
                StreamReader sr = new StreamReader(path);
                var line = sr.ReadToEnd();
                if (s.Contains(".txt"))
                {
                    var splitedList = line.Split(' ');
                    foreach (var x in splitedList)
                    {
                        var toInt = Int32.Parse(x);
                        intFromTextFile.Add(toInt);
                    }
                }
                if (s.Contains(".csv"))
                {
                    var splitedList = line.Split(',');
                    foreach (var x in splitedList)
                    {
                        var toInt = Int32.Parse(x);
                        intFromTextFile.Add(toInt);
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return intFromTextFile;
        }

        public int SumOfNumbers(List<int> a)
        {
            return a[0] + a[1];
        }

        public int MuliplyOfNumbers(List<int> a)
        {
           return a[0] * a[1];
        }

        public int  DivideFirstAndSecond(List<int> a)
        {
            try
            {
                return a[0] / a[1];
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}

