using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Gauss_pidar gp = new Gauss_pidar(new double[,] 
            {
                {2,15,2 },
                {1,15,1 },
                {2,5,1 }
            });
            Console.WriteLine(gp);
            Console.WriteLine(gp.GaussDet());
            Console.WriteLine(gp);
            Console.ReadKey();
        }
    }
}
