//-----------------------------------------------------------------------------
// <copyright file="IEnumerationService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;

using FEHub.Api.Services.Common;

namespace FEHub.Api.Services.Interfaces
{
    public interface IEnumerationService<T>
    {
        List<EnumerationValue> GetAll();
    }
}
