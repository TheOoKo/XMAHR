﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMCWeb.Models
{
    public class MemberViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean Remember { get; set; }
    }
}