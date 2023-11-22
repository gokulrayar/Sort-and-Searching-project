using System;
using System.Collections.Generic;
using System.IO;

namespace Retrieve_Student__the_Option_of_Sorting_and_Searching
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // File path containing student data
            string filePath = "F:\\.Net projects\\project-sl-3/sampledata.txt";

            // Read student data from the file
            List<Student> students = ReadStudentData(filePath);

            if (students.Count == 0)
            {
                Console.WriteLine("No student data found.");
                return;
            }

            Console.WriteLine("Retrieved Data:");
            DisplayStudentData(students);
            Console.WriteLine("-----------------------------------------------------------");

            SortStudentsByName(students);
            DisplayStudentData(students);
            Console.WriteLine("-----------------------------------------------------------");

            
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();

            Student foundStudent = SearchStudentByName(students, searchName);

            DisplaySearchResult(foundStudent);

            Console.WriteLine("-----------------------------------------------------------");
            Console.ReadKey();
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        students.Add(new Student { Name = parts[0].Trim(), Class = parts[1].Trim() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading student data: " + ex.Message);
            }

            return students;
        }

        static void DisplayStudentData(List<Student> students)
        {
            Console.WriteLine("Student Data:");

            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name} Class: {student.Class}");
            }
        }

        static void SortStudentsByName(List<Student> students)
        {
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.Ordinal));
        }

        static Student SearchStudentByName(List<Student> students, string searchName)
        {
            return students.Find(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplaySearchResult(Student foundStudent)
        {
            if (foundStudent != null)
            {
                Console.WriteLine($"Student found: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Console.ReadKey();
        }
    }
}
