using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "acaa", "aaa", "bde", "abade", "uhd4" };

            //查询有关于a的字符串
            //var query = names.Where(s => s.Contains("a"));
            //查询第一个出现有关于ab的字符串
            var query = names.Where(s => s.Contains("ab")).FirstOrDefault();

            //var query = from x in names
            //            where x.Contains("a")
            //            select x;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            

            //int[] num = { 10, 20, 30, 40, 11, 21, 31, 41 };
            //var query = from x in num
            //            where (x % 2 == 0) && (x > 20)
            //            select x;
            //foreach (var item in query)
            //{
            //    Console.Write(item.ToString() + "");
            //}
            //Console.ReadLine();


            //int[] num = { 10, 20, 30, 40, 11, 21, 31, 41 };
            //var query = from x in num
            //            where x % 2 == 0
            //            select x;
            //foreach (var item in query)
            //{
            //    Console.Write(item.ToString() + "   ");
            //}
            //Console.ReadLine();

        }
    }
}
