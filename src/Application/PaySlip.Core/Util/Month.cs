using PaySlip.Core;
using PaySlip.Core.Util;
using System;
using System.Globalization;
using System.Linq;

namespace PaySlip.Application.Core.Util
{
    public class Month
    {
        public static bool IsValidMonth(string month)
        {
            var value = month.Trim().ToUpper();
            return GetMonths()
                .ToList()
                .Any(x => x.ToUpper().Equals(value));
        }

        public static string[] GetMonths()
        {
            CultureInfo ci = new CultureInfo(Config.Get<string>(Const.Settings_Language));
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            return dtfi.MonthGenitiveNames;
        }

        public static string GetMonthDuration(string month)
        {
            CultureInfo ci = new CultureInfo(Config.Get<string>(Const.Settings_Language));
            int montNo = ci.DateTimeFormat.MonthNames.ToList().IndexOf(month.FirstCharToUpper()) + 1;
            var lastDayOfMonth = new DateTime(DateTime.UtcNow.Year, montNo, 1).AddMonths(1).AddDays(-1);
            return "01 " + month + " - " + lastDayOfMonth.Day.ToString() + " " + month;
        }
    }
}
