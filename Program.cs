using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Projekt22
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tab = new int[6];
            tab[0] = 1;
            tab[1] = 100913;
            tab[2] = 1009139;
            tab[3] = 10091401;
            tab[4] = 100914061;
            tab[5] = 1009140611;

            var pomiar = new Stopwatch();
            List<long> pierwsze = new List<long>();

            for (int t = 1; t <= 4; t++)
            {
                Console.WriteLine("Sprawdzam liczbę: " + tab[t]);
                string typ = "Liczba " + tab[t];
             

                pomiar.Start();

                for (long i = tab[t-1]; i < tab[t]; i++)
                {
                    bool pierwsza = true;
                    for (long n = 2; n < i; n++)
                    {
                        if (i % n == 0)
                        {
                            pierwsza = false;
                            break;
                        }
                    }
                    if (pierwsza)
                    {
                        pierwsze.Add(i);
                    }
                  
                }
                pomiar.Stop();
                long pomiarresult = pomiar.ElapsedMilliseconds;
                pomiarresult.ToString();
                Console.WriteLine("Zakończono sprawdzanie liczby " + tab[t]+". Czas: " + pomiarresult+"ms. Łącznie znalezionio "+pierwsze.Count + " liczb pierwszych");
                addRecord("", tab[t], ";", pomiarresult, "Pomiar.csv");
                pomiar.Reset();
                pierwsze.Clear();
                
            }
            Console.WriteLine("Zakonczono dzialanie programu.");
            Console.ReadKey();

        }
        public static void addRecord(string typ, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(typ);
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("", ex);
            }
        }

        public static void addRecord(string nazwa, int tabela, string przerwa, long czas, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(nazwa + tabela + przerwa + " " + czas);
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("", ex);
            }
        }

    }
}

    

