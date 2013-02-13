    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using CodeBase2.Databases;
    using CodeBase2;

    public static class DateTimeFunctions
    {
        /// <summary>
        /// Convert to Date for entry into MySQL
        /// </summary>
        /// <param name="mysqldate">mysql Date</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string datetomysql(string mysqldate)
        {

            Match newdate = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)");
            string month1 = newdate.Groups[1].Value;
            string day1 = newdate.Groups[2].Value;
            string year1 = newdate.Groups[3].Value;
            string newdate1 = string.Empty;

            month1 = month1.PadLeft(2, '0');

            while (day1.Length < 2)
            {
                day1 = "0" + day1;
            }

            return year1 + "-" + month1 + "-" + day1;


        }
        public static string datetoordentry(string mysqldate)
        {

            Match newdate = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)");
            string month1 = newdate.Groups[1].Value;
            string day1 = newdate.Groups[2].Value;
            string year1 = newdate.Groups[3].Value;
            string newdate1 = string.Empty;

            month1 = month1.PadLeft(2, '0');

            while (day1.Length < 2)
            {
                day1 = "0" + day1;
            }

            return month1 + day1;


        }
        public static string dateToSoftPath(string mysqldate)
        {

            Match newdate = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)");
            string month1 = newdate.Groups[1].Value;
            string day1 = newdate.Groups[2].Value;
            string year1 = newdate.Groups[3].Value;
            string newdate1 = string.Empty;

            month1 = month1.PadLeft(2, '0');

            while (day1.Length < 2)
            {
                day1 = "0" + day1;
            }

            return year1 + month1 + day1;


        }

        public static string datetimeintomysql(string mysqldatetime)
        {
            string[] dates = mysqldatetime.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Match oldcoldate = Regex.Match(dates[0], "([0-9]+)/([0-9]+)/([0-9]+)");
            string oldmonth = oldcoldate.Groups[1].Value;
            string oldday = oldcoldate.Groups[2].Value;
            string oldyear = oldcoldate.Groups[3].Value;
            oldday = oldday.PadLeft(2, '0');
            oldmonth = oldmonth.PadLeft(2, '0');

            return oldyear + "-" + oldmonth + "-" + oldday;

        }

        private static string datetoordernumber(string ordend)
        {
            Match dateend = Regex.Match(ordend.ToString(), "([0-9]+)/([0-9]+)/([0-9]+)");
            string endmonth = dateend.Groups[1].Value;
            string endday = dateend.Groups[2].Value;
            string endyear = dateend.Groups[3].Value;
            while (endday.ToString().Length < 2)
            {
                endday = "0" + endday;
            }

            int endmnth = int.Parse(endyear) - 2004;
            endmnth = endmnth * 12;


            int monthend = Convert.ToInt32(endmonth) + Convert.ToInt32(endmnth);
            string monthendString = monthend.ToString();
            if (monthend > 99)
            {
                int letter = int.Parse(Microsoft.VisualBasic.Strings.Left(monthendString, 2));
                string newmonthend = Microsoft.VisualBasic.Strings.Right(monthendString, 1);
                letter = letter + 55;
                monthend = int.Parse(Microsoft.VisualBasic.Strings.Chr(letter) + newmonthend);
            }



            return monthend + endday;

        }
        public static object datetoordernumberEnd(string ordend)
        {
            return datetoordernumber(ordend).PadRight(8, '9');
        }

        public static object datetoordernumberStart(string ordend)
        {
            return datetoordernumber(ordend).PadRight(8, '0');
        }
    }

