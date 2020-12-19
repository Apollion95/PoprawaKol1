using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            //zad1
            //Napisz funkcję, która będzie generować tekst na etykietach żywności. 
            //Nadruk powinien składać się z daty ważności (30 dni od aktualnej daty), kod linii produkcyjnej (litera A/B/C) przesłany jako parametr do funkcji i unikalny numer
            //seryjny(A1 i B1 to również unikalne numery)
            string kod;
            
            Random losujsn = new Random(); //generowanie s/n
            int numsn = losujsn.Next(0, 100);
            Random losuj = new Random();
            int num = losuj.Next(0, 4);
            char litera = (char)('A' + num);
            DateTime localDate = DateTime.Now;
            DateTime expireDate = localDate.AddDays(30);
            Console.WriteLine("Najlepiej spożyć przed "+expireDate+" numer seryjny "+litera+numsn+"");
            Console.ReadKey();
            //zad 2
            //Stwórz tablicę 10x5 reprezentującą paczkomat.Skrytki mogą mieć 3 stany: Pusta, Nadanie i Odbiór.Wypełnij tablicę losowymi wartościami.
            //Wypisz kurierowi do których skrytek może włożyć przesyłki do odbioru a także z których skrytek powinien odebrać nadane przesyłki.

   
        }
    }
}
