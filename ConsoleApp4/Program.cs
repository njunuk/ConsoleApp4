using ConsoleApp4.Entities;
using EFCoreIntro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Runtime.Serialization;

class Program
{
    //static void AddStudent()
    //{
    //    Console.Write("Input first name: ");
    //    string fn = Console.ReadLine();
    //    Console.Write("Input last name: ");
    //    string ln = Console.ReadLine();
    //    Console.Write("Input birth date(MM/dd/YYYY): ");
    //    string bd = Console.ReadLine();
    //    string[] birth = bd.Split('/');
    //    Console.Write("Input email: ");
    //    string mail = Console.ReadLine();
    //    AppDbContext db = new AppDbContext();
    //    Student student = new Student()
    //    {
    //        FirstName = fn,
    //        LastName = ln,
    //        BirthDate = new DateTime(int.Parse(birth[2]), int.Parse(birth[0]), int.Parse(birth[1])),//yyyy-mm-dd?
    //        Email = mail
    //    };
    //    db.Students.Add(student);
    //    db.SaveChanges();
    //}
    //static void AddTeacher()
    //{
    //    Console.Write("Input full name: ");
    //    string fn = Console.ReadLine();
    //    Console.Write("Input age: ");
    //    int a = int.Parse(Console.ReadLine());
    //    Console.Write("Input salary: ");
    //    double s = double.Parse(Console.ReadLine());
    //    AppDbContext db = new AppDbContext();
    //    Teacher teacher = new Teacher()
    //    {
    //        FullName = fn,
    //        Age = a,
    //        Salary = s
    //    };
    //    db.Teachers.Add(teacher);
    //    db.SaveChanges();
    //}
    //static void ListStudent()
    //{
    //    AppDbContext db = new AppDbContext();

    //    foreach (var student in db.Students)
    //    {
    //        Console.WriteLine(student.FirstName);
    //    }

    //    var query = from student in db.Students
    //                select student.BirthDate;

    //    foreach (var item in query)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}
    //static void ListTeacher()
    //{
    //    AppDbContext db = new AppDbContext();

