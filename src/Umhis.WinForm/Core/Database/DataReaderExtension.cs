using System;
using System.Data;

namespace Umhis.Core.Database
{
    public static class DataReaderExtension
    {
        private static readonly DateTime OldDate = new DateTime(1920, 1, 1);

        private static bool TryGetOrdinal(this IDataRecord dr, string fieldName, out int colIndex)
        {
            try
            {
                colIndex = dr.GetOrdinal(fieldName);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                colIndex = -1;
                return false;
            }
        }


        public static string GetStringFrom(this IDataRecord dr, string fieldName, string valueIfNull = "")
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;

            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetString(colIndex);
        }


        public static int GetInt32From(this IDataReader dr, string fieldName, int valueIfNull = 0)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetInt32(colIndex);
        }


        public static byte GetByteFrom(this IDataReader dr, string fieldName, byte valueIfNull = 0)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetByte(colIndex);
        }


        public static DateTime GetDateTimeFrom(this IDataReader dr, string fieldName, DateTime? valueIfNull = null)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull ?? OldDate;
            return dr.IsDBNull(colIndex) ? valueIfNull ?? OldDate : dr.GetDateTime(colIndex);
        }

        public static Guid GetGuidFrom(this IDataReader dr, string fieldName, Guid? valueIfNull = null)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull ?? Guid.Empty;
            return dr.IsDBNull(colIndex) ? valueIfNull ?? Guid.Empty : dr.GetGuid(colIndex);
        }


        public static bool GetBooleanFrom(this IDataReader dr, string fieldName, bool valueIfNull = false)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetBoolean(colIndex);
        }

        public static long GetInt64From(this IDataReader dr, string fieldName, long valueIfNull = 0)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetInt64(colIndex);
        }


        public static long GetLongFrom(this IDataReader dr, string fieldName, long valueIfNull = 0)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetInt64(colIndex);
        }


        public static decimal GetDecimalFrom(this IDataReader dr, string fieldName, decimal valueIfNull = 0)
        {
            if (!dr.TryGetOrdinal(fieldName, out var colIndex)) return valueIfNull;
            return dr.IsDBNull(colIndex) ? valueIfNull : dr.GetDecimal(colIndex);
        }
    }
}
