using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Numerics;


namespace Projekt22
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] tab = new BigInteger[8];
            
            tab[0] = 100913;
            tab[1] = 1009139;
            tab[2] = 10091401;
            tab[3] = 100914061;
            tab[4] = 1009140611;
            tab[5] = 10091406133;
            tab[6] = 100914061337;
            tab[7] = 1009140613399;
            

            var czasProgramu = new Stopwatch();
            czasProgramu.Start();
            string typAlgorytmu = "Algorytm przyzwoity, pomiar operacji";
            string nazwaPliku = typAlgorytmu + ".csv";

            AddRecord(typAlgorytmu, nazwaPliku);

            for (int t = 0; t <= 7; t++)  
            {
                IsPrime(tab[t], nazwaPliku);     
            }

            czasProgramu.Stop();
            BigInteger pomiarCalkowityResult = czasProgramu.ElapsedMilliseconds;
            pomiarCalkowityResult.ToString();
            Console.WriteLine("Zakonczono dzialanie programu. Czas dzialania programu to: " + pomiarCalkowityResult + "ms.");

            Console.ReadKey();  
        }


        public static void IsPrime(BigInteger liczba, string nazwaPliku)
        {
            
            string isPrime;
            var pomiarJednostkowy = new Stopwatch();
            
            
            pomiarJednostkowy.Start();

                BigInteger i = liczba;
                {

                    bool pierwsza = true;

                for (BigInteger n = 2; n*n <= i; n++) 
                    {
                        if (i % n == 0)
                        {
                            pierwsza = false;
                            break;
                        }
                    }
                    if (pierwsza == true)
                    {
                        isPrime = "Jest to liczba pierwsza.";
                    }
                    else
                    {
                        isPrime = "Nie jest to liczba pierwsza.";
                    }

                    pomiarJednostkowy.Stop();
                    BigInteger pomiarJednostkowyResult = pomiarJednostkowy.ElapsedTicks;
                    pomiarJednostkowyResult.ToString();
                    Console.WriteLine("Zakończono sprawdzanie liczby " + liczba + ". Liczba operacji: " + pomiarJednostkowyResult + ". " + isPrime);
                    AddRecord("", liczba, ";", pomiarJednostkowyResult, nazwaPliku);
                    pomiarJednostkowy.Reset();
                }  
        }

        public static void AddRecord(string typ, string filepath)
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

        public static void AddRecord(string nazwa, BigInteger tabela, string przerwa, BigInteger czas, string filepath)
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

    

