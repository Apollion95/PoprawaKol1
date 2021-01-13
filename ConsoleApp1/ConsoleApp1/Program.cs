using System;
using System.Globalization;

namespace ConsoleApp1
{
    public enum Skrytka
    {
        Pusta,
        Nadanie,
        Odbiór
    }
    public enum Zakres
    {
        OC,
        AC,
        Dom,
        Zycie
    }
    public enum TypSzkody
    {
        Pojazd,
        Dom,
        Szpital,
        Choroba
    }
    class Program
    {
        //zad1
        //Napisz funkcję, która będzie generować tekst na etykietach żywności. 
        //Nadruk powinien składać się z daty ważności (30 dni od aktualnej daty), kod linii produkcyjnej (litera A/B/C) przesłany jako parametr do funkcji i unikalny numer
        //seryjny(A1 i B1 to również unikalne numery)
        public static string Zad1(string litera)
        {
            DateTime localDate = DateTime.Now;
            DateTime expireDate = localDate.AddDays(-30);
            Random losuj = new Random();
            int num = losuj.Next(0, 100);
            string etykieta = "Najlepiej spożyć przed: " + expireDate + " Numer Seryjny: " + litera + num + "";
            return etykieta;
        }
        public static void Zad2()
        {
            Skrytka[,] paczkomat = new Skrytka[10, 5];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Random losuj = new Random();

                    paczkomat[i, j] = (Skrytka)(losuj.Next(0, 3));
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (paczkomat[i, j] == Skrytka.Nadanie)
                    {
                        Console.WriteLine("Z tej skrytki można nadać paczkę" + i + "," + j);
                    }
                    if (paczkomat[i, j] == Skrytka.Odbiór)
                    {
                        Console.WriteLine("Z tej skrytki można odebrać paczkę" + i + "," + j);
                    }
                }
            }

        }
        //zad 2
        //Stwórz tablicę 10x5 reprezentującą paczkomat.Skrytki mogą mieć 3 stany: Pusta, Nadanie i Odbiór.Wypełnij tablicę losowymi wartościami.
        //Wypisz kurierowi do których skrytek może włożyć przesyłki do odbioru a także z których skrytek powinien odebrać nadane przesyłki.
        public class Polisa
        {
            public Polisa(int numer, int dataPoczatkowa, int dataKoncowa, int kwota, Zakres zakres, TypSzkody typSzkody, int dataSzkody)
            {
                int kwotaDoWyplacenia;

                if (kwota < 0)
                {
                    Console.WriteLine("Kwota jest ujemna");
                }
                else
                {
                    Sprawdz(dataSzkody, typSzkody);
                }
                void Sprawdz(int dataSzkody, TypSzkody typSzkody)
                {
                    if (typSzkody == TypSzkody.Pojazd)
                    {
                        if (zakres == Zakres.OC)
                        {
                            kwotaDoWyplacenia = kwota / 10;
                            Console.WriteLine("Polisa OC. Zwrot 10% kwoty " + kwotaDoWyplacenia);
                        }
                        if (zakres == Zakres.OC && zakres == Zakres.AC)
                        {
                            kwotaDoWyplacenia = kwota / 10 * 2;
                            Console.WriteLine("Polisa OC+AC. Zwrot 20% kwoty " + kwotaDoWyplacenia);
                        }
                        }
                        if (typSzkody == TypSzkody.Dom)
                        {
                            kwotaDoWyplacenia = kwota / 10 * 5;
                            Console.WriteLine("Polisa Dom. Zwrot 50% kwoty " + kwotaDoWyplacenia);
                        }
                        if (typSzkody == TypSzkody.Szpital | typSzkody == TypSzkody.Choroba)
                        {
                            kwotaDoWyplacenia = kwota / 10 * 5;
                            Console.WriteLine("Polisa Zycie. Zwrot 50% kwoty " + kwotaDoWyplacenia);
                          }
                }
            }
            static void Main(string[] args)
            {

                Console.WriteLine(Zad1("A"));
                Zad2();

                Polisa p1 = new Polisa(1, 2015, 2020, 350, Zakres.Zycie, TypSzkody.Szpital, 2016);
                Polisa p2 = new Polisa(2, 2015, 2020, -50, Zakres.AC, TypSzkody.Pojazd, 2014);
                Polisa p3 = new Polisa(3, 2015, 2020, 1100, Zakres.OC, TypSzkody.Pojazd, 2014);
                Polisa p4 = new Polisa(4, 2015, 2020, 500, Zakres.Dom, TypSzkody.Dom, 2014);
                Polisa p5 = new Polisa(5, 2015, 2020, 600, Zakres.AC, TypSzkody.Pojazd, 2014);
                Console.WriteLine();

                //zad3
                //Stwórz klasę Polisa.Dodaj do niej właściwości Numer, Zakres(flaga bitowa), DataPoczatkowa, DataKoncowa i Kwota.
                //Zakres powinien mieć opcje OC, AC, Dom, Zycie.Dodaj konstruktor, który wypełni wszystkie pola.Sprawdź czy kwota jest dodatnia - jeśli nie rzuć wyjątek. //komunikat cw //enum
                //Typ AC może być włączony tylko jeśli jest także OC. Data końcowa to zawsze 1 rok od daty początkowej.
                //Dodaj metodę Sprawdz, która przyjmie następujące parametry: DataSzkody i TypSzkody a następnie zwróci kwotę ubezpieczenia do wypłaty.
                // Jeśli typ szkody to słowo "Pojazd", to sprawdź czy polisa zakłada OC i AC. Jeśli tylko OC, zwróć 10 % Kwoty; jeśli OC i AC, zwróć 20 %.
                //Jeśli typ do "Dom", zwróć 50 %.Jeśli typ to "Szpital" lub "Choroba", zwróć 50 %



            }
        }
    }
}

