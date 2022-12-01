using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Configuration
{
    public static class SqlReaderUtilities
    {
        public static T SafeGet<T>(this DbDataReader reader, string columnName)
        {
            var indexOfColumn = reader.GetOrdinal(columnName);
            return reader.IsDBNull(indexOfColumn) ? default(T) : reader.GetFieldValue<T>(indexOfColumn);
        }
    }
}