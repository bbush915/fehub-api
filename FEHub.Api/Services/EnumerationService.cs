//-----------------------------------------------------------------------------
// <copyright file="EnumerationService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using FEHub.Api.Services.Common;

namespace FEHub.Api.Services
{
    internal sealed class EnumerationService<T>
    {
        #region Methods
        public List<EnumerationValue> GetAll()
        {
            return Enum
                .GetValues(typeof(T))
                .Cast<Enum>()
                .Select(x => new EnumerationValue(x))
                .ToList();
        }
        #endregion
    }
}
