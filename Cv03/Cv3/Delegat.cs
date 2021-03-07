using System;
using Fei.BaseLib;
namespace Cv3
{
    delegate int sortStudents(Student st1, Student st2);
    class Program
    {
        static void Main(string[] args)
        {
            //int d = MathConventor.BinToDec(01011);
            //string q = MathConventor.DecToBin(20);
            //double? x1, x2;
            //bool b = ExtraMath.QuadraticEquation(1, 1, 1, out x1, out x2);
            Students studenti = new Students(0);
            sortStudents sortStudents;
            do
            {

                studenti.PrintMenu();
                switch (Reading.ReadInt("Vyberte možnost"))
                {
                    case 1:
                        int? numberOfStudents = Reading.ReadInt("Zadej pocet studentu");
                        if (numberOfStudents != null)
                        {
                            studenti.LoadStudents((int)numberOfStudents);
                        }
                        else
                        {
                            Console.WriteLine("Nezadal jste platne cislo");
                        }
                        break;
                    case 2: studenti.PrintStudents(); break;
                    case 3: sortStudents = studenti.CompareByNumber; studenti.BubbleSortStudents(sortStudents); break;
                    case 4: sortStudents = studenti.CompareByName; studenti.BubbleSortStudents(sortStudents); break;
                    case 5: sortStudents = studenti.CompareByFaculty; studenti.BubbleSortStudents(sortStudents); break;
                    case 6: Environment.Exit(0); break;

                }
            } while (true);

        }
    }




}
