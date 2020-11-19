using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusSolutionsLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lottoNumbers = new List<int>();

            int lowerNumber;
            int higherNumber;
            int counter;

            Random rnd = new Random();

            if(!int.TryParse(ConfigurationManager.AppSettings["LowerValue"].ToString(), out lowerNumber))
            {
                lowerNumber = 1;
            }

            if (!int.TryParse(ConfigurationManager.AppSettings["UpperValue"].ToString(), out higherNumber))
            {
                higherNumber = 1;
            }

            if (!int.TryParse(ConfigurationManager.AppSettings["Balls"].ToString(), out counter))
            {
                counter = 6;
            }

            while (lottoNumbers.Count < 6)
            {
                int number = rnd.Next(lowerNumber, higherNumber);

                if (!lottoNumbers.Contains(number))
                {
                    lottoNumbers.Add(number);
                }
            }

            foreach(int lottoNumber in lottoNumbers.OrderBy(ln => ln))
            {
                if (lottoNumber <= 9)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (lottoNumber >= 9 && lottoNumber <= 19)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if(lottoNumber >= 20 && lottoNumber <= 29)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }

                if (lottoNumber >= 30 && lottoNumber <= 39)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (lottoNumber >= 40 && lottoNumber <= 49)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(lottoNumber);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press Any Key to Exit");

            Console.ReadLine();
        }
    }
}
