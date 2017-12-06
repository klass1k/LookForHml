using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookForHml
{
    class Program
    {
        static void Main(string[] args)
        {
            LookFor lf = new LookFor();
            //DirSearch(@"D:\English\pre\New English File Class CD Pre-Intermediate (mp3 split up version)(2005)");
            string directoryPath = @"D:\English\pre";
            foreach (var item in lf.GetHtml(directoryPath).Distinct())
            {
                Console.WriteLine(item.FullName);
            }
            Console.ReadKey();
        }      

    }
}

