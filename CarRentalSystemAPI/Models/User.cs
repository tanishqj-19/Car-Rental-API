using System.ComponentModel.DataAnnotations;

namespace CarRentalSystemAPI.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name should not exceed 100 characters.")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "User";

    }
}
