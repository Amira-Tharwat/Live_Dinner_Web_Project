﻿using System.ComponentModel.DataAnnotations;

namespace Live_Dinner_3.Models
{
	public class ContactMessage
	{
		[Key]
        public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
		
		public string Subject { get; set; }
		[Required]
		public string Message { get; set; }
    }
}
