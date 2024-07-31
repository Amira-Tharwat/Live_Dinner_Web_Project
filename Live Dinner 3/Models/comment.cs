using System.ComponentModel.DataAnnotations;

namespace Live_Dinner_3.Models
{
    public class comment
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required]
        public string ?Comment { get; set; }
        public int BlogId { get; set; }
    }
}
