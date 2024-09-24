
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grade_Management_System_in_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option = "Y";
            Console.Write("Enter school name: ");
            Console.ReadLine();
            Console.WriteLine("===============================================");
            do
            {
                Console.Write("Enter class name: ");
                Console.ReadLine();
                Console.Write("Enter the number of students int the class: ");
                
                 //int TotalClassStudents = int.Parse(Console.ReadLine());
ENTERSTUDENT:
                int Students = 0;
                if (!(int.TryParse(Console.ReadLine(), out Students)))
                {
                    Console.WriteLine("Please enter valid number of students.");
                    goto ENTERSTUDENT;
                }
                string[] Names = new string[Students];
                float[][] Marks = new float[Students][];
                string[] Grades = new string[Students];
                for (int i = 0; i < Students; i++)
                {
                    // Input student name
                    Console.Write($"Enter student name {i + 1}: ");
                    Names[i] = Console.ReadLine();

                    // Input marks for three subjects
                    Marks[i] = new float[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"Enter marks for subject {j + 1}: ");
                        Marks[i][j] = float.Parse(Console.ReadLine());
                    }

                    // Calculate the grade
                    Grades[i] = CalculateGrade(Marks[i]);
                }
                Console.WriteLine("\nStudent Grades:");
                for (int i = 0; i < Students; i++)
                {
                    Console.WriteLine($"Name: {Names[i]}, Marks: {string.Join(", ", Marks[i])}, Grade: {Grades[i]}");
                }
                // Calculate overall class average
                float overallAverage = CalculateClassAverage(Marks);
                Console.WriteLine($"\nOverall Class Average: {overallAverage:F2}");

                // Find highest and lowest grade
                string highestGrade = FindHighestGrade(Grades);
                string lowestGrade = FindLowestGrade(Grades);

                Console.WriteLine($"Highest Grade: {highestGrade}");
                Console.WriteLine($"Lowest Grade: {lowestGrade}");
                Console.Write("Do you want to genrate report for another class : Y OR N ");
              
                option = Console.ReadLine();
                Console.WriteLine("===============================================");
            } while (option == "Y" || option == "y" || option == "YES" || option == "yes" || option == "Yes");
            Console.ReadKey();
        }
      public  static string CalculateGrade(float[] marks)
        {
            float average = (marks[0] + marks[1] + marks[2]) / marks.Length;

            if (average >= 90) return "A";
            else if (average >= 80) return "B";
            else if (average >= 70) return "C";
            else if (average >= 60) return "D";
            else return "F";
        }
       public static float CalculateClassAverage(float[][] studentMarks)
        {
            float total = 0;
            int count = 0;

            foreach (var marks in studentMarks)
            {
                total += (marks[0] + marks[1] + marks[2]) / marks.Length;
                count++;
            }

            return total / count;
        }
       public static string FindHighestGrade(string[] grades)
        {
            string highest = "F";
            foreach (var grade in grades)
            {
                if (string.Compare(grade, highest) < 0)
                {
                    highest = grade;
                }
            }
            return highest;
        }
        static string FindLowestGrade(string[] grades)
        {
            string lowest = "A";
            foreach (var grade in grades)
            {
                if (string.Compare(grade, lowest) > 0)
                {
                    lowest = grade;
                }
            }
            return lowest;
        }
    }
}
