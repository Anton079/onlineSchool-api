using online_school_api.Courses.Models;
using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace online_school_api.Enrolments.Models
{
    [Table("enrolments")]
    public class Enrolment
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("studentId")]
        public int StudentId { get; set; }

        [Required]
        [Column("courseId")]
        public int CourseId {  get; set; }

        [Required]
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
