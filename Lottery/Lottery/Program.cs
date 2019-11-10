using System;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            int pick;
            int extra = 0;
            int doubleUp = 0;
            int[] numbers = new int[7];
            Random rnd = new Random();

            //Seitsemän päänumeron arvonta
            for (int i = 0; i < 7; i++)
            {
                pick = (rnd.Next(40) + 1);

                if (CheckDuplicate(numbers, pick) == true)
                {
                    i--;
                } else {
                    numbers[i] = pick;
                }
            }
            Array.Sort(numbers);

            //Lisänumeron arvonta
            do
            {
                pick = (rnd.Next(40) + 1);

                if (CheckDuplicate(numbers, pick) == true)
                {
                    extra = 0;
                }
                else
                {
                    extra = pick;
                }

            } while (extra == 0);

            //Tuplausnumeron arvonta
            do
            {
                pick = (rnd.Next(40) + 1);

                if (CheckDuplicate(numbers, pick) == true)
                {
                    doubleUp = 0;
                }
                else
                {
                    doubleUp = pick;
                }
            } while (doubleUp == 0);

            //Arvontojen tulostus
            Console.WriteLine("Loton oikearivi on:");
            foreach (int number in numbers)
            {
                if (number == numbers[6])
                {
                    Console.Write(number);
                    Console.WriteLine();
                } else
                {
                    Console.Write(number + ", ");
                }
            }

            Console.WriteLine("Lisänumero: " + extra);
            Console.WriteLine("Tuplausnumero: " + doubleUp);
        }

        //Tarkistaa onko annetussa taulukossa jo annettu luku. Palauttaa bool arvon "true" jos on.
        static bool CheckDuplicate(Array list, int number)
        {
            bool result = false;

            foreach (int i in list)
            {
                if (number == i)
                {
                    result = true;
                }
            }
            Console.WriteLine(number);
            return result;
        }
    }
}
