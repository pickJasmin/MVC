using ClssApplication2.BusinessLayer;
using ClssApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClssApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            crateClass();
            //QueryClass();
            //Update();
            //Delete();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void crateClass()
        {
            Console.WriteLine("请输入一个班级");
            string name = Console.ReadLine();
            Class Cls = new Class();
            Cls.ClassName = name;
            ClassBusinessLayer cbl = new ClassBusinessLayer();
            cbl.Add(Cls);
        }
        static void QueryClass()
        {
            ClassBusinessLayer cbl = new ClassBusinessLayer();
            var classes = cbl.Query();
            foreach (var item in classes)
            {
                Console.WriteLine(item.ClassId + " " + item.ClassName);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入班级id");
            int id = int.Parse(Console.ReadLine());
            ClassBusinessLayer cbl = new ClassBusinessLayer();
            Class classed = cbl.Query(id);
            Console.WriteLine("请输入新的班级名字");
            string name = Console.ReadLine();
            classed.ClassName = name;
            cbl.Update(classed);

        }
        static void Delete()
        {
            ClassBusinessLayer cbl = new ClassBusinessLayer();
            Console.WriteLine("请输入一个班级的id");
            int id = int.Parse(Console.ReadLine());
            Class classes = cbl.Query(id);
            cbl.Delete(classes);

        }
    }
}
