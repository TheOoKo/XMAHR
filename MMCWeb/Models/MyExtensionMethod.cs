using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMCWeb.Models
{
    public static class MyExtensionMethod
    {
        public static string getCode(this string prefix, int newID, string zeroformat, string suffix = null)
        {

            string value = newID.ToString();
            for (int i = value.Length; i < zeroformat.Length; i++)
            {
                value = string.Concat("0", value);
            }
            return string.Concat(prefix, value, suffix);
        }
    }
}