namespace NashWebApi.Enums
{
    using System;
    using System.ComponentModel;

    public enum DaysOfWeek
    {
        [Description("Friday")]
        Friday = 5,
        [Description("Monday")]
        Monday = 1,
        [Description("Saturday")]
        Saturday = 6,
        [Description("Sunday")]
        Sunday = 7,
        [Description("Thursday")]
        Thursday = 4,
        [Description("Tuesday")]
        Tuesday = 2,
        [Description("Wednesday")]
        Wednesday = 3
    }
}

