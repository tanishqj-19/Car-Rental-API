﻿namespace CarRentalSystemAPI.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string to, string subject, string body);
    }
}