    //    foreach (var teacher in db.Teachers)
    //    {
    //        Console.WriteLine(teacher.FullName +", "+ teacher.Age);
    //    }
    //}
    //groups
    static void CreateGroup()
    {
        Console.Write("Input Name: ");
        string n = Console.ReadLine();
        AppDbContext db = new AppDbContext();
        Group group = new Group()
        {
            Name = n,
            Students = new List<Student>()
        };
        db.Groups.Add(group);
        db.SaveChanges();
    }
    static string ReturnGroup(int Id)
    {
        AppDbContext db = new AppDbContext();
        Group x = db.Groups.Find(Id);
        return x.ToString();
    }
    static void EditGroup(int Id)
    {
        AppDbContext db = new AppDbContext();
        Group x = db.Groups.Find(Id);
        Console.Write("Change Name + Current Name: " + x.Name + ": ");
        string n = Console.ReadLine();
        x.Name = n;
        while (true)
        {
            foreach (Student s in x.Students)
            {
                s.ToString();
            }
            Console.Write("Input 1 to add a student, 2 to delete a student, 0 to quit: ");
            int ch1 = int.Parse(Console.ReadLine());
            Console.Write("Input student id to manipulate: ");
            int sid = int.Parse(Console.ReadLine());
            if (ch1 == 1)
            {
                Student xs = db.Students.Find(sid);
                x.Students.Add(xs);
            }
            if (ch1 == 2)
            {
                Student xs = db.Students.Find(sid);
                x.Students.Remove(xs);
            }
        }
    }
    static void DeleteGroup(int Id)
    {
        AppDbContext db = new AppDbContext();
        Group x = db.Groups.Find(Id);
        db.Groups.Remove(x);
    }
    //students
    static void CreateStudents()
    {
        Console.Write("Input First name: ");
        string fn = Console.ReadLine();
        Console.Write("Input Last name: ");
        string ln = Console.ReadLine();
        Console.Write("Input scholarship: ");
        decimal s = decimal.Parse(Console.ReadLine());
        Console.Write("Input birthday (10/22/1987): ");
        DateTime b = DateTime.Parse(Console.ReadLine());

        AppDbContext db = new AppDbContext();
        Student student = new Student()
        {
            FirstName = fn,
            LastName = ln,
            Scholarship = s,
            Birthday = b,
            GroupId = 0,
            Group = null,
            Passport = null
        };
        db.Students.Add(student);
        db.SaveChanges();

    }
    static string ReturnStudent(int Id)
    {
        AppDbContext db = new AppDbContext();
        Student x = db.Students.Find(Id);
        return x.ToString();
    }
    static void EditStudent(int Id)
    {
        AppDbContext db = new AppDbContext();
        Student x = db.Students.Find(Id);
        Console.Write("Input new First name, current: " + x.FirstName + ": ");
        string fn = Console.ReadLine();
        x.FirstName = fn;
        Console.Write("Input new Last name, current: " + x.LastName + ": ");
        string ln = Console.ReadLine();
        x.LastName = ln;
        Console.Write("Input new scholarship, current: " + x.Scholarship + ": ");
        decimal s = decimal.Parse(Console.ReadLine());
        x.Scholarship = s;
        Console.Write("Input new birthday (10/22/1987), current: " +x.Birthday +": ");
        DateTime b = DateTime.Parse(Console.ReadLine());
        x.Birthday = b;
        Console.Write("Input group id, current: " + x.GroupId + ": ");
        int gid = int.Parse(Console.ReadLine());
        Group g = db.Groups.Find(gid);
        x.Group = g;
        x.GroupId = gid;
        Console.Write("Input passport id, current: " + x.Passport.Id + ": ");
        int pid = int.Parse(Console.ReadLine());
        Passport p = db.Passports.Find(pid);
        x.Passport = p;
    }
    static void DeleteStudent(int Id)
    {
        AppDbContext db = new AppDbContext();
        Student x = db.Students.Find(Id);
        db.Students.Remove(x);
    }

