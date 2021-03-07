using System;
using System.Collections.Generic;
using System.Text;
using Fei.BaseLib;

namespace Cv3
{
    class Students
    {

        public Student[] students;
        const string menu = "1. Nacteni studentu\n2. Vypis studentu\n3. Serazeni podle cisla\n4. Serazeni podle jmena\n5. Serazeni podle fakulty\n6. Konec programu\n";
        const string faculties = "1. FES\n2. FF\n3. FEI\n4. FCHT";
        public Students(int students)
        {
            if (students < 0)
                throw new ArgumentOutOfRangeException("Negative input");
            this.students = new Student[students];
        }

        public void PrintMenu()
        {
            Console.WriteLine(menu);
        }

        public void LoadStudents(int numberOfStudents)
        {
            students = new Student[numberOfStudents];
            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Reading.ReadString("Zadej jmeno studenta");
                int? number = Reading.ReadInt("Zadej cislo studenta");
                if (number != null)
                {
                    Console.WriteLine(faculties);
                    int? typeOfFaculty = Reading.ReadInt("Zadej fakultu");
                    TypeOfFaculty faculty;
                    switch (typeOfFaculty)
                    {
                        case 1: faculty = TypeOfFaculty.FES; break;
                        case 2: faculty = TypeOfFaculty.FF; break;
                        case 3: faculty = TypeOfFaculty.FEI; break;
                        case 4: faculty = TypeOfFaculty.FCHT; break;
                        default: faculty = TypeOfFaculty.FEI; break;
                    }
                    students[i] = new Student(name, (int)number, faculty);
                    Console.WriteLine("--------------------------------");
                }

            }
            Console.WriteLine("Studenti byly nacteni");
        }
        public void PrintStudents()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }
        public void BubbleSortStudents(sortStudents sort)
        {

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = 0; j < students.Length - i - 1; j++)
                {
                    if (sort(students[j + 1], students[j]) < 0)
                    {
                        Student tmp = students[j + 1];
                        students[j + 1] = students[j];
                        students[j] = tmp;
                    }
                }
            }
        }
        public int CompareByName(Student st1, Student st2)
        {
            return String.Compare(st1.Name, st2.Name);
        }
        public int CompareByNumber(Student st1, Student st2)
        {
            return st1.Number - st2.Number;
        }
        public int CompareByFaculty(Student st1, Student st2)
        {
            return st1.TypeOfFaculty - st2.TypeOfFaculty;
        }

    }
    public enum TypeOfFaculty { FES, FF, FEI, FCHT };
    class Student
    {
        private string name;
        private int number;
        private TypeOfFaculty typeOfFaculty;
        public string Name { get { return name; } set { name = value; } }
        public int Number { get { return number; } set { number = value; } }
        public TypeOfFaculty TypeOfFaculty { get { return typeOfFaculty; } set { typeOfFaculty = value; } }

        public Student(string name, int number, TypeOfFaculty typeOfFaculty)
        {
            this.name = name;
            this.number = number;
            this.typeOfFaculty = typeOfFaculty;
        }

        public override string ToString()
        {
            return "" + name + ", " + number + ", " + typeOfFaculty;
        }

    }
}
