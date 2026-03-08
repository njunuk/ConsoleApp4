using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public Kafedra Kafedra { get; set; }
        public List<Teacher> Teachers { get; set; } = null!;
        public override string ToString()
        {
            return $"{Id}. {Name} {Description}";
        }
    }
}