using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Live_Dinner_3.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(2,50)]
        public string Title { get; set; }
        [Required]
        [Length(10,10000)]
        public string Description { get; set; }
        [Required]
        [Length(2,20)]
        public string Author { get; set; }
        public List<comment>? Comments { get; set; }

        [NotMapped]
        public IFormFile? BlogImg { get; set; }
        public string? ImgPath { get; set; }

       
    }
}
