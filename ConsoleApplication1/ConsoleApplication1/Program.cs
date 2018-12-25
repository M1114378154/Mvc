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
            string[] names = { "abc", "aaa", "bda", "xdsd" };
            var query1 = from x in names
                         where x.Contains("a") //Contains返回一个值，该值指示指定的子串是否出现在此字符串中
                         select x;
            foreach (var item in query1)
            {
                Console.Write(item.ToString() + " ");
            }

            //静态成员调用 类名.方法名
            //int y = String.Compare(str, "abc");
            Console.ReadKey();




            //int[] numList = { 10, 20, 30, 40, 11, 21, 31, 34 };
            ////查询语法
            //var query1 = from x in numLi st
            //            where x % 2 == 0 //求偶数
            //            select x;
            //var query2 = numList.Where(x => x % 2 == 0).OrderBy(x => x).FirstOrDefault();
            ////执行查询
            //foreach (var item in query1)
            //{
            //    Console.Write(item.ToString() + " ");
            //}
            //Console.ReadKey();
        }
    }
}
