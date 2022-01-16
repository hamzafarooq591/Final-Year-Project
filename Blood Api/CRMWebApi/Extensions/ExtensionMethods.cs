namespace NashWebApi.Extensions
{
    using NashWebApi.Enums;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ExtensionMethods
    {
        public static void AddProperty(this ExpandoObject expando, string propertyName, object propertyValue)
        {
            IDictionary<string, object> dictionary = expando;
            if (dictionary.ContainsKey(propertyName))
            {
                dictionary[propertyName] = propertyValue;
            }
            else
            {
                dictionary.Add(propertyName, propertyValue);
            }
        }

        public static decimal CalculatePartnerPercentage(this decimal amount) => 
            ((amount * 10M) / 100M);

        public static string ConvertToFriendlyMessaage(this string efExceptionMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(efExceptionMessage))
                {
                    return string.Empty;
                }
                if (efExceptionMessage.Contains("The INSERT statement conflicted with the FOREIGN KEY "))
                {
                    int index = efExceptionMessage.IndexOf("\"", StringComparison.Ordinal);
                    int num2 = efExceptionMessage.IndexOf("\"", index + 1, StringComparison.Ordinal);
                    efExceptionMessage = "Invalid Paramater : '" + efExceptionMessage.Substring(index + 1, (num2 - index) - 1) + "'";
                    efExceptionMessage = efExceptionMessage.Replace("FK_dbo.", string.Empty);
                }
                return efExceptionMessage;
            }
            catch (Exception)
            {
                return efExceptionMessage;
            }
        }

        public static int? DefaultIfNull(this int? value)
        {
            if (!value.HasValue)
            {
                return 0;
            }
            return value;
        }

        public static long? DefaultIfNull(this long? value)
        {
            long? nullable = value;
            return new long?(nullable.HasValue ? nullable.GetValueOrDefault() : 0L);
        }

        public static string DefaultIfNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value;
        }

        public static string FixSqlSingleQuote(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            return text.Replace("'", "''");
        }

        public static string FormatDate(this DateTime value, string format = "MM/dd/yyyy hh:mm tt")
        {
           return value.ToString(format, CultureInfo.InvariantCulture);
        }
        public static string FormatDate(this DateTime? value, string format = "MM/dd/yyyy hh:mm tt")
        {
            return value.HasValue ? 
                value.GetValueOrDefault().ToString(format, CultureInfo.InvariantCulture) : "";
        }

        public static string FormatTime(this TimeSpan? value, string format = "hh:mm tt")
        {
            if (!value.HasValue)
            {
                return "";
            }
            return value.Value.FormatTime(format);
        }

        public static string FormatTime(this TimeSpan value, string format = "hh:mm tt") => 
            DateTime.Today.Add(value).ToString(format, CultureInfo.InvariantCulture);

        public static DaysOfWeek GetAvailibilyDay(this DayOfWeek dayOfWeek)
        {
            DaysOfWeek sunday = DaysOfWeek.Sunday;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return sunday;

                case DayOfWeek.Monday:
                    return DaysOfWeek.Monday;

                case DayOfWeek.Tuesday:
                    return DaysOfWeek.Tuesday;

                case DayOfWeek.Wednesday:
                    return DaysOfWeek.Wednesday;

                case DayOfWeek.Thursday:
                    return DaysOfWeek.Thursday;

                case DayOfWeek.Friday:
                    return DaysOfWeek.Friday;

                case DayOfWeek.Saturday:
                    return DaysOfWeek.Saturday;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static decimal RoundOff(this decimal d, int digit = 2) => 
            Math.Round(d, 2);

        public static byte[] ToBytesArray(this Stream stream)
        {
            byte[] buffer4;
            long position = 0L;
            if (stream.CanSeek)
            {
                position = stream.Position;
                stream.Position = 0L;
            }
            try
            {
                int num3;
                byte[] buffer = new byte[0x1000];
                int offset = 0;
                while ((num3 = stream.Read(buffer, offset, buffer.Length - offset)) > 0)
                {
                    offset += num3;
                    if (offset == buffer.Length)
                    {
                        int num4 = stream.ReadByte();
                        if (num4 != -1)
                        {
                            byte[] buffer3 = new byte[buffer.Length * 2];
                            Buffer.BlockCopy(buffer, 0, buffer3, 0, buffer.Length);
                            Buffer.SetByte(buffer3, offset, (byte) num4);
                            buffer = buffer3;
                            offset++;
                        }
                    }
                }
                byte[] dst = buffer;
                if (buffer.Length != offset)
                {
                    dst = new byte[offset];
                    Buffer.BlockCopy(buffer, 0, dst, 0, offset);
                }
                buffer4 = dst;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = position;
                }
            }
            return buffer4;
        }

        public static DateTime ToLocalTime(this DateTime utcDateTime, string timeZoneById)
        {
            TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneById);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc), destinationTimeZone);
        }

        public static DateTime? ToLocalTime(this DateTime? utcDateTime, string timeZoneById)
        {
            if (utcDateTime.HasValue)
            {
                return new DateTime?(utcDateTime.Value.ToLocalTime(timeZoneById));
            }
            return null;
        }

        public static TimeSpan? ToLocalTime(this TimeSpan? utcTimeSpan, string timeZoneById)
        {
            if (utcTimeSpan.HasValue)
            {
                return new TimeSpan?(utcTimeSpan.Value.ToLocalTime(timeZoneById));
            }
            return null;
        }

        public static TimeSpan ToLocalTime(this TimeSpan utcTimeSpan, string timeZoneById)
        {
            TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneById);
            DateTime time3 = new DateTime(0x7e0, 1, 1);
            return TimeZoneInfo.ConvertTimeFromUtc(time3.Add(utcTimeSpan), destinationTimeZone).TimeOfDay;
        }

        public static DateTime ToTimeSpan(this string timeSpan) => 
            DateTime.ParseExact(timeSpan, "hh:mm tt", CultureInfo.InvariantCulture);

        public static DateTime ToUtcTime(this DateTime utcDateTime, string timeZoneById)
        {
            TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneById);
            return TimeZoneInfo.ConvertTimeToUtc(utcDateTime, sourceTimeZone);
        }

        public static DateTime? ToUtcTime(this DateTime? localDateTime, string timeZoneById)
        {
            if (localDateTime.HasValue)
            {
                return new DateTime?(localDateTime.Value.ToUtcTime(timeZoneById));
            }
            return null;
        }

        public static TimeSpan? ToUtcTime(this TimeSpan? localTimeSpan, string timeZoneById)
        {
            if (localTimeSpan.HasValue)
            {
                return new TimeSpan?(localTimeSpan.Value.ToUtcTime(timeZoneById));
            }
            return null;
        }

        public static TimeSpan ToUtcTime(this TimeSpan localTimeSpan, string timeZoneById)
        {
            DateTime time3 = new DateTime(0x7e0, 1, 1);
            return time3.Add(localTimeSpan).ToUtcTime(timeZoneById).TimeOfDay;
        }
    }
}

