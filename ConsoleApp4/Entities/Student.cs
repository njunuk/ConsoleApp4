using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConsoleApp4.Entities
{
    public enum AttendanceForm
    {
        Offline, Online, Hybrid
    }

    public class Student
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = null!;

        [Required(AllowEmptyStrings = false)] // "" != null
        public string LastName { get; set; } = null!;
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public decimal? Scholarship { get; set; }
        public DateTime Birthday { get; set; }
        [Column("Attendance")]
        public AttendanceForm AttendanceForm { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public Passport Passport { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id}. {FirstName} {LastName} {Email} {Birthday:d} -- {Group.Name}";
        }
    }
}