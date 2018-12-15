using System;
using System.Web.Mvc;

namespace MMCWeb.Services
{
    public interface IEmailInfo
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string ViewName { get; set; }
        [AllowHtml]
        string Message { get; set; }
        DateTime SendDate { get; }
        string Sender { get; set; }

    }
}