using HashtableTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, int> d = new HashDictionary<int, int>();
            TestDriver.Instance.Run(d, 10000);

            var t = new HashDictionary<GeoLocation, int>();
            t.Add(new GeoLocation(1, 2), 1);
            //t.Add(new GeoLocation(1, 2), 1);

            var x = t[new GeoLocation(1, 2)];
            Console.WriteLine(x);
        }
    }
}
