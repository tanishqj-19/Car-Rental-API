using System.ComponentModel.DataAnnotations;

namespace CarRentalSystemAPI.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(100, ErrorMessage = "Model should not exceed 100 characters.")]
        [MinLength(3, ErrorMessage = "Model should be at least 3 characters long.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        [StringLength(50, ErrorMessage = "Make should not exceed 50 characters.")]
        public string Make { get; set; }


        [Required(ErrorMessage = "Price per day is required.")]
        [Range(1, 10000, ErrorMessage = "Price per day must be between 1 and 10,000.")]
        [DataType(DataType.Currency)]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Availability status is required.")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }
    }
}
