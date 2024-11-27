﻿namespace CarRentalSystemAPI.Models.Mail
{
    public class GetEmailSetting
    {

        public string SecretKey { get; set; } = default;
        public string From { get; set; } = default;

        public string SmtpServer { get; set; } = default;

        public int Port { get; set; }

        public bool EnableSSL { get; set; }


    }
}
