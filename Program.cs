using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        int b = 4;
        static void Main(string[] args)
        {
            int a = 5;
            bool b = false;
            Console.WriteLine("hello world");
            //процедура - кусок кода со своим именем например Main и набором аргументов с которыми она работает
            //функция - возвращает какой-то результат в вызывающий ее код
            int result = 0;
            //функция работает но резулььтат никуда не пишется
            calcAdd(4, 5);
            //результат пишется в переменную result
            result = calcAdd(4, 5);
            int aaa = Convert.ToInt32( Console.ReadLine() );
            int bbb = Convert.ToInt32( Console.ReadLine() );

            result = calcAdd(aaa, bbb);

            Console.WriteLine("result="+ result);
            //задержка ввода в конце (ждем чтоб пользователь что нажал)
            Console.ReadLine();
        }

        static int calcAdd(int a, int b)
        {
            int res = a + b;
            return res; 
        }

    }
}
