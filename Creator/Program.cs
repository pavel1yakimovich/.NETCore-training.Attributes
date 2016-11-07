using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Creator.CreateUsers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
