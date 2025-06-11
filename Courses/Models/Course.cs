using online_school_api.Enrolments.Models;
using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace online_school_api.Courses.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")] 
        public string Name { get; set; }

        [Required]
        [Column("department")]
        public string Department { get; set; }

        public virtual List<Enrolment> Enrolments { get; set; } = new();
    }
}
