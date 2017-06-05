using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using f = MyNamespaceOne;
using s = MyNamespaceTwo;

namespace ConsoleApplication1
{

    public class Test
    {
        static async Task Download()
        {
            Console.WriteLine(await GetUrlContents());
        }

         static Task<string> GetUrlContents()
        {
            WebClient webClient = new WebClient();
            Task<string> content = webClient.DownloadStringTaskAsync("http:\\google.com");

            return content;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate c = new Coordinate(100,200);
            c *= 2;

            string one = "My";
            string two = null;
            string three = two + one;
            Console.WriteLine(three); 

            List<int> test = new List<int>();
            test.Add(1);
            test.Add(2);

            IEnumerator<int> t = test.GetEnumerator();
            while (t.MoveNext())
            {
                Console.WriteLine(t.Current);
            }
     
            String string1 = "One";
            String string2 = "One";

            StringBuilder stringBuilder1 = new StringBuilder("One");
            StringBuilder stringBuilder2 = new StringBuilder("One");

            List<Object> list = new List<object>();

            list.Add(string1);
            list.Add(stringBuilder1);

            Console.WriteLine(list.Contains(string2));
            Console.WriteLine(list.Contains(stringBuilder2));
            Console.WriteLine(list.Contains(stringBuilder2.ToString()));

            String my1 = String.Format("One {0} Three", "Two");


            bool? a = null, b = null;
            writeOutput(a & b);
            writeOutput(a | b);
            a = true;
            writeOutput(a & b);
            writeOutput(a | b);
            b = false;
            writeOutput(a & b);
            writeOutput(a | b);

        }

        private static void RunProgram()
        {
            throw new NotImplementedException();
        }

        static void writeOutput(object o)
        {
            if (o == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(o.ToString());
            }
        }
    }

    internal class Coordinate
    {
        public Coordinate(int i, int i1)
        {
            X = i;
            Y = i1;
        }

        public static Coordinate operator *(Coordinate c, int factor)
        {
            return new Coordinate(c.X * factor, c.Y * factor);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public int Y { get; private set; }

        public int X { get; private set; }
    }
}