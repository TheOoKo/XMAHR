using System;
using System.ComponentModel.DataAnnotations;

namespace MMCWeb.Services
{
    public class EmailInfo : IEmailInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string ViewName { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd, MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SendDate { get { return DateTime.UtcNow.getLocalTime(); } }
        public string Tag { get; set; }
    }
}