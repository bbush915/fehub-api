//-----------------------------------------------------------------------------
// <copyright file="AdoHelpers.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace FEHub.Api.Utilities
{
    public static class AdoHelpers
    {
        public static DataTable BuildDataTable<T>(IEnumerable<T> values)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Value", typeof(T)));

            foreach (var value in values)
            {
                dataTable.Rows.Add(value);
            }

            return dataTable;
        }
    }
}
