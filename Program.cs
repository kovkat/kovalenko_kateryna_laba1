using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        public class Parameters
        {
            public int x = 2;
            public int y = 3;
            public void PrintParameters()
            {
                Console.WriteLine("Our parameters");
                Console.WriteLine("x= " + x);
                Console.WriteLine("y= " + y);
                Console.WriteLine("----------");

            }

            public void SummParameters()
            {
                int z;
                z = x + y;
                Console.WriteLine("sum: " + z);
            }

            public void ChangeParameters()
            {
                Random rnd = new Random();
                x = rnd.Next(100);
                y = rnd.Next(100);
            }

            public void CompareParameters()
            {
                if (x > y)
                {
                    Console.WriteLine("The largest value x: " + x);
                }
                else
                {
                    if (x < y)
                    {
                        Console.WriteLine("The largest value y: " + y);
                    }
                    else
                    {
                        Console.WriteLine("y=x, so the largest" + x);
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Do you want 1st or 2nd method?(Enter 1 or 2)");
            int numb = Convert.ToInt32(Console.ReadLine());
            if (numb == 1)
            {
                var par = new Parameters { };
                par.PrintParameters();
                par.ChangeParameters();
                par.PrintParameters();
                par.SummParameters();
                par.CompareParameters();
                File.WriteAllText("par.json", JsonConvert.SerializeObject(par));
            }
            else
            {
                if (numb == 2)
                {
                    if (File.Exists("par.json"))
                    {
                        var par = JsonConvert.DeserializeObject<Parameters>(File.ReadAllText("par.json"));
                        par.PrintParameters();
                        par.ChangeParameters();
                        par.PrintParameters();
                        par.SummParameters();
                        par.CompareParameters();
                    }
                    else
                        Console.WriteLine("File does not exist!");
                }
                else
                {
                    Console.WriteLine("Error! Try again!");
                }
            }

        }
    }
}
