﻿namespace TechnicalTest.Services
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; } = null!;
        public string SmtpPassword { get; set; } = null!;
        public string FromAddress { get; set; } = null!;
        public string FromName { get; set; } = null!;
    }
}
