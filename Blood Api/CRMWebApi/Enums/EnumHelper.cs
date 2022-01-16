namespace NashWebApi.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class EnumHelper
    {
        public static T EnumToEnum<T, TU>(TU enumArg)
        {
            T local;
            if (!typeof(T).IsEnum)
            {
                throw new Exception("This method only takes enumerations.");
            }
            if (!typeof(TU).IsEnum)
            {
                throw new Exception("This method only takes enumerations.");
            }
            try
            {
                local = (T) Enum.ToObject(typeof(T), enumArg);
            }
            catch
            {
                throw new Exception($"Error converting enumeration {enumArg} value {typeof(TU)} to enumeration {typeof(T)} ");
            }
            return local;
        }

        public static List<T> GetAllFromEnum<T>() => 
            GetFieldsFromEnum<T>().Select<string, T>(new Func<string, T>(EnumHelper.GetEnumType<T>)).ToList<T>();

        public static string GetEnumFieldDescription(this Enum value)
        {
            DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (customAttributes.Length == 0)
            {
                return value.ToString();
            }
            return customAttributes[0].Description;
        }

        public static T GetEnumType<T>(int value) => 
            ((T) Enum.Parse(typeof(T), value.ToString()));

        public static T GetEnumType<T>(this string value) => 
            ((T) Enum.Parse(typeof(T), value));

        public static T GetEnumTypeFromDescription<T>(string desc)
        {
            Type enumType = typeof(T);
            foreach (string str in Enum.GetNames(enumType))
            {
                if (((Enum) Enum.Parse(enumType, str)).GetEnumFieldDescription().Equals(desc))
                {
                    return (T) Enum.Parse(enumType, str);
                }
            }
            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }

        public static TEnum GetEnumTypeTry<TEnum>(this string value, TEnum defaultType) where TEnum: struct
        {
            TEnum local;
            if (!Enum.TryParse<TEnum>(value, true, out local))
            {
                return defaultType;
            }
            return local;
        }

        public static int GetEnumValue<T>(T enumField) => 
            Convert.ToInt32(enumField);

        public static List<string> GetFieldsFromEnum<T>() => 
            Enum.GetNames(typeof(T)).ToList<string>();
    }
}

