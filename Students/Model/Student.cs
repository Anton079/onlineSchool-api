
using Microsoft.AspNetCore.Mvc;
using online_school_api;
using online_school_api.Books.Model;
using online_school_api.Enrolments.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace online_school_api.Students.Model
{
    [Table("students")]

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("email")]

        public string Email { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("age")]
        public int Age { get; set; }

        [Required]
        [Column("university")]
        public string University { get; set; }


        public virtual List<Book> Books { get; set; } = new();

        [JsonIgnore]
        public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
  




    }
}