    //teacher
    //teachers
    static void CreateTeacher()
    {
        Console.Write("Input First name: ");
        string fn = Console.ReadLine();
        Console.Write("Input Last name: ");
        string ln = Console.ReadLine();
        Console.Write("Input salary: ");
        decimal sal = decimal.Parse(Console.ReadLine());
        AppDbContext db = new AppDbContext();
        Teacher teacher = new Teacher()
        {
            FirstName = fn,
            LastName = ln,
            Salary = sal,
            Subjects = new List<Subject>()
        };
        db.Teachers.Add(teacher);
        db.SaveChanges();
    }
    static string ReturnTeacher(int Id)
    {
        AppDbContext db = new AppDbContext();

        Teacher t = db.Teachers.Find(Id);

        return t.ToString();
    }
    static void EditTeacher(int Id)
    {
        AppDbContext db = new AppDbContext();
        Teacher t = db.Teachers.Find(Id);
        Console.Write("Input new First name, current: " + t.FirstName + ": ");
        string fn = Console.ReadLine();
        t.FirstName = fn;
        Console.Write("Input new Last name, current: " + t.LastName + ": ");
        string ln = Console.ReadLine();
        t.LastName = ln;
        Console.Write("Input new salary, current: " + t.Salary + ": ");
        decimal sal = decimal.Parse(Console.ReadLine());
        t.Salary = sal;
        while (true)
        {
            Console.WriteLine("Teacher subjects:");
            foreach (Subject s in t.Subjects)
            {
                Console.WriteLine(s.ToString());
            }
            Console.Write("Input 1 to add subject, 2 to delete subject, 0 to quit: ");
            int ch = int.Parse(Console.ReadLine());
            if (ch == 0)
                break;
            Console.Write("Input subject id: ");
            int sid = int.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Subject sub = db.Subjects.Find(sid);
                t.Subjects.Add(sub);
            }
            if (ch == 2)
            {
                Subject sub = db.Subjects.Find(sid);
                t.Subjects.Remove(sub);
            }
        }
        db.SaveChanges();
    }
    static void DeleteTeacher(int Id)
    {
        AppDbContext db = new AppDbContext();
        Teacher t = db.Teachers.Find(Id);
        db.Teachers.Remove(t);
        db.SaveChanges();
    }

    //subjects
    static void CreateSubject()
    {
        Console.Write("Input subject name: ");
        string n = Console.ReadLine();
        Console.Write("Input description: ");
        string d = Console.ReadLine();
        Console.Write("Input kafedra id: ");
        AppDbContext db = new AppDbContext();
        Subject subject = new Subject()
        {
            Name = n,
            Description = d,
            Kafedra = null,
            Teachers = new List<Teacher>()
        };
        db.Subjects.Add(subject);
        db.SaveChanges();
    }
    static string ReturnSubject(int Id)
    {
        AppDbContext db = new AppDbContext();
        Subject s = db.Subjects.Find(Id);
        return s.ToString();
    }

    static void EditSubject(int Id)
    {
        AppDbContext db = new AppDbContext();
        Subject s = db.Subjects.Find(Id);
        Console.Write("Input new name, current: " + s.Name + ": ");
        string n = Console.ReadLine();
        s.Name = n;
        Console.Write("Input new description, current: " + s.Description + ": ");
        string d = Console.ReadLine();
        s.Description = d;
        Console.Write("Input new kafedra id, current: " + s.Kafedra.Id + ": ");
        int kid = int.Parse(Console.ReadLine());
        Kafedra k = db.Kafedras.Find(kid);
        s.Kafedra = k;
        while (true)
        {
            Console.WriteLine("Subject teachers:");
            foreach (Teacher t in s.Teachers)
            {
                Console.WriteLine(t.ToString());
            }
            Console.Write("Input 1 to add teacher, 2 to delete teacher, 0 to quit: ");
            int ch = int.Parse(Console.ReadLine());
            if (ch == 0)
                break;
            Console.Write("Input teacher id: ");
            int tid = int.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Teacher t = db.Teachers.Find(tid);
                s.Teachers.Add(t);
            }
            if (ch == 2)
            {
                Teacher t = db.Teachers.Find(tid);
                s.Teachers.Remove(t);
            }
        }
        db.SaveChanges();
    }

    static void DeleteSubject(int Id)
    {
        AppDbContext db = new AppDbContext();
        Subject s = db.Subjects.Find(Id);
        db.Subjects.Remove(s);
        db.SaveChanges();
    }

    //kafedra
    static void CreateKafedra()
    {
        Console.Write("Input kafedra name: ");
        string n = Console.ReadLine();
        AppDbContext db = new AppDbContext();
        Kafedra k = new Kafedra()
        {
            Name = n,
            Subjects = new List<Subject>()
        };
        db.Kafedras.Add(k);
        db.SaveChanges();
    }

    static string ReturnKafedra(int Id)
    {
        AppDbContext db = new AppDbContext();
        Kafedra k = db.Kafedras.Find(Id);
        return k.ToString();
    }
    //passport
    static void CreatePassport()
    {
        Console.Write("Input passport number: ");
        string num = Console.ReadLine();
        Console.Write("Input student id: ");
        int sid = int.Parse(Console.ReadLine());
        AppDbContext db = new AppDbContext();
        Student s = db.Students.Find(sid);
        Passport p = new Passport()
        {
            Number = num,
            Student = s,
            StudentId = sid
        };
        db.Passports.Add(p);
        db.SaveChanges();
    }
    static string ReturnPassport(int Id)
    {
        AppDbContext db = new AppDbContext();
        Passport p = db.Passports.Find(Id);
        return p.ToString();
    }
    static void Main(string[] args)
    {
        Console.WriteLine("ttt");
        //*дуже дуже довге меню вибора*
    }
}

