using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Live_Dinner_3.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(3, 50)]
        public string Name { get; set; }

        [Length(10, 200)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "Please enter price from 10 to 1000")]
        public float Price { get; set; }
        //  public string Img { get; set; }

        public bool Availability { get; set; }
        public int ChefId { get; set; }
        [ForeignKey("ChefId")]
        public Chef? Chef { get; set; }

        [NotMapped]
        public IFormFile? MealImg { get; set; }
        public string? ImgPath { get; set; }
    }
}
