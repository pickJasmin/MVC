using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var musicalList = new List<Musical>();

            Musical m = new Musical();
            m.musicalID = "001";
            m.musicalName="尤克里里";
            musicalList.Add(m);

            m = new Musical();
            m.musicalID = "002";
            m.musicalName = "吉他";
            musicalList.Add(m);




            foreach (var item in musicalList)
            {
                Console.WriteLine("musicalID:{0},musicalName:{1}", item.musicalID, item.musicalName);
            }
            Console.Read();

        }
    }
}
