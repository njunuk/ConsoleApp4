using System;
namespace ConsoleApp4.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; } = 0!;
        public double Salary { get; set; } = 0!;
    }
}