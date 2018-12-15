using System;
using System.ComponentModel.DataAnnotations;

namespace MMCWeb.Services
{
    public class ContactEmailInfo : EmailInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
      
    }
  
}