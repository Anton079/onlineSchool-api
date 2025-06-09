using online_school_api.Courses.Models;
using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Student Student { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}
