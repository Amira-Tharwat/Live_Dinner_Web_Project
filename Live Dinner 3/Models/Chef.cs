using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Live_Dinner_3.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress (ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }
        //   public string Img { get; set; }
        [NotMapped]
        public IFormFile? ChefImg { get; set; }
        public   string? ImgPath { get; set; }
    }
}
