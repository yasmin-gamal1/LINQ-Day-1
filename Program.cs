using System;
using System.Collections.Generic;
using System.Linq;

class Subject
{
    public int Code { get; set; }
    public string Name { get; set; }
}

class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Subject[] Subjects { get; set; }
}

class Program
{
    static void Main()
    {
      
        List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

       
        var uniqueSortedNumbers = numbers.Distinct().OrderBy(n => n);
        Console.WriteLine("Unique and Sorted Numbers:");
        foreach (var num in uniqueSortedNumbers)
        {
            Console.WriteLine(num);
        }

      
        Console.WriteLine("\nNumbers and Their Multiplication:");
        foreach (var num in uniqueSortedNumbers)
        {
            Console.WriteLine($"{num} -> {num * num}");
        }

       
        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

       
        var lengthThreeNames = names.Where(name => name.Length == 3);
        Console.WriteLine("\nNames with Length Equal to 3:");
        foreach (var name in lengthThreeNames)
        {
            Console.WriteLine(name);
        }

        
        var namesWithA = names.Where(name => name.IndexOf('a', StringComparison.OrdinalIgnoreCase) >= 0)
                              .OrderBy(name => name.Length);
        Console.WriteLine("\nNames Containing 'A' (or 'a') Sorted by Length:");
        foreach (var name in namesWithA)
        {
            Console.WriteLine(name);
        }

        var firstTwoNames = names.Take(2);
        Console.WriteLine("\nFirst 2 Names:");
        foreach (var name in firstTwoNames)
        {
            Console.WriteLine(name);
        }

        
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                ID = 1, FirstName = "Ali", LastName = "Mohammed",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 33, Name = "UML" }
                }
            },
            new Student()
            {
                ID = 2, FirstName = "Mona", LastName = "Gala",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 34, Name = "XML" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 3, FirstName = "Yara", LastName = "Yousf",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 1, FirstName = "Ali", LastName = "Ali",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 33, Name = "UML" }
                }
            }
        };

      
        Console.WriteLine("\nStudent Full Name and Number of Subjects:");
        var studentSubjectsCount = students.Select(s => new
        {
            FullName = $"{s.FirstName} {s.LastName}",
            SubjectCount = s.Subjects.Length
        });

        foreach (var student in studentSubjectsCount)
        {
            Console.WriteLine($"{student.FullName}: {student.SubjectCount} subjects");
        }

        
        Console.WriteLine("\nOrdered Students by FirstName Descending and LastName Ascending:");
        var orderedStudents = students.OrderByDescending(s => s.FirstName)
                                      .ThenBy(s => s.LastName)
                                      .Select(s => new { s.FirstName, s.LastName });

        foreach (var student in orderedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
