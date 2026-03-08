using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp4.Entities
{
    public class Kafedra
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Subject> Subjects { get; set; } = null!;
        public override string ToString()
        {
            return $"{Id}. N: {Name} S: {Subjects.Count()}";
        }
    }
}