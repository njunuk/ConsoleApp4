

namespace ConsoleApp4.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; }
        public override string ToString()
        {
            return $"{Id}. {Name}.";
        }
    }
}