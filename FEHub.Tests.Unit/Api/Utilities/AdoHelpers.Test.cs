//-----------------------------------------------------------------------------
// <copyright file="AdoHelpers.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;

using FEHub.Api.Utilities;

using Xunit;

namespace FEHub.Tests.Unit.Api.Utilities
{
    public sealed class AdoHelpersTests
    {
        [Fact]
        public void BuildDataTable_NoValues_ReturnsDataTable()
        {
            // Arrange

            var values = new List<int>();

            // Act

            var dataTable = AdoHelpers.BuildDataTable(values);

            // Assert

            Assert.True(dataTable.Columns.Contains("Value"));
            Assert.Equal(0, dataTable.Rows.Count);
        }

        [Fact]
        public void BuildDataTable_SingleInteger_ReturnsDataTable()
        {
            // Arrange

            var values = new List<int>() { 1 };

            // Act

            var dataTable = AdoHelpers.BuildDataTable(values);

            // Assert

            Assert.True(dataTable.Columns.Contains("Value"));
            Assert.Equal(1, dataTable.Rows.Count);

            Assert.Equal(1, dataTable.Rows[0]["Value"]);
        }

        [Fact]
        public void BuildDataTable_MultipleStrings_ReturnsDataTable()
        {
            // Arrange

            var values = new List<string>() { "Mary", "had", "a", "little", "lamb" };

            // Act

            var dataTable = AdoHelpers.BuildDataTable(values);

            // Assert

            Assert.True(dataTable.Columns.Contains("Value"));
            Assert.Equal(5, dataTable.Rows.Count);

            Assert.Equal("Mary", dataTable.Rows[0]["Value"]);
            Assert.Equal("had", dataTable.Rows[1]["Value"]);
            Assert.Equal("a", dataTable.Rows[2]["Value"]);
            Assert.Equal("little", dataTable.Rows[3]["Value"]);
            Assert.Equal("lamb", dataTable.Rows[4]["Value"]);
        }
    }
}
