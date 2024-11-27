namespace CarRentalSystemAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public int RentalDays { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
}
