using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace zad4pr16
{
    internal class Program
    {
        static void Main(string[] args)
        {// 5.1, 1, 3, 9.2, 2, 3, 5.1, 3 
            if (File.Exists("1.txt"))
            {
                string[] bb = File.ReadAllLines("1.txt");
                double[] numbers = new double[bb.Length];
                for (int i = 0; i < bb.Length; i++)
                {
                    try
                    {
                        numbers[i] = Convert.ToDouble(bb[i]);
                    }catch (Exception)
                    {
                        WriteLine($"Число в {i}-й строке написано неправильно") ;
                    }
                }
                var num = numbers
                       .GroupBy(n => n)
                       .Select(g => new { Number = g.Key, Frequency = g.Count() });
                WriteLine("Число\tЧастота");
                WriteLine("-----------------");
                foreach (var n in num)
                {
                    WriteLine($"{n.Number}\t{n.Frequency}");
                }


                var newArray = numbers
                    .Select(n => n * num.First(nf => nf.Number == n).Frequency);
                var nums = newArray
                    .GroupBy(n => n)
                    .Select(g => new { Number = g.Key, Frequency = g.Count() });

                WriteLine("\nЧисло\tЧастота (старого массива)");
                WriteLine("-----------------");
                foreach (var n in nums)
                {
                    WriteLine($"{n.Number}\t{n.Frequency}");
                }
            }
            else WriteLine($"Файл (1.txt) не существует!!");

            ReadKey();
        }
    }
}
