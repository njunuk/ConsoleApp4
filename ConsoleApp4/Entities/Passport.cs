using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Entities
{
    public class Passport
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public override string ToString()
        {
            return $"{Id}. {Number} | " + Student.ToString();
        }
    }
}