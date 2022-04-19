using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;

namespace Lesson2

//Задача "Хватит ли мне денег на переезд в Америку ,если я переведу свои рубли в долларовую валюту"
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Курс доллара составляет 
            //курс доллара. Http - http response.
            //double cource = 79.99;
            // GET по адресу:        http://www.cbr.ru/scripts/XML_daily.asp

            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            //ответ на запрос в Интернет
            WebResponse response = null;
            //для получения ответа
            StreamReader strReader = null;
            //сам запрос по ссылке
            WebRequest request = WebRequest.Create(url);
            //получаем ответ из Интернета с сайта ЦБ
            response = request.GetResponse();
            //открываем ответ на чтение   
            strReader = new StreamReader(response.GetResponseStream());
            //читаем ответ в строку
            string line = strReader.ReadToEnd();
            //нужно закрыть соединение
            response.Close();
            //теперь есть строка line. надо в ней найти курс Доллара
            //строка - массив символов (есть длина, есть поиск, есть цикл for по массиву..)
            //возможности C# - поиск по строке встроен

            int posUSD = line.IndexOf("USD");//ищем USD
            int positionValue = line.IndexOf("Value", posUSD);
            int posBeginCourse = positionValue + 6;
            string course = line.Substring(posBeginCourse, 7);
            double courceUSD = Convert.ToDouble(course);


            int posEU = line.IndexOf("EUR");//ищем EU
            int positionValueEU = line.IndexOf("Value", posEU);
            int posBeginCourseEU = positionValueEU + 6;
            string courseEU = line.Substring(posBeginCourseEU, 7);
            double courceEU = Convert.ToDouble(courseEU);


            //for (int i = 0; i < line.Length; i++)
            //{
            //    if line[i]=='$'
            //}


            string a = "";
            for (int i = 0; i < 15; i++)
            {
                a = a + i.ToString() + " ";//вот это работает медленно
            }
            //быстро работающий прибавлятор строк
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 15; i++)
            {
                sb.Append(i.ToString());
                sb.Append(" ");
            }
            string res = sb.ToString();


            //Для переезда в Америку мне нужно 25000 долларов
            double migrationUSD = 25000;
            double migrationEU = 32000;

            //Введенная сумма пользователем
            double money;

            int choice;


            Console.WriteLine("Мы предлагаем вам калькулятор, способный высчитать в нужной вам валюте возможность переезда в Америку или Германию.");
            Console.WriteLine("Нынешний курс доллара составляет " + courceUSD + " рублей, а курс Евро составляет " + courceEU + "рублей.");
            Console.WriteLine("Если вы хотите переехать в Америку - введите цифру 1 и нажмите Enter. Если вы хотите переехать в Германию - введите цифру 2 и нажмите Enter. Введите 3 для выхода");
            choice = int.Parse(Console.ReadLine());
            //Как остановить while?
            while ( choice != 3 )
            {

           
                if (choice == 1)
                {
                    Console.WriteLine("Введите сумму ваших денег в рублёвом эквиваленте и нажмите enter");
                    money = double.Parse(Console.ReadLine());

                    if ((money / courceUSD) > (migrationUSD * courceUSD))
                    {
                        Console.WriteLine("Ваших ресурсов хватает на переезд в Америку");
                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Копите деньги. Вашего финанса не хватит на комфортную жизнь в Америке");
                        Console.WriteLine("Для комфортной жизни в Америке вам нужно " + (courceUSD * migrationUSD) + " рублей");
                        Console.ReadLine();
                        Console.WriteLine("Спасибо за использование нашего калькулятора");
                    }
                }
                if (choice == 2)
                {
                    Console.WriteLine("Введите сумму ваших денег в рублёвом эквиваленте и нажмите enter");
                    money = double.Parse(Console.ReadLine());

                if ((money / courceEU) > (migrationEU * courceEU))
                {
                    Console.WriteLine("Ваших ресурсов хватает на переезд в Германию");
                    Console.ReadLine();
                }

                else
                {
                    Console.WriteLine("Копите деньги. Вашего финанса не хватит на комфортную жизнь в Германии");
                    Console.WriteLine("Для комфортной жизни в Германии вам нужно " + (courceEU * migrationEU) + " рублей");
                    Console.ReadLine();
                    Console.WriteLine("Спасибо за использование нашего калькулятора");
                }

                }
                if ((choice != 1) || (choice != 2)) 
                {
                    Console.WriteLine("Введите правильное число");
                    choice = int.Parse(Console.ReadLine());
                
                }
            }
        }
    }
}
