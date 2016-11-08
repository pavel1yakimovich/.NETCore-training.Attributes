using System;
using static Validators.Validator;

namespace Creator
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Creator.CreateUsers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("Int: " + (IntValidator(item) ? "Valid" : "Invalid"));
                Console.WriteLine("String: "+ (StringValidator(item) ? "Valid" : "Invalid"));
            }

            foreach (var item in Creator.CreateAdvancedUsers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("Int: " + (IntValidator(item) ? "Valid" : "Invalid"));
                Console.WriteLine("String: " + (StringValidator(item) ? "Valid" : "Invalid"));
            }
            Console.ReadKey();
        }
    }
}
