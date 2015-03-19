using System;

namespace DuoCode.Helpers
{
	public static class DateTimeExtensions
	{
		public static string ToLogString(this DateTime dateTime)
		{
			var milliecondsString = dateTime.Millisecond.ToString();
			while (milliecondsString.Length <= 2)
				milliecondsString = "0" + milliecondsString;

			return string.Format(
					"{0} {1} {2}:{3}:{4}.{5}",
					dateTime.Day,
					dateTime.ToMonthShortName(),
					dateTime.Hour,
					dateTime.Minute,
					dateTime.Second,
					milliecondsString);
		}

		public static string ToMonthShortName(this DateTime dateTime)
		{
			return dateTime.JsDate.toDateString().split(" ")[1];
		}
	}
}
