using System;

namespace Fei
{
    namespace BaseLib
    {
        public class Reading
        {
            /// <summary>
            /// Metoda nacte hodnotu z konzole jako string a pote zkusi prevest na int
            /// Vraci prevedeny int nebo null
            /// </summary>
            /// <param name="text">Vypis vyzvy k napsani hodnoty</param>
            /// <returns></returns>
            public static int? ReadInt(string text)
            {
                Console.WriteLine(text + ": ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return Convert.ToInt32(result);
                }
                return null;
            }
            /// <summary>
            /// Metoda nacte a vraci string
            /// </summary>
            /// <param name="text">Vypis vyzvy k napsani hodnoty</param>
            /// <returns></returns>
            public static string ReadString(string text)
            {
                Console.WriteLine(text + ": ");
                return Console.ReadLine();
            }
            /// <summary>
            /// Metoda nacte hodnotu z konzole jako string a pote zkusi prevest na double
            /// Vraci prevedeny double nebo null
            /// </summary>
            /// <param name="text">Vypis vyzvy k napsani hodnoty</param>
            /// <returns></returns>
            public static double? ReadDouble(string text)
            {
                Console.WriteLine(text + ": ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return Convert.ToDouble(result);
                }
                return null;
            }
            /// <summary>
            /// Metoda vraci char
            /// </summary>
            /// <param name="text">Vypis vyzvy k napsani hodnoty</param>
            /// <returns></returns>
            public static char ReadChar(string text)
            {
                Console.WriteLine(text + ": ");
                return (char)Console.Read();
            }
        }
    }
}