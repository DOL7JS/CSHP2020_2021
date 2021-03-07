using System;
using System.Text;

namespace Fei
{
    namespace BaseLib
    {

        public class ExtraMath
        {
            public static bool QuadraticEquation(double a, double b, double c, out double? x1, out double? x2)
            {
                double disk = b * b - 4 * a * c;
                if (disk == 0)
                {
                    x1 = (-b) / (2 * a);
                    x2 = x1;
                    return true;
                }
                else if (disk > 0)
                {
                    x1 = (-b + Math.Sqrt(disk)) / (2 * a);
                    x2 = (-b - Math.Sqrt(disk)) / (2 * a);
                    return false;
                }
                x1 = null;
                x2 = null;
                return false;
            }
            public static double genedateRandom(Random random, int min, int max)
            {
                return random.NextDouble() * (max - min) + min;
            }
        }
        public class MathConventor
        {
            static string[] roman1 = { "MMM", "MM", "M" };
            static string[] roman2 = { "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C" };
            static string[] roman3 = { "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X" };
            static string[] roman4 = { "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };

            public static string DecToBin(int decNumber)
            {
                return Convert.ToString(decNumber, 2);
            }
            public static int BinToDec(int binNumber)
            {
                return Convert.ToInt32(binNumber.ToString(), 2);
            }
            public static string DecToRomanNumber(int num)
            {
                if (num > 3999) throw new ArgumentException("num > 3999");
                if (num < 1) throw new ArgumentException("num < 1");
                int thousands, hundreds, tens, units;
                thousands = num / 1000;
                num %= 1000;
                hundreds = num / 100;
                num %= 100;
                tens = num / 10;
                units = num % 10;
                var sb = new StringBuilder();
                if (thousands > 0) sb.Append(roman1[3 - thousands]);
                if (hundreds > 0) sb.Append(roman2[9 - hundreds]);
                if (tens > 0) sb.Append(roman3[9 - tens]);
                if (units > 0) sb.Append(roman4[9 - units]);
                return sb.ToString();
            }
            public static int RomanNumberToDec(string decNumber)//1 - 3999
            {
                int s1;
                int s2;
                int result = 0;
                for (int i = 0; i < decNumber.Length; i++)
                {
                    s1 = RomanNumberToInt(decNumber[i]);
                    if (i + 1 < decNumber.Length)
                    {
                        s2 = RomanNumberToInt(decNumber[i + 1]);
                        if (s1 >= s2)
                        {
                            result += s1;
                        }
                        else
                        {
                            result += s2 - s1;
                            i++;
                        }
                    }
                    else
                    {
                        result += s1;
                    }
                }
                return result;
            }
            private static int RomanNumberToInt(char romanNumber)
            {
                switch (romanNumber)
                {
                    case 'I': return 1;
                    case 'V': return 5;
                    case 'X': return 10;
                    case 'L': return 50;
                    case 'C': return 100;
                    case 'D': return 500;
                    case 'M': return 1000;
                    default: return -1;
                }
            }
        }
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
                Console.Write(text + ": ");
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
                Console.Write(text + ": ");
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
                Console.Write(text + ": ");
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
                Console.Write(text + ": ");
                return (char)Console.Read();
            }
        }
    }
}