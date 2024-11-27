using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Services
{
    public class NotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendRentalConfirmation(string recipientEmail, Car car, int rentalDays, decimal totalPrice)
        {
            var subject = "Car Rental Confirmation";
            var message = $@"
            <h1>Car Rental Confirmation</h1>
            <p>Dear Customer,</p>
            <p>Your rental is confirmed!</p>
            <p>
                <strong>Car:</strong> {car.Make} {car.Model} ({car.Year})<br>
                <strong>Rental Duration:</strong> {rentalDays} days<br>
                <strong>Total Price:</strong> {totalPrice:C}
            </p>
            <p>Thank you for choosing us!</p>";

            await _emailService.SendEmail(recipientEmail, subject, message);
        }
    }

}
