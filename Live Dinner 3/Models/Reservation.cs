using System.ComponentModel.DataAnnotations;

namespace Live_Dinner_3.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required]
       
        public int Number { get; set; }
        
        public int ? NumOfPersons { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
    }
}
