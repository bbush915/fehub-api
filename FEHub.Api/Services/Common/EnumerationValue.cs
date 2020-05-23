//-----------------------------------------------------------------------------
// <copyright file="Enumeration.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FEHub.Api.Services.Common
{
    internal sealed class EnumerationValue
    {
        #region Constructors
        public EnumerationValue(Enum value)
        {
            this.Name = value.ToString();
            this.Value = Convert.ToInt32(value);

            var displayInfo = value
                .GetType()
                .GetMember(value.ToString())[0]
                .GetCustomAttribute<DisplayAttribute>();

            this.Description = displayInfo.GetDescription();
            this.DisplayValue = displayInfo.GetName();
        }
        #endregion

        #region Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DisplayValue { get; private set; }
        public int Value { get; private set; }
        #endregion
    }
}
