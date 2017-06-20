using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SecondHighestNumber
{
    // Find 2nd highest number in list
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {5, 6, 7, 9, 0, 1, 2, 3, 4, 8};

            var one = new Version1();

            WriteLine("Version1: " + one.Find(list));

            var two = new Version2();

            WriteLine("Version2: " + two.Find(list));

            ReadLine();
        }
    }

    public class Version1
    {
        public int Find(List<int> list)
        {
            return list.OrderByDescending(x => x)
                .Distinct()
                .Skip(1)
                .First();
        }
    }

    public class Version2
    {
        public int Find(List<int> list)
        {
            int max = int.MinValue;
            int second = Int32.MinValue;

            foreach (int value in list)
            {
                if (value > max)
                {
                    second = max;
                    max = value;
                }
                else
                {
                    if (value > second)
                    {
                        second = value;
                    }
                }
            }

            return second;
        }
    }
}
