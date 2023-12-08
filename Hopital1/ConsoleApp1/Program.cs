using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFile();
            Console.ReadKey();
        }
        static void TestFile()
        {
            new TimeFile().File();
        }
        static void TestTime()
        {
            DateTime date;
            date = DateTime.Now;
            Time t = new Time();
            //Console.WriteLine(DateTime.Now);
            t.Insert();
        }
        static void Test()
        {
            Hopital h = Hopital.Instance;
            //Patient p1 = new Patient();
            //Patient p2 = new Patient();
            //h.Add(p1);
            //h.Add(p2);
            //h.Remove();
            //Console.WriteLine(h.CheckQueue());
        }
    }
}
