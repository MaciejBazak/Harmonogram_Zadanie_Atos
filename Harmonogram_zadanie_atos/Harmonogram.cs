using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonogramNs
{
    public class Harmonogram
    {

        Dictionary<int, int> harmonogram = new Dictionary<int, int>();
        int pierwszaNiedziela;
        int liczbaDniRoboczych;

        public Harmonogram(Dictionary<int, int> harm, int niedziela)
        {
            harmonogram = harm;
            pierwszaNiedziela = niedziela;


            foreach (KeyValuePair<int, int> kvp in harmonogram)
            {
                if (kvp.Key == pierwszaNiedziela | kvp.Key == pierwszaNiedziela + 7 | kvp.Key == pierwszaNiedziela + 14 | kvp.Key == pierwszaNiedziela + 21 | kvp.Key == pierwszaNiedziela + 28)
                {
                    Console.WriteLine("Key = {0}, Value = {1} TU NIEDZIELA", kvp.Key, kvp.Value);
                }
                else if (kvp.Key == pierwszaNiedziela - 1 | kvp.Key == pierwszaNiedziela + 6 | kvp.Key == pierwszaNiedziela + 13 | kvp.Key == pierwszaNiedziela + 20 | kvp.Key == pierwszaNiedziela + 27)
                {
                    Console.WriteLine("Key = {0}, Value = {1} TU SOBOTA", kvp.Key, kvp.Value);
                }
                else
                {
                    Console.WriteLine("Key = {0}, Value = {1} Dzień roboczy", kvp.Key, kvp.Value);
                    liczbaDniRoboczych++;
                }

            }
        }

        public Dictionary<int, int> getHarmonogram()
        {
            return harmonogram;
        }

        public int getLiczbaDniRoboczych()
        {
            return liczbaDniRoboczych;
        }

        public bool CzyPrzekracza()
        {
            int maxGodziny = 8 * liczbaDniRoboczych;
            int pracGodziny = 0;

            foreach (KeyValuePair<int, int> kvp in harmonogram)
            {
                pracGodziny = pracGodziny + kvp.Value;

            }

            if (pracGodziny > maxGodziny) { return true; }
            else { return false; }


        }

        public bool CzyPracaNiedziela()
        {
            foreach (KeyValuePair<int, int> kvp in harmonogram)
            {
                if (kvp.Key == pierwszaNiedziela | kvp.Key == pierwszaNiedziela + 7 | kvp.Key == pierwszaNiedziela + 14 | kvp.Key == pierwszaNiedziela + 21 | kvp.Key == pierwszaNiedziela + 28)
                {
                    if (kvp.Value > 0) return true;
                }

            }

            return false;
        }

        public int IleNadgodzin()
        {
            int nadgodziny = 0;

            foreach (KeyValuePair<int, int> kvp in harmonogram)
            {
                if (kvp.Key == pierwszaNiedziela | kvp.Key == pierwszaNiedziela + 7 | kvp.Key == pierwszaNiedziela + 14 | kvp.Key == pierwszaNiedziela + 21 | kvp.Key == pierwszaNiedziela + 28)
                {
                    nadgodziny = nadgodziny + kvp.Value;
                }
                else
                {
                    if (kvp.Value > 8)
                    {
                        nadgodziny = nadgodziny + (kvp.Value - 8);
                    }
                }

            }

            return nadgodziny;
        }


        public bool CzyPrzekraczaJedenascie()
        {
            if (CzyJedenascie().Count == 0) return false;
            else return true;
        }



        //przyjmujac ze wszyscy rozpoczynaja prace o 8, bowiem w struktrzue danych opsisanej w zadaniu
        // dzień miesiąca, liczba godzin. Nie ma mowy o czasie rozpoczęcia czy zakończenia pracy.
        // W tym wypadku pozostała tylko możliwość przyjęcia, któregoś z rozwiązań
        // Zdecydowałem się na przyjęcie iż każdy pracownik rozpoczyna pracę o 8:00 co nam daje, ażeby nie było 11h przerwy
        // to musiałby ktoś zakończyć pracę o 21 czyli pracować 13h
        public List<int> CzyJedenascie()
        {
            List<int> listaPrzekraczajacych = new List<int>();

            foreach (KeyValuePair<int, int> kvp in harmonogram)
            {
                if (kvp.Value >= 13)
                {
                    listaPrzekraczajacych.Add(kvp.Key);
                    Console.WriteLine("Przerwa miedzy praca mniejsza niz 11h dnia " + kvp.Key);
                }
            }

            return listaPrzekraczajacych;
        }


    }


}