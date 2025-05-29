using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public ICollection<StudentSubject> Subjects { get; set; } = new List<StudentSubject>();
    }
}
