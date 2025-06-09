using online_school_api;
using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using System.Text.Json.Serialization;

namespace online_school_api.Books.Model
{
    [Table("books")]
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
       
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("created")]
         public DateTime Created { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }

        public int StudentId { get; set; }




    }
}
