using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int kumulacja;
        static int Start = 40;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int hajs = Start;
            int dzien = 0;
            do
            {
                hajs = Start;
                dzien = 0;
                ConsoleKey wybor;
                do
                {
                    kumulacja = rnd.Next(2, 37) * 1000000;
                    dzien++;
                    int losow = 0;
                    List<int[]> kupon = new List<int[]>();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Dzień: {0}", dzien);
                        Console.WriteLine(" Witaj w grze LOTTo, dzis do wygrania jest aż {0} zł", kumulacja);
                        Console.WriteLine("\nStan Konta: {0}zł", hajs);
                        WyswietlKuoon(kupon);

                        if (hajs >= 3 && losow < 8) 
                        {
                            Console.WriteLine("1 - Postaw lost -3 [{0}/8]", losow + 1);
                        }
                        Console.WriteLine("2 - Sprawdz kupon - losowanie");
                        Console.WriteLine("3 - zakończ grę");

                        wybor = Console.ReadKey().Key;
                        if (wybor == ConsoleKey.D1 && hajs >= 3 && losow < 8) 
                        {
                            kupon.Add(PostawLos());
                            hajs -= 3;
                            losow++;

                        }
                    } while (wybor == ConsoleKey.D1);
                    Console.Clear();
                    if(kupon.Count > 0)
                    {
                        int wygrana = Sprawdz(kupon);
                        if(wygrana > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nWgrałeś {0}zł w tym losowaniu", wygrana);
                            Console.ResetColor();
                            hajs += wygrana;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPrzegrałeś {0}zł w tym losowaniu", wygrana);
                            Console.ResetColor(); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie miałeś losów w tym losowaniu");

                    }
                    Console.WriteLine("Enter - kontynuuj");
                    Console.ReadKey(); 

                } while (hajs >= 3 && wybor != ConsoleKey.D3);

                Console.Clear();
                Console.WriteLine("Dzień{0}. \nkoniec gry, twoj wynik to : {1}) zł", dzien, hajs - Start);
                Console.WriteLine("Enter - graj od nowa");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
        private static int Sprawdz(List<int[]> kupon)
        {
            int wygrana = 0;
            int[] wylosowane = new int[6];
            for (int i = 0; i < wylosowane.Length; i++)
            {
                int los = rnd.Next(1, 50);
                if(!wylosowane.Contains(los))
                {
                    wylosowane[i] = los;
                }
                else
                {
