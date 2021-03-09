using System;
using System.Collections.Generic;
using System.Text;

namespace Fei
{
    namespace BaseLib
    {
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
    }
}
