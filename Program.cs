using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Program
{
    // See https://aka.ms/new-console-template for more information
    static void Main(string[] args)
    {
        //Урок 1 "Hello world"

        Console.WriteLine("Hello, World!");
        Console.WriteLine("Привет, мир");

        //Урок 4 - Типы

        int a;
        a = 0;
        Console.WriteLine(a);

        int c, b;
        c = 9;
        b = 99;
        Console.WriteLine(c);
        Console.WriteLine(b);

        bool e = true;
        bool d = false;

        Console.WriteLine(d);
        Console.WriteLine(e);

        double f = 22.8;
        Console.WriteLine(f);

        char g = '@';
        Console.WriteLine(g);

        string i = "Акуна Матата";
        Console.WriteLine(i);

        int m = 12;
        Console.WriteLine(m);

        m = 120;
        Console.WriteLine(m);

        //Урок 5 Ввод данных в консоль


        string l = "Назови свое имя";
        Console.WriteLine(l);
        string k;
        k = Console.ReadLine();
        Console.WriteLine("Привет, " + k + ", введи число 1");

        //Урок 6. Класс Convert.

        string j;
        //Как консоль видит "p" и "r"?
        int p, r;
        float ss=0;
        j = Console.ReadLine();
        p = Convert.ToInt32(j);
        Console.WriteLine("А теперь число 2");
        j = Console.ReadLine();
        r = Convert.ToInt32(j);

        Console.WriteLine("Ввди операцию +,-,*,/ над числами");
        j = Console.ReadLine();
        if (j == "+")
        {
            ss = calcAdd(p, r);
        }
        if (j == "-")
        {
            ss = calcAdd(p, -r);
        }
        if (j == "*")
        {
            ss = calcMultiply(p, r);
        }
        if (j == "/")
        {
            ss = calcDiff(p, r);
            if (ss==float.PositiveInfinity || ss==float.NegativeInfinity) 
            {
                Console.WriteLine("делили на ноль!");
            }
        }
        //вызов функций - сложение, умножение, вычитание, деление
        Console.WriteLine("Итак, " + k + ", результат = " + ss);



        //Урок 7. Класс Parse.
        Console.WriteLine("А теперь число TRY");
        string t = Console.ReadLine();

        //Метод try catch
        try
        {
            int u = int.Parse(t);
            Console.WriteLine("Успех");
        }
        catch (Exception ex)
        {
            //обработка исключения - записать файл, сообщить пользоователю, отправить инфу сисадмину
            Console.WriteLine("Неудача " + ex.Message);
        }
        //Метод if else
        //Старался сделать по-своему, 
        string v;
        int w;
        Console.WriteLine("Введи целое число");
        v = Console.ReadLine();
        bool x = int.TryParse(v, out w);
        if (x != false) // x==true
        {
            Console.WriteLine("Успех. Значение = " + w);
        }
        else
        {
            Console.WriteLine("Неудача");
        }
        // И ИЛИ НЕ - И && ИЛИ ||  отрицание != сравнение ==
        // w > 100 || w<-100
        // w!=100
        if (w > 100 && w < 200)
        { }
        //генератор случайных чиел
        Random rand = new Random();
        int chisli = rand.Next(1, 100);
    }
    static int calcAdd(int a, int b)
    {
        int res = a + b;
        return res;
    }
    static int calcMultiply(int a, int b)
    {
        int res = a * b;
        return res;
    }
    static float calcDiff(int a, int b)
    {
        //надо преобразовать а во float потому что иначе деление целочисленное
        float res = (float)a / b;
        return res;
    }
}
