using System;
using Fei.BaseLib;

namespace Cv02_odevzdani
{
    class Program
    {
        private static void LoadArray( ref double[] array) {
            int? size = Reading.ReadInt("Vložte velikost pole");
            if (size != null)
            {
                if (size < 1)
                {
                    Console.WriteLine("Zadal jsi nekladne cislo pro velikost pole");
                    return;
                }
                array = new double[(int)size];
                for (int i = 0; i < size; i++)
                {
                    double? value = Reading.ReadDouble($"Array[{i}]");
                    if (value != null)
                    {
                        array[i] = (double)value;
                    }
                    else
                    {
                        Console.WriteLine("Nezadal jsi cislo");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nezadal jsi cislo");
                return;
            }
        }
        private static void PrintArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Index {i} = {array[i]}");
            }
        }
        private static void SortArray(double[]array) {
            Array.Sort(array);
            Console.WriteLine("Pole bylo setrideno");
        }
        private static void FindMinValue(double[] array) {
            if (array.Length < 1) {
                return;
            }
            double min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine($"Nejmensi hodnota je {min}");
        }
        private static void FindFirstValue(double[] array) {
            double? number = Reading.ReadDouble("Zadej hledane cislo");
            if (number != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == (double)number)
                    {
                        Console.WriteLine($"Prvni vyskyt cisla {number} se vyskytuje na indexu {i}");
                        break;
                    }
                }
            }
        }
        private static void FindLastValue(double[] array) {
            double? number = Reading.ReadDouble("Zadej hledane cislo");
            if (number != null)
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] == (double)number)
                    {
                        Console.WriteLine($"Posledni vyskyt cisla {number} se vyskytuje na indexu {i}");
                        break;
                    }
                }
            }
        }
        private static void PrintMenu() {
            Console.WriteLine(    "-------------------------------------------------\n" +
                                  "1.Zadaní prvků pole z klávesnice\n"
                                + "2.Výpis pole na obrazovku\n"
                                + "3.Utřídění pole vzestupně\n"
                                + "4.Hledání minimálního prvku\n"
                                + "5.Hledání prvního výskytu zadaného čísla\n"
                                + "6.Hledání posledního výskytu zadaného čísla\n"
                                + "7.Konec programu\n");
        }
        static void Main(string[] args)
        {
          
            double[] array = new double[0];
            do {
                PrintMenu();
                switch (Reading.ReadInt("Vyberte možnost")) {
                    case 1:
                        LoadArray(ref array);
                        break;
                    case 2:
                        PrintArray(array);
                        break;
                    case 3:
                        SortArray( array);
                        break;
                    case 4:
                        FindMinValue(array);
                        break;
                    case 5:
                        FindFirstValue(array);
                        break;
                    case 6:
                        FindLastValue(array);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Pokračuj kliknutím");
                Console.ReadKey();
            } while (true);
        
        }

        
    }
}
