﻿namespace email_service.Helper
{
    public class EmailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public bool Ssl { get; set; }
    }
}