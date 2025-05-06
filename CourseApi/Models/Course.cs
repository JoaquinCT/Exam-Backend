using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseApi.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [MaxLength(50)]
        public string Schedule { get; set; }

        [MaxLength(100)]
        public string Professor { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}

