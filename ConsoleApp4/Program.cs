using ConsoleApp4.Entities;
using EFCoreIntro;
using Microsoft.EntityFrameworkCore;
using System;

class Program
{
    static void AddStudent()
    {
        Console.Write("Input first name: ");
        string fn = Console.ReadLine();
        Console.Write("Input last name: ");
        string ln = Console.ReadLine();
        Console.Write("Input birth date(MM/dd/YYYY): ");
        string bd = Console.ReadLine();
        string[] birth = bd.Split('/');
        Console.Write("Input email: ");
        string mail = Console.ReadLine();
        AppDbContext db = new AppDbContext();
        Student student = new Student()
        {
            FirstName = fn,
            LastName = ln,
            BirthDate = new DateTime(int.Parse(birth[2]), int.Parse(birth[0]), int.Parse(birth[1])),//yyyy-mm-dd?
            Email = mail
        };
        db.Students.Add(student);
        db.SaveChanges();
    }
    static void AddTeacher()
    {
        Console.Write("Input full name: ");
        string fn = Console.ReadLine();
        Console.Write("Input age: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Input salary: ");
        double s = double.Parse(Console.ReadLine());
        AppDbContext db = new AppDbContext();
        Teacher teacher = new Teacher()
        {
            FullName = fn,
            Age = a,
            Salary = s
        };
        db.Teachers.Add(teacher);
        db.SaveChanges();
    }
    static void ListStudent()
    {
        AppDbContext db = new AppDbContext();

        foreach (var student in db.Students)
        {
            Console.WriteLine(student.FirstName);
        }

        var query = from student in db.Students
                    select student.BirthDate;

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }
    }
    static void ListTeacher()
    {
        AppDbContext db = new AppDbContext();

        foreach (var teacher in db.Teachers)
        {
            Console.WriteLine(teacher.FullName +", "+ teacher.Age);
        }
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("1, 2 to add student/teacher; 3, 4 to list students/teachers; 0 to quit");
            int ch1 = int.Parse(Console.ReadLine());
            if (ch1 == 1)
            {
                AddStudent();
            }
            if (ch1 == 2)
            {
                AddTeacher();
            }
            if (ch1 == 3)
            {
                ListStudent();
            }
            if (ch1 == 4)
            {
                ListTeacher();
            }
            if (ch1 == 0)
            {
                break;
            }
        }
    }
}