using System;

namespace MMCWeb.Services
{
    public static class MyExtensionMethods
    {
        public static DateTime getLocalTime(this DateTime utc)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.FindSystemTimeZoneById("Myanmar Standard Time"));
        }
    }
}