using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMCWeb.Helpers
{
    public static class MyExtension
    {
        public static DateTime getLocalTime(this DateTime utc)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.FindSystemTimeZoneById("Myanmar Standard Time"));
        }

        public static string getZeroFormat(this string value, string zeroformat)
        {
            for (int i = value.Length; i < zeroformat.Length; i++)
            {
                value = string.Concat("0", value);
            }
            return value;
        }
        public static int getNewID(this List<int> integers)
        {
            try
            {
                int i, d, x, rcount = 0, maxID = 0, lgvalue = 0;

                ArrayList seq = new ArrayList();
                rcount = integers.Count;
                maxID = integers.Max();
                integers.Sort();
                if (rcount != maxID)
                {
                    x = 1;
                    if (rcount > 0)
                    {
                        for (i = 0; i < rcount - 1; i++)
                        {
                            d = integers[i + 1] - integers[i];
                            if (d > 1)
                            {
                                do
                                {
                                    seq.Add(integers[i + 1] - x);
                                    d = d - 1;
                                    x++;
                                } while (1 < d);
                                x = 1;
                            }

                        }
                        seq.Sort();
                    }
                    else
                    {
                        for (i = 0; i < maxID - 1; i++)
                        {
                            do
                            {
                                seq.Add(maxID - x);
                                x++;
                            } while (rcount == maxID);
                            x = 1;
                        }
                        seq.Sort();
                    }

                    if (seq.Count > 0)
                    {
                        lgvalue = (int)seq[0];
                    }
                    else
                    {
                        lgvalue = maxID + 1;
                    }


                }
                else
                {
                    lgvalue = maxID + 1;
                }
                return lgvalue;
            }
            catch (Exception ex)
            {
                string exstr = ex.Message;
                return 1;
            }
        }
    }
}