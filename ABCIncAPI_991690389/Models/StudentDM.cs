using System.ComponentModel.DataAnnotations;

namespace ABCIncAPI_991690389.Models
{
    //Table used for dev info
    public class StudentDM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        [Key]
        public int StudentNumber { get; set; }
    }
}
