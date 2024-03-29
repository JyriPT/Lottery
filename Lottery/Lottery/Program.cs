﻿using System;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alustetaan arvonnassa tarvittavat muuttujat sekä tulostaulukko
            int pick;
            int extra = 0;
            int doubleUp = 0;
            int[] numbers = new int[7];
            Random rnd = new Random();

            //Seitsemän päänumeron arvonta
            #region Main draw
            //Looppi käydään läpi 7 kertaa, enemmän jos arvotaan sama numero
            //Arvotaan numero ja tarkistetaan ettei sitä ole jo valittu, lisätään tulostaulukkoon
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
            #endregion

            //Lisänumeron arvonta
            #region Extra
            //Arvotaan lisänumero, varmistetaan ettei arvottua numeroa ole tulostaulukossa
            //Jos on, arvotaan uudestaan kunnes löytyy käyttämätön luku
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
            #endregion

            //Tuplausnumeron arvonta
            #region Double
            //Arvotaan tuplausnumero, varmistetaan ettei arvottua luku ole vielä tulostaulukossa
            //Jos on, arvotaan uudestaan kunnes löytyy käyttämätön luku
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
            #endregion

            #region Print out
            //Arvontojen tulostus
            Console.WriteLine("Loton oikearivi on:");
            //Toistorakenne varmistaa mallin mukaisen kirjoitusasun lottoriville
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
            //Lisä- ja tuplausnumero tulostetaan mallin mukaisesti omillaan'
            Console.WriteLine("Lisänumero: " + extra);
            Console.WriteLine("Tuplausnumero: " + doubleUp);
            #endregion
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
            return result;
        }
    }
}
