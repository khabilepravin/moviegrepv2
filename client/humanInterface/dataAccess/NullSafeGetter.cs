using System;
using System.Data;
using System.Text.RegularExpressions;

namespace dataAccess
{
    public static class NullSafeGetter
    {
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return row.GetValueOrDefault<T>(ordinal);
        }


        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }

        public static object GetDefault(this Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }

        public static T GetDefault<T>()
        {
            var t = typeof(T);
            return (T)GetDefault(t);
        }

        public static object IsDefault<T>(T other)
        {
            T defaultValue = GetDefault<T>();
            if (other == null)
            {
                return (object)DBNull.Value;
            }
            else if (other is bool) // since default value for bool is false which is also a valid value.
            {
                return other;
            }
            else if (other.Equals(defaultValue))
            {
                return (object)DBNull.Value;
            }
            else
            {
                return other;
            }
        }

        public static string UrlFriendlyString(this string inputString)
        {
            if(!string.IsNullOrWhiteSpace(inputString))                        
            {

                inputString = Regex.Replace(inputString, @"[^\w\@\- ]", string.Empty);
                inputString = inputString.Replace(" ", "-");
                return inputString.ToLower();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
