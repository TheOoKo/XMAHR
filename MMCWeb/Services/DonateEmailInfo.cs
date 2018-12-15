using System;
using System.ComponentModel.DataAnnotations;

namespace MMCWeb.Services
{
    public class DonateEmailInfo : EmailInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BankInfo { get; set; }
        public double Amount { get; set; }
    }
  
}