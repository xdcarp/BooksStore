﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IEmailService
    {
        Task SendMail(string subject, string toEmail, string message);
    }
}
