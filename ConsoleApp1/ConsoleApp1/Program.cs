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
    [Flags]
    public enum Zakres
    {
        OC = 1,
        AC = 2,
        Dom = 4,
        Zycie = 8
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
            DateTime expireDate = localDate.AddDays(+30);
            Random losuj = new Random(DateTime.Now.Millisecond);
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
            int numer;
            int kwota { get; set; }
            Zakres zakres;
            TypSzkody typSzkody;
            static DateTime dataPoczatkowa = DateTime.Now;
            DateTime dataKoncowa = dataPoczatkowa.AddDays(+365);
            DateTime dataSzkody = DateTime.Now;
            int kwotaDoWyplacenia;

            public Polisa(int numer, DateTime dataPoczatkowa, int kwota, Zakres zakres, TypSzkody typSzkody, DateTime dataSzkody)
            {


                if (kwota < 0)
                {
                    Console.WriteLine("Kwota jest ujemna");
                }
                else
                {
                    Sprawdz(dataSzkody, typSzkody, kwota, zakres);
                }

            }
            void Sprawdz(DateTime dataSzkody, TypSzkody typSzkody, int kwota,Zakres zakres)
            {
                if (typSzkody == TypSzkody.Pojazd)
                {
                    if (zakres == Zakres.AC)
                    {
                        kwotaDoWyplacenia = kwota / 10 * 2;
                        Console.WriteLine("Polisa OC+AC. Zwrot 20% kwoty " + kwotaDoWyplacenia);
                    }
                    if (zakres == Zakres.OC)
                    {
                        kwotaDoWyplacenia = kwota / 10;
                        Console.WriteLine("Polisa OC. Zwrot 10% kwoty " + kwotaDoWyplacenia);
                    }
                }
                if (typSzkody == TypSzkody.Dom)
                {
                    kwotaDoWyplacenia = kwota / 10 * 5;
                    Console.WriteLine("Polisa Dom. Zwrot 50% kwoty " + kwotaDoWyplacenia);
                }
                if (typSzkody == TypSzkody.Szpital || typSzkody == TypSzkody.Choroba) 
                {
                    kwotaDoWyplacenia = kwota / 10 * 5;
                    Console.WriteLine("Polisa Zycie. Zwrot 50% kwoty " + kwotaDoWyplacenia);
                }
            }
        }
        //zad3
        //Stwórz klasę Polisa.Dodaj do niej właściwości Numer, Zakres(flaga bitowa), DataPoczatkowa, DataKoncowa i Kwota.
        //Zakres powinien mieć opcje OC, AC, Dom, Zycie.Dodaj konstruktor, który wypełni wszystkie pola.Sprawdź czy kwota jest dodatnia - jeśli nie rzuć wyjątek. 
        //Typ AC może być włączony tylko jeśli jest także OC. Data końcowa to zawsze 1 rok od daty początkowej.
        //Dodaj metodę Sprawdz, która przyjmie następujące parametry: DataSzkody i TypSzkody a następnie zwróci kwotę ubezpieczenia do wypłaty.
        // Jeśli typ szkody to słowo "Pojazd", to sprawdź czy polisa zakłada OC i AC. Jeśli tylko OC, zwróć 10 % Kwoty; jeśli OC i AC, zwróć 20 %.
        //Jeśli typ do "Dom", zwróć 50 %.Jeśli typ to "Szpital" lub "Choroba", zwróć 50 %
        static void Main(string[] args)
        {

            Console.WriteLine(Zad1("A"));
            Zad2();
            DateTime dataPoczatkowa = DateTime.Now;
            Polisa p1 = new Polisa(1, dataPoczatkowa, 500, Zakres.OC , TypSzkody.Pojazd, DateTime.Now);
            Polisa p2 = new Polisa(2, dataPoczatkowa, 500, Zakres.AC, TypSzkody.Pojazd, DateTime.Now);
            Polisa p3 = new Polisa(3, dataPoczatkowa, 1100, Zakres.Zycie, TypSzkody.Szpital, DateTime.Now); 
            Polisa p4 = new Polisa(4, dataPoczatkowa, 500, Zakres.Dom, TypSzkody.Dom, DateTime.Now); 
            Polisa p5 = new Polisa(5, dataPoczatkowa, 600, Zakres.Dom, TypSzkody.Szpital, DateTime.Now);
        }

    }
}


