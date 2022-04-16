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
            double cource = Convert.ToDouble(course);

            //for (int i = 0; i < line.Length; i++)
            //{
            //    if line[i]=='$'
            //}

            //XmlDocument doc = new XmlDocument();

            //doc.LoadXml(line);



            //Для переезда в Америку мне нужно 25000 долларов
            double migration = 25000;

            //Введенная сумма пользователем
            double money;

            Console.WriteLine("Для переезда в Америку вам нужно 25000. Введите сколько у вас денег в рублях для того, чтобы узнать, хватит ли вам ресурсов");
            Console.WriteLine("Нынешний курс доллара составляет " + cource + " рублей");

            money = double.Parse(Console.ReadLine());

            if ((money * cource) > (migration * cource))
            {
                Console.WriteLine("Ваших ресурсов хватает на переезд");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Копите деньги. Вашего финанса не хватит на комфортную жизнь в Америке");
                Console.WriteLine("Для комфортной жизни в Америке вам нужно " + (cource * migration) + " рублей");
                Console.ReadLine();
            }

        }
    }
}
