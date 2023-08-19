using HarmonogramNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HarmonogramNs
{
    internal class HarmonogramOperator
    {
        public static void Main()
        {

            string filePath = "Godziny4.txt";
            Dictionary<int, int> temp = ReadFile(filePath);

            Console.WriteLine("Kiedy jest pierwsza niedziela? zakres (1-7)");
            int ndz = Convert.ToInt32(Console.ReadLine());
            while (ndz > 7 | ndz < 1)
            {
                Console.WriteLine("Podaj prawidłowy zakres (1-7)");
                ndz = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Pierwsza niedziela jest " + ndz);



            Harmonogram harmonogram = new Harmonogram(temp, ndz);


            Console.WriteLine("Liczba dni roboczych wynosi " + harmonogram.getLiczbaDniRoboczych());
            Console.WriteLine("Czy suma godzin przekracza 8*dni roboczych w miesiacu? " + harmonogram.CzyPrzekracza());
            Console.WriteLine("Czy praca w niedziele? " + harmonogram.CzyPracaNiedziela());
            Console.WriteLine("Ile nadgodzin? " + harmonogram.IleNadgodzin());
            Console.WriteLine("Czy brak przerwy 11h? " + harmonogram.CzyPrzekraczaJedenascie());


        }

        public static Dictionary<int, int> ReadFile(string filePath)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            String line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();

                while (line != null)
                {


                    string[] parts = line.Split(' ');
                    int tempday = int.Parse(parts[0]);
                    int temphours = int.Parse(parts[1]);
                    temp.Add(tempday, temphours);

                    //Read the next line
                    line = sr.ReadLine();



                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return temp;
        }
    }




}